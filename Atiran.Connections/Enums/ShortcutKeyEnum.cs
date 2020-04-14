using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.Connections.Enums
{
    public enum ShortcutKeyEnum
    {
        #region Main Key

        
        HelpKey = Keys.F1,
        SearchFormsKey = (Keys.Alt | Keys.M),
        ActivatedFormKey = (Keys.Alt | Keys.F6),

        #endregion

    }
}
