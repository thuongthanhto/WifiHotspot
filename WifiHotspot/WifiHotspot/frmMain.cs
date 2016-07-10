using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiHotspot
{
    public partial class frmMain : Form
    {
        // Dùng để di chuyển form vì mặc định form non không di chuyển được 
        int TogMove;
        int MValX;
        int MValY;
        public frmMain()
        {
            InitializeComponent();
            frmUse use = new frmUse();
            use.MdiParent = this;
            use.Dock = DockStyle.Fill;
            use.Show();
        }
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void pnlTitle_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMininize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd add = new frmAdd();
            add.MdiParent = this;
            add.Dock = DockStyle.Fill;
            add.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelete del = new frmDelete();
            del.MdiParent = this;
            del.Dock = DockStyle.Fill;
            del.Show();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo("cmd", "/c netsh wlan show hostednetwork");
            proc.RedirectStandardOutput = true;
            proc.UseShellExecute = false;
            proc.CreateNoWindow = true;
            Process a = new Process();
            a.StartInfo = proc;
            a.Start();
            string result = a.StandardOutput.ReadToEnd();
            MessageBox.Show(this, result, "Thông tin wifi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
