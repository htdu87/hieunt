using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuyenDung
{
    public class BaseChildForm: Form
    {
        public BaseChildForm()
        {
            this.MdiParent = Program.frm;
        }
    }
}
