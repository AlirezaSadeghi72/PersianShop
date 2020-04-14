using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Atiran.UI.WindowsForms
{
   public class BlinkLabel:UI.WindowsForms.Controls.Label
    {
        private const int _maxNumberOfBlinks = 10000;
        private int _blinkCount = 0;
        private Timer _timer;
        private Color oldColor;

        public BlinkLabel()
        {
            this._timer = new Timer();
            this._timer.Tick += new EventHandler(_timer_Tick);
            this._timer.Interval = 621;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!this._timer.Enabled && base.IsHandleCreated && this.Visible==true) StartBlink();
        }

        public void StartBlink()
        {
            this._blinkCount = 0;
            base.Visible = true;
            this.oldColor = base.ForeColor;
            base.ForeColor = System.Drawing.Color.Red;
            this._timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            base.Visible = !base.Visible;
            this._blinkCount++;
            if (this._blinkCount >= _maxNumberOfBlinks)
            {
                this._timer.Stop();
                base.Visible = true;
                base.ForeColor = oldColor;
            }
        }
    }
}
