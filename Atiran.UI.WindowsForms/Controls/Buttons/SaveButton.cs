using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class SaveButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
        private IComponentChangeService _changeService;
        public SaveButton()
        {
            InitializeUI();
            this.AutoSize = false;
            this.Margin = new Padding(10);
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 140, 231);
            this.EnabledChanged += SaveButton_EnabledChanged;
        }

        private void SaveButton_EnabledChanged(object sender, System.EventArgs e)
        {
            if (this.Enabled == false)
            {
                this.BackColor = Color.FromArgb(143, 215, 255);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(0, 140, 231);
                this.ForeColor = Color.White;
            }
        }

        private void InitializeUI()
        {
           // this.AutoSize = false;
           // this.Margin = new Padding(10);
           // this.FlatAppearance.BorderSize = 1;
           // this.FlatAppearance.BorderColor = Color.Gray;
            
            this.BackColor = Color.FromArgb(0, 140, 231);
            this.ForeColor = Color.White;
            //this.Font = FontManager.GetFont("IRNazanin", 14, System.Drawing.FontStyle.Bold);
            //this.Width = 75;
            //this.Height = 35;
        }

        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                _changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (_changeService != null)
                    _changeService.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
                base.Site = value;
                if (!DesignMode)
                    return;
                _changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (_changeService != null)
                    _changeService.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
            }
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs ce)
        {
            SaveButton aBtn = ce.Component as SaveButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("saveButton", "ثبت");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
