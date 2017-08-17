using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{
    class Delegates
    {
    }

    public delegate void GoGoPowerRangers();
    public delegate void LoadApplicationsDelegate();
    public delegate void LoadApplicationsDetailsDelegate();
    public delegate void ApplicationApproveDelegate();
    public delegate void ApplicationRevokeDelegate();
    public delegate void CustomEvent(object sender, EventArgs e, SacramentType t);
    public delegate void LoadApplicationDetailsDelegate(DataGridView dgv);
}
