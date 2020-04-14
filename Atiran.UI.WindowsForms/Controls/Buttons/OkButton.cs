using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class OkButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
        private IComponentChangeService _changeService;
        public OkButton()
        {
            InitializeUI();
        }
        private void InitializeUI()
        {
            this.BackColor = Color.FromArgb(29, 142, 174);
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
            OkButton aBtn = ce.Component as OkButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("okButton", "تاييد");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
