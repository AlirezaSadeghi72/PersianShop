using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class AccountingEnviromentHeader : UI.WindowsForms.UIElements.EnvironmentHeader
    {
        //public AccountingPath accPath;
        public AccountingEnviromentHeader(EnviromentMainForm parent_) : base(parent_)
        {

        }

        public override void FillLeftPanel()
        {
            dateAndTime = new DateAndTimeHeaderButton(this);
            user = new UserHeaderButton(this, GetCurrentSysUser.Instance.UserName);
            //accPath = new AccountingPath(this, Connections.ConnectionInfo.CurrentMasirName);
            this.leftPanel.Controls.Add(dateAndTime);
            HeaderSeperator seperator = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator);
            HeaderSeperator seperator4 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator4);
            HeaderSeperator seperator1 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator1);
            this.leftPanel.Controls.Add(user);
            HeaderSeperator seperator2 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator2);
            HeaderSeperator seperator5 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator5);
            HeaderSeperator seperator6 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator6);
        }
    }

}
