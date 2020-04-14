using System;
using System.Drawing;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.UI.WindowsForms.UIElements
{
    public  class EnvironmentHeader : Header
    {
        //public static Atiran.UI.WindowsForms.ResourceManager ResourceManagerInstance;
        public HomeHeaderButton home;
        public MaximizeHeaderButton max;
        public MinimizeHeaderButton min;
        public EnvironmentTitleHeaderButton title;
        public DateAndTimeHeaderButton dateAndTime;
        public UserHeaderButton user;
        public EnviromentMainForm EnvParent;
        public string Headertitle;

        public EnvironmentHeader(EnviromentMainForm parent_): base(parent_)
        {
            this.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 11.5F, FontStyle.Bold);
            this.Height = 39;
            EnvParent = parent_;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            Headertitle = EnvironmentNames.GetTitle(EnvParent.environment);

            if (parent_.environment!=Connections.Enums.Definitions.EnvironmentNames.Login)
            {
                this.BackColor = System.Drawing.Color.FromArgb(120,144,156);
                FillRightPanel();
                FillLeftPanel();
            }
            parent_.Controls.Add(this);
           
        }

     
        public virtual void FillRightPanel()
        {
            home = new HomeHeaderButton(this);
            max = new MaximizeHeaderButton(this);
            min = new MinimizeHeaderButton(this);
            title = new EnvironmentTitleHeaderButton(this,ResourceManager.GetResourceManager().GetString(Headertitle),System.Drawing.Color.FromArgb(255, 255, 255));

            this.rightPanel.Controls.Add(home);
            this.rightPanel.Controls.Add(max);
            this.rightPanel.Controls.Add(min);
            TitleHeaderSeperator seperator3 = new TitleHeaderSeperator(this.leftPanel);
            this.rightPanel.Controls.Add(seperator3);
            this.rightPanel.Controls.Add(title);
        }
        public virtual void FillLeftPanel()
        {
            dateAndTime = new DateAndTimeHeaderButton(this);
            user = new UserHeaderButton(this, GetCurrentSysUser.Instance.UserName);
            this.leftPanel.Controls.Add(dateAndTime);
            HeaderSeperator seperator = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator);
            if (EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.Reporting || EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.SalesManagement | EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.Sales | EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.BasicInformation | EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.Treasury | EnvParent.environment==Connections.Enums.Definitions.EnvironmentNames.KalaGostaran | EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.Rahyab| EnvParent.environment == Connections.Enums.Definitions.EnvironmentNames.EMS)
            {
                HeaderSeperator seperator3 = new HeaderSeperator(this.leftPanel);
                this.leftPanel.Controls.Add(seperator3);
              
            }
            HeaderSeperator seperator1 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator1);
            this.leftPanel.Controls.Add(user);
            HeaderSeperator seperator2 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator2);
            HeaderSeperator seperator4 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator4);
            HeaderSeperator seperator5 = new HeaderSeperator(this.leftPanel);
            this.leftPanel.Controls.Add(seperator5);
        }

    }
}
