using Sts.Lib.Win.Drawing.Extensions;

namespace Sts.Lib.Win.Test.App;

public class LL : Label
{
    protected override void OnClientSizeChanged(EventArgs e)
    {
        base.OnClientSizeChanged(e);
        //SuspendLayout();
        var fitFont = Font.FitFont(CreateGraphics(),new Size(ClientSize.Width-4, ClientSize.Height-4), Text);
        Font.Dispose();
        Font = fitFont;
        //ResumeLayout();
        //Invalidate();
    }
}
