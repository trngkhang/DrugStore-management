using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugStore
{
    public partial class Loading : Form
    {
        private string tendn;
        public Loading(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(10);
            if(progressBar.Value >= 100)
            {
                FHomePage f = new FHomePage(this.tendn);
                f.Show();
                this.Close();
            }
        }
    }
}
