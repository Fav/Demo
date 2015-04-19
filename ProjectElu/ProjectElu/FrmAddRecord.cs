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
    public partial class FrmAddRecord : Form
    {
        private PRODUCT _Product;

        public PRODUCT Product
        {
            get { return _Product; }
        }

        public FrmAddRecord()
        {
            InitializeComponent();
            dtStartTime.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var item in panel1.Controls)
            {
                TextBox tb = item as TextBox;
                if (tb == null)
                    continue;
                if (string.IsNullOrEmpty( tb.Text))
                {
                    MessageBox.Show("信息不完整，请检查");
                    return;
                }
            }
            _Product = new PRODUCT();
            _Product.ID = CommonMethod.GetID();
            _Product.UNIT = tbUnit.Text;
            _Product.DEPARTMENT = tbDepartment.Text;
            _Product.CONTACTS = tbContacts.Text;
            _Product.PHONE = tbPhone.Text;
            _Product.INSTRUMENT = tbInstructment.Text;
            _Product.STARTTIME = dtStartTime.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmAddRecord_Load(object sender, EventArgs e)
        {
            USER user = CommonMethod.g_User;
            //部门管理员只能添加自己单位的
            if (user.ROLETYPE!=0)
            {
                tbUnit.Text = user.UNIT;
                tbUnit.Enabled = false;
            }
        }

    }
}
