using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectElu
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            string strbg = "res/bg.png";
            if (System.IO.File.Exists(strbg))
            {
                this.BackgroundImage = Image.FromFile(strbg);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CreateValidateCode();
        }
        private void CreateValidateCode()
        {
            string code = ValidateCodeUtil.CreateRandomCode(4);
            Image image = ValidateCodeUtil.CreateImage(code);
            image.Tag = code;
            pbImageCode.Image = image;
            this.txtValidateCode.Text = code;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblWarn.Text = "";
            string name =tbUser.Text;
            string pw = CommonMethod.MD5Encrypt(tbPw.Text);
            USER user = BaseDA.Retrive<USER>(name);
            if (user == null)
            {
                lblWarn.Text = "用户名或密码错误";
                return;
            }
            if (user.USERNAME == name && user.PASSWORD == pw)
            {
                CommonMethod.g_User = user;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                lblWarn.Text = "用户名或密码错误";
            }
        }
    }
}
