using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class EditButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
        private IComponentChangeService _changeService;
        public EditButton()
        {
            InitializeUI();
            this.EnabledChanged += EditButton_EnabledChanged;
          
        }

        private void EditButton_EnabledChanged(object sender, System.EventArgs e)
        {
            this.BackColor = this.Enabled ? Color.Green : Color.FromArgb(203, 240, 197);
        }

        //protected override void OnPaint(PaintEventArgs pevent)
        //{
        //    this.ForeColor = this.Enabled ? Color.Transparent : Color.White;
        //    base.OnPaint(pevent);
        //    TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, this.BackColor);
           
        //}
        private void InitializeUI()
        {
            this.AutoSize = false;
            this.Margin = new Padding(10);
            this.FlatAppearance.BorderSize = 1;

            this.FlatAppearance.BorderColor = Color.Green;
          
            this.BackColor = Color.Green;
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
            EditButton aBtn = ce.Component as EditButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("editButton", "ويرايش");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
