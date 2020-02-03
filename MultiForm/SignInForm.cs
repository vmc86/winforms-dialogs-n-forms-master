using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MultiForm.Form1;
using static MultiForm.Form2;

namespace MultiForm
{
    public partial class SignInForm : Form
    {
        public OnResult OnResultCallback { set; private get; }
        public SignInForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> resultArgs = new Dictionary<string, object>();
            resultArgs["password"] = passwordTextBox.Text;
            //DialogResult = DialogResult.OK;
            OnResultCallback(resultArgs);
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
