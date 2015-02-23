using System;
using System.Windows.Forms;

namespace OCRTHINGEE
{
    public partial class ShowSystemName : Form
    {
        public ShowSystemName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.Text = @"Enter a valid Galaxy here!";
                return;
            }
            Form1.Systemname = textBox2.Text;
            Form1.Stationname = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ShowSystemName_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form1.Systemname;
            textBox1.Text = Form1.Stationname;
        }
    }
}
