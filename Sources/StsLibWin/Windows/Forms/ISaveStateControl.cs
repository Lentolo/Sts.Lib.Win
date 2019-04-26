namespace StsLibWin.Windows.Forms
{
  public interface ISaveStateControl
  {
    bool CanSaveState();
    object GetControlState();
    void SetControlState(object value);
  }
}