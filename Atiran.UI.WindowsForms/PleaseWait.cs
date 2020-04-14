using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms
{
   public class PleaseWait : IDisposable
    {
        public Form mSplash;
        private LoadingForm loading;
        private Control parent;
        private bool onParent;
        public PleaseWait(Control parent, bool onParent = false)
        {
            this.parent = parent;
            this.onParent = onParent;
            Thread t = new Thread(new ThreadStart(workerThread));
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public void Dispose()
        {
            mSplash.Invoke(new MethodInvoker(stopThread));
        }
        private void stopThread()
        {
            mSplash.Close();
        }
        private void workerThread()
        {
            if (parent != null)
            {
                mSplash = new Form();
                loading = new LoadingForm();
                loading.Dock = DockStyle.Fill;
                mSplash.Controls.Add(loading);
                mSplash.MinimumSize = mSplash.Size = parent.Size;
                mSplash.WindowState = FormWindowState.Normal;
                mSplash.FormBorderStyle = FormBorderStyle.None;
                mSplash.StartPosition =  FormStartPosition.CenterScreen;
                Application.Run(mSplash);
            }
        }


    }
}

