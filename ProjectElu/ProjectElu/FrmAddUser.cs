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
    public partial class FrmAddUser : Form
    {
        public string UserName { get; set; }
        public string PSW { get; set; }
        public string UNIT { get; set; }
        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPW.Text) || string.IsNullOrEmpty(tbUserName. Text) || string.IsNullOrEmpty(tbUnit. Text))
            {
                CommonMethod.OutLog("输入信息不完全");
                return;
            }
            UserName = tbUserName.Text;
            PSW = CommonMethod.MD5Encrypt(tbPW.Text);
            UNIT = tbUnit.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
