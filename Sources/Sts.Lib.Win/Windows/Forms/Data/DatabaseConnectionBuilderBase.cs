using Sts.Lib.Data;

namespace Sts.Lib.Win.Windows.Forms.Data;

public class DatabaseConnectionBuilderBase : UserControl
{
    public virtual GenericConnectionString ConnectionString
    {
        get;
    }

    public virtual string DatabaseTypeName
    {
        get;
    }

    public virtual bool Test()
    {
        try
        {
            using var db = ConnectionString.CreateAndOpenConnection();
            return true;
        }
        catch
        {
            // ignored
        }

        return false;
    }
}
