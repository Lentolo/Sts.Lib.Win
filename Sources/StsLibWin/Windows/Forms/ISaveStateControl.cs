namespace StsLibWin.Windows.Forms
{
  public interface ISaveStateControl
  {
    string GetControlKey();
    bool CanSaveValue();
    object GetControlValue();
    void SetControlValue(object value);
  }
}