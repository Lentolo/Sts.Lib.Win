using System;
using System.Drawing;

namespace Sts.Lib.Win.Drawing;

public class Captcha
{
    public delegate double StretchFunctionDelegate(double x);

    private int _height = 240;
    private int _noiseBlockNum = 10;
    private int _noiseElementPerBlock = 15;
    private int _noiseFillFactor = 30;
    private int _stretchBlockNum = 5000;
    private int _width = 320;

    public string Text
    {
        get;
        set;
    } = "";

    public int Width
    {
        get
        {
            return System.Math.Max(1, _width);
        }
        set
        {
            _width = value;
        }
    }

    public int Height
    {
        get
        {
            return System.Math.Max(1, _height);
        }
        set
        {
            _height = value;
        }
    }

    public Color BackGroundColor
    {
        get;
        set;
    } = Color.White;

    public Color ForeGroundColor
    {
        get;
        set;
    } = Color.Black;

    public bool Stretch
    {
        get;
        set;
    } = true;

    public bool Noise
    {
        get;
        set;
    } = true;

    private int NoiseBlockNum
    {
        get
        {
            return System.Math.Max(1, _noiseBlockNum);
        }
    }

    private int NoiseElementPerBlock
    {
        get
        {
            return System.Math.Max(1, _noiseElementPerBlock);
        }
    }

    private int StretchBlockNum
    {
        get
        {
            return System.Math.Max(1, _stretchBlockNum);
        }
    }

    private int NoiseFillFactor
    {
        get
        {
            return System.Math.Max(1, _noiseFillFactor);
        }
    }

    public event StretchFunctionDelegate StretchFunction;

    public Bitmap GetCaptcha()
    {
        using var bmp = new Bitmap(Width, Height);

        if (!string.IsNullOrEmpty(Text) && Width > 0 && Height > 0)
        {
            using var graph = Graphics.FromImage(bmp);

            using (var solidBrush = new SolidBrush(BackGroundColor))
            {
                graph.FillRectangle(solidBrush, 0, 0, Width, Height);
            }

            SizeF textDim;
            var textPos = new PointF();
            var fontSize = 1;

            do
            {
                using var font = new Font(FontFamily.GenericSansSerif.Name, fontSize++);
                textDim = graph.MeasureString(Text, font);
            }
            while (textDim.Width < Width && (Stretch && textDim.Height < Height / 3 || !Stretch && textDim.Height < Height));

            fontSize--;

            using (var font = new Font(FontFamily.GenericSansSerif.Name, fontSize++))
            {
                using (var solidBrush = new SolidBrush(ForeGroundColor))
                {
                    textDim = graph.MeasureString(Text, font);
                    textPos.X = (Width - textDim.Width) / 2;
                    textPos.Y = (Height - textDim.Height) / 2;
                    graph.DrawString(Text, font, solidBrush, textPos);
                }
            }

            var random = new Random();

            if (Noise)
            {
                float x, y, rr = (float)System.Math.Sqrt(NoiseFillFactor / 100.0 * textDim.Width / NoiseBlockNum * textDim.Height / NoiseBlockNum / (System.Math.PI * NoiseElementPerBlock));

                for (var r = 0; r < NoiseBlockNum; r++)
                {
                    for (var c = 0; c < NoiseBlockNum; c++)
                    {
                        for (var p = 0; p < NoiseElementPerBlock; p++)
                        {
                            using var solidBrush = new SolidBrush(ForeGroundColor);
                            y = textPos.Y + textDim.Height / NoiseBlockNum * ((float)random.NextDouble() + r);
                            x = textPos.X + textDim.Width / NoiseBlockNum * ((float)random.NextDouble() + c);
                            graph.FillEllipse(solidBrush, x - rr, y - rr, 2 * rr, 2 * rr);
                        }
                    }
                }
            }

            if (Stretch)
            {
                var funcId = random.Next(0, 3);
                using var bmp2 = (Bitmap)bmp.Clone();

                using (var solidBrush = new SolidBrush(BackGroundColor))
                {
                    graph.FillRectangle(solidBrush, 0, 0, Width, Height);
                }

                var origRect = new RectangleF();
                float y;

                for (var c = 0; c < StretchBlockNum; c++)
                {
                    //OrigRect.Location = new System.Drawing.PointF(
                    //    TextPos.X + (float)c * TextDim.Width / (float)m_StretchBlockNum,
                    //    TextPos.Y);
                    //OrigRect.Size = new System.Drawing.SizeF(
                    //    TextDim.Width / (float)m_StretchBlockNum,
                    //    TextDim.Height);
                    //y = TextPos.Y + TextDim.Height * (float)System.Math.Min(1.0, System.Math.Max(-1.0, StretchFunction((float)c / (float)m_StretchBlockNum)));
                    //Graph.DrawImage(Bmp2, OrigRect.Left, y, OrigRect, System.Drawing.GraphicsUnit.Pixel);
                    origRect.Location = new PointF((float)c * Width / StretchBlockNum, textPos.Y);
                    origRect.Size = new SizeF(Width / (float)StretchBlockNum, Height);
                    y = textPos.Y - textDim.Height * (float)System.Math.Min(1.0, System.Math.Max(-1.0, OnStretchFunction(funcId, c / (float)StretchBlockNum)));
                    graph.DrawImage(bmp2, origRect.Left, y, origRect, GraphicsUnit.Pixel);
                }
            }
        }

        return (Bitmap)bmp.Clone();
    }

    protected virtual double OnStretchFunction(int funcId, double x)
    {
        if (StretchFunction != null)
        {
            return StretchFunction(x);
        }

        switch (funcId)
        {
            case 0:
                return StretchFunctionCos(x);
            case 1:
                return StretchFunctionCubic(x);
            case 2:
                return StretchFunctionParabolic(x);
        }

        return StretchFunctionSin(x);
    }

    public void SetStretchParams(int stretchBlockNum)
    {
        _stretchBlockNum = stretchBlockNum;
    }

    public void SetNoiseParams(int noiseBlockNum, int noiseElementPerBlock, int noiseFillFactor)
    {
        _noiseBlockNum = noiseBlockNum;
        _noiseElementPerBlock = noiseElementPerBlock;
        _noiseFillFactor = noiseFillFactor;
    }

    public static double StretchFunctionSin(double x)
    {
        return System.Math.Sin(2 * System.Math.PI * x);
    }

    public static double StretchFunctionCos(double x)
    {
        return System.Math.Cos(2 * System.Math.PI * x);
    }

    public static double StretchFunctionParabolic(double x)
    {
        return 6.0 * System.Math.Pow(x, 2.0) - 5.0 * x;
    }

    public static double StretchFunctionCubic(double x)
    {
        return 8.0 * System.Math.Pow(x, 3.0) - 12.0 * System.Math.Pow(x, 2.0) + 6 * x - 1;
    }
}
