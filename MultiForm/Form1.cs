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
    public partial class Form1 : Form
    {
        private string password;
        public delegate void OnResult(Dictionary<string, object> resultArgs);
        public static BindingList<Good> GoodsModel { get; } =
            new BindingList<Good>();
        public static int SelectedGoodId { get; set; } = -1;
        public static Good SelectedGood { get; set; } = null;

        public Form1()
        {
            InitializeComponent();
            password = "123";
            SignInForm signInForm = new SignInForm();
            signInForm.OnResultCallback = (resultArgs) => {
                if (resultArgs["password"] as string == password)
                {
                    signInForm.Close();
                }
                else {
                    MessageBox.Show("Wrong password!");
                    return;
                }
                this.passwordLabel.Text = resultArgs["password"] as string;
            };
            signInForm.ShowDialog();
            goodsListBox.DataSource = GoodsModel;
            goodsListBox.SelectedValueChanged += (s, a) => {
                SelectedGood = (s as ListBox).SelectedItem as Good;
            };
            GoodsModel.ListChanged += (s, a) => { goodsListBox.SelectedItem = GoodsModel.ElementAtOrDefault(0); };
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            
        }

        private void addGoodButton_Click(object sender, EventArgs e)
        {
            GoodForm goodForm = new GoodForm() { CurrentMode = GoodForm.Mode.Add };
            goodForm.ShowDialog();
        }
        //public void activateBtn(bool status)
        //{
        //    editGoodButton.Visible = status;
        //    btnDelete.Visible = status;
        //}

        private void editGoodButton_Click(object sender, EventArgs e)
        {
            if (SelectedGood is null)
            {
                //activateBtn(false);
                return;
            }
           // activateBtn(true);
            GoodForm goodForm = new GoodForm() { CurrentMode = GoodForm.Mode.Edit };
            goodForm.ShowDialog();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedGood is null)
            {
                //activateBtn(false);
                return;
            }
            //activateBtn(true);
            Form2 vasy = new Form2() { CurrentMode = Form2.Mode.Delete };
            vasy.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
