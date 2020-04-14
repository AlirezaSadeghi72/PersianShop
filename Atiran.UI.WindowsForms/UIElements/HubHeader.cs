using System;
using System.Drawing;
using System.Windows.Forms;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class HubHeader : Header
    {
        public HubHeader(Form parent_): base(parent_)
        {
            this.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 15, FontStyle.Bold);
            this.Height = 46;

            Atiran.UI.WindowsForms.GetHubForm.GetCurrent = this.parent;
           CloseHeaderButton close = new CloseHeaderButton(this);
           MaximizeHeaderButton max = new MaximizeHeaderButton(this);
           MinimizeHeaderButton min = new MinimizeHeaderButton(this);
           this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
           this.rightPanel.Controls.Add(close);
           this.rightPanel.Controls.Add(max);
           this.rightPanel.Controls.Add(min);
           DateAndTimeHeaderButton dateTimeHeaderButton = new DateAndTimeHeaderButton(this);
           UserHeaderButton user = new UserHeaderButton(this, GetCurrentSysUser.Instance.UserName);
           ActivatedForms activated = new ActivatedForms(this, Connections.AtiranAccModel.ConnectionInfo.ActiveForms);

            this.leftPanel.Controls.Add(dateTimeHeaderButton);
           HeaderSeperator seperator = new HeaderSeperator(this.leftPanel);
           this.leftPanel.Controls.Add(seperator);
           
           HeaderSeperator seperator1 = new HeaderSeperator(this.leftPanel);
           this.leftPanel.Controls.Add(seperator1);
            HeaderSeperator seperator3 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator3);
            this.leftPanel.Controls.Add(user);
           HeaderSeperator seperator2 = new HeaderSeperator(this.leftPanel);
           this.leftPanel.Controls.Add(seperator2);
            HeaderSeperator seperator5 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator5);
            this.leftPanel.Controls.Add(activated);
            HeaderSeperator seperator6 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator6);
            parent_.Controls.Add(this);
            this.BringToFront();
           
            
        }

    }
}
