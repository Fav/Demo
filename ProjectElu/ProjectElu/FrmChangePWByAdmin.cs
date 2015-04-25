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
    public partial class FrmChangePWByAdmin : Form
    {
        public string NewPW { get; set; }
        public FrmChangePWByAdmin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPW.Text)||string.IsNullOrEmpty(tbNewPW2.Text) )
            {
                CommonMethod.OutLog("输入信息不完全");
                return;
            }

            if (tbNewPW.Text != tbNewPW2.Text)
            {
                CommonMethod.OutLog("两次输入密码不一致");
                return;
            }

            NewPW = CommonMethod.MD5Encrypt(tbNewPW.Text); ;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
