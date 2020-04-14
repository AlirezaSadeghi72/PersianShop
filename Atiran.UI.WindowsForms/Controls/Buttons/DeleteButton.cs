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
    public class DeleteButton : Atiran.UI.WindowsForms.Controls.Buttons.Button
    {
        private IComponentChangeService _changeService;
        public DeleteButton()
        {
            InitializeUI();
            this.Leave += DeleteButton_Leave;
          
            
        }

        private void DeleteButton_Leave(object sender, EventArgs e)
        {
            this.FlatAppearance.BorderColor = Color.Red;
            this.FlatAppearance.BorderSize = 1;
        }


        //protected override void OnPaint(PaintEventArgs pevent)
        //{
        //   this.ForeColor = this.Enabled ? Color.Red : Color.FromArgb(249, 197, 196) ;
        //    this.FlatAppearance.BorderColor = this.Enabled ? Color.Red: Color.FromArgb(249, 197, 196) ;
        //    base.OnPaint(pevent);
        //   TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, this.BackColor);
        //}
        private void InitializeUI()
        {
            this.AutoSize = false;
            this.Margin = new Padding(10);
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.Red;

            this.BackColor = Color.White;
            this.ForeColor = Color.Red;
            
            //this.Font = FontManager.GetFont("bnazanin", 14, System.Drawing.FontStyle.Bold);
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
            DeleteButton aBtn = ce.Component as DeleteButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            if (aBtn.Text == aBtn.Name)
                aBtn.Text = aBtn.Name.Replace("deleteButton", "حذف");
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();

        }
    }
}
