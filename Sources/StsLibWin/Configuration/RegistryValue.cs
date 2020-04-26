using System;
using System.Globalization;
using Microsoft.Win32;
using Sts.Lib.Common;
using Utils = Sts.Lib.Runtime.Serialization.Utils;

//using Convert = System.Convert;
namespace Sts.Lib.Win.Configuration
{
    [Serializable]
    public class RegistryValue<T> : RegistryValueBase
    {
        public delegate void SerializeDelegate(RegistryValue<T> registryValue, bool isSerializing, ref T value, ref string stringValue);
        public delegate void ValueTransformDelegate(RegistryValue<T> registryValue, bool isSettingValue, T inValue, ref T outValue);
        private readonly bool _createValueIfNotExists;
        private readonly T _default;
        private readonly TimeExpireValue<T> _value;
        public RegistryValue(RegistryKey rootKey, string subKey, string value, T Default, bool createValueIfNotExists, int expireSeconds)
            : base(rootKey, subKey, value)
        {
            _default = Default;
            _createValueIfNotExists = createValueIfNotExists;
            _value = new TimeExpireValue<T>(expireSeconds);
            _value.ExpiredValue += m_Value_ExpiredValue;
        }
        public T Value
        {
            get => _value.Value;
            set
            {
                SetValue(value);
                _value.SetExpired();
            }
        }
        private void m_Value_ExpiredValue(object sender, DataArgs<T> eventArg)
        {
            eventArg.Data = GetValue();
        }
        public static RegistryValue<T> Create(RegistryKey rootKey, string subKey, string value, T Default, bool createValueIfNotExists, int expireSeconds)
        {
            return new RegistryValue<T>(rootKey, subKey, value, Default, createValueIfNotExists, expireSeconds);
        }
        private bool ValueExists()
        {
            return RootKey.OpenSubKey(SubKey) != null && RootKey.OpenSubKey(SubKey).GetValue(ValueName) != null;
        }
        private T GetValue()
        {
            var rValue = _default;
            try
            {
                var value = RootKey.OpenSubKey(SubKey).GetValue(ValueName);
                if (value is T)
                {
                    rValue = (T)value;
                }
                else if (value is string)
                {
                    if (typeof(T) == typeof(bool))
                    {
                        rValue = Sts.Lib.Common.Convert.Utils.TryParseTo((string)value, _default);
                    }
                    else if (typeof(T) == typeof(float))
                    {
                        rValue = Sts.Lib.Common.Convert.Utils.TryParseTo((string)value, _default, CultureInfo.InvariantCulture, NumberStyles.Number);
                    }
                    else if (typeof(T) == typeof(double))
                    {
                        rValue = Sts.Lib.Common.Convert.Utils.TryParseTo((string)value, _default, CultureInfo.InvariantCulture, NumberStyles.Number);
                    }
                    else if (typeof(T) == typeof(DateTime))
                    {
                        rValue = Sts.Lib.Common.Convert.Utils.TryParseTo((string)value, _default, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    }
                    else if (typeof(T).IsEnum)
                    {
                        rValue = Sts.Lib.Common.Convert.Utils.TryParseTo((string)value, _default, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    }
                    else
                    {
                        var rVal = _default;
                        var strValue = (string)value;
                        OnSerialize(false, ref rVal, ref strValue);
                        rValue = rVal;
                    }
                }
            }
            catch
            {
            }

            OnValueTransform(false, rValue, ref rValue);
            if (_createValueIfNotExists && !ValueExists())
            {
                try
                {
                    SetValue(rValue);
                }
                catch
                {
                }
            }

            return rValue;
        }
        private void SetValue(T value)
        {
            OnValueTransform(true, value, ref value);
            if (typeof(T) == typeof(int) ||
                typeof(T) == typeof(long) ||
                typeof(T) == typeof(string))
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, value);
            }
            else if (typeof(T) == typeof(bool))
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, ((bool)(object)value).ToString(CultureInfo.InvariantCulture));
            }
            else if (typeof(T) == typeof(float))
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, ((float)(object)value).ToString(CultureInfo.InvariantCulture));
            }
            else if (typeof(T) == typeof(double))
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, ((double)(object)value).ToString(CultureInfo.InvariantCulture));
            }
            else if (typeof(T) == typeof(DateTime))
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, ((DateTime)(object)value).ToString(CultureInfo.InvariantCulture));
            }
            else if (typeof(T).IsEnum)
            {
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, ((int)(object)value).ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                var val = "";
                OnSerialize(true, ref value, ref val);
                Registry.SetValue(RootKey.Name + "\\" + SubKey, ValueName, val);
            }
        }
        public event SerializeDelegate Serialize;
        public event ValueTransformDelegate ValueTransform;
        protected virtual void OnSerialize(bool isSerializing, ref T value, ref string stringValue)
        {
            if (Serialize != null)
            {
                Serialize(this, isSerializing, ref value, ref stringValue);
            }
            else
            {
                if (isSerializing)
                {
                    stringValue = Utils.Serialize(value);
                }
                else
                {
                    value = Utils.DeSerialize<T>(stringValue);
                }
            }
        }
        protected virtual void OnValueTransform(bool isSettingValue, T inValue, ref T outValue)
        {
            if (ValueTransform != null)
            {
                ValueTransform(this, isSettingValue, inValue, ref outValue);
            }
            else
            {
                outValue = inValue;
            }
        }
    }
}