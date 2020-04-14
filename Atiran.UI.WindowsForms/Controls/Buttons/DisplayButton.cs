using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class DisplayButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
        private IComponentChangeService _changeService;
        public DisplayButton()
        {
            InitializeUI();
            this.EnabledChanged += Button_EnabledChanged;
        }
        private void Button_EnabledChanged(object sender, System.EventArgs e)
        {
            this.ForeColor = ((Button)sender).Enabled == false ? Color.Blue : Color.White;
            this.BackColor = ((Button)sender).Enabled == false ? Color.AliceBlue : Color.FromArgb(49, 27, 146);
        }
        private void InitializeUI()
        {
            this.AutoSize = false;
            this.Margin = new Padding(10);
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.FromArgb(49, 27, 146);

            this.BackColor = Color.FromArgb(49, 27, 146);
            this.ForeColor = Color.White;

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
            DisplayButton aBtn = ce.Component as DisplayButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("displayButton", "نمايش");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
