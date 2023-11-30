using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nguyen_CRM
{
    public partial class meeting : Form
    {
        public meeting()
        {
            InitializeComponent();
        }

        private void meeting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.meetings' table. You can move, or remove it, as needed.
            this.meetingsTableAdapter.Fill(this.dataSet1.meetings);

        }
    }
}
