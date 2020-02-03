using MultiForm.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiForm
{
    public partial class Form2 : Form
    {
        public enum Mode
        {
            Delete
        }
        private Mode mode;
        public Form2()
        {
            InitializeComponent();
        }

        public Mode CurrentMode
        {
            private get { return mode; }
            set
            {
                mode = value;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (mode == Mode.Delete)
            {
                Form1.GoodsModel.Remove(Form1.SelectedGood);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
