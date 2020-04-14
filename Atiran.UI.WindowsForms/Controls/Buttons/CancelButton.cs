using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class CancelButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
      
        private IComponentChangeService _changeService;
        public CancelButton()
        {
            InitializeUI();
            this.EnabledChanged += SaveButton_EnabledChanged;
            
        }

      

        private void SaveButton_EnabledChanged(object sender, System.EventArgs e)
        {
            if (this.Enabled == false)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Gray;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Gray;
            }
        }

        private void InitializeUI()
        {


            this.BackColor = Color.White;
            this.ForeColor = Color.Gray;
      
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
            CancelButton aBtn = ce.Component as CancelButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("cancelButton", "انصراف");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
