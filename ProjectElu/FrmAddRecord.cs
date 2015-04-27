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
        private PRODUCT _Product = null;

        public PRODUCT Product
        {
            set { _Product = value;}
            get { return _Product; }
        }

        public void Init()
        {
            if (_Product == null)
                return ;

            comboBoxDanWei.SelectedText = _Product.UNIT;
            tbDepartment.Text = _Product.DEPARTMENT;
            tbContacts.Text = _Product.CONTACTS;
            tbPhone.Text = _Product.PHONE;
            tbInstructment.Text = _Product.INSTRUMENT;
            if (_Product.STARTTIME == null)
                dtStartTime.Value = DateTime.Now;
            else
            {
                if (_Product.STARTTIME < DateTime.MaxValue && _Product.STARTTIME > DateTime.MinValue)
                    dtStartTime.Value = _Product.STARTTIME;
                else
                    dtStartTime.Value = DateTime.Now;
            }
        }

        public FrmAddRecord()
        {
            InitializeComponent();

            QueryCollection qc = new QueryCollection();
            qc.AddQueryParam("ROLETYPE", 1);
            IList<USER> lst = BaseDA.QueryForList<USER>(CommonMethod.PrepareQuery(qc.QueryParams));

            comboBoxDanWei.Items.Clear();
            foreach(USER uesr in lst)
            {
                comboBoxDanWei.Items.Add(uesr.UNIT);
            }
            comboBoxDanWei.SelectedIndex = 0;
           
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

            if (_Product == null)
            {
                _Product = new PRODUCT();
                _Product.ID = CommonMethod.GetID();
            }
            _Product.UNIT = comboBoxDanWei.Text;
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
                comboBoxDanWei.Text = user.UNIT;
                comboBoxDanWei.Enabled = false;
            }
        }

    }
}
