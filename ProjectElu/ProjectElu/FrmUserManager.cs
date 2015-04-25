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
    public partial class FrmUserManager : Form
    {
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAddUser frm = new FrmAddUser();
            if (frm.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
            {
                return; 
            }
            USER user = new USER();
            user.ID = CommonMethod.GetID();
            user.PASSWORD = frm.PSW;
            user.USERNAME = frm.UserName;
            user.UNIT = frm.UNIT;
            user.ROLETYPE = 1;
            BaseDA.Insert<USER>(user);
            RefreshGridView();
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            Action<string, string> act = (name, psw) => BaseDA.Delete("USER", name);
            int k = GetSelectUserCount(act);
            RefreshGridView();
        }

        private int GetSelectUserCount(Action<string, string> act)
        {
            //多次连接数据库，大数据时性能会损耗
            int count = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCheckBoxCell cb = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (cb == null)
                {
                    continue;
                }
                if (!Convert.ToBoolean(cb.EditingCellFormattedValue))
                    continue;
                count++;
                string name = dataGridView1.Rows[i].Cells[2].Value.ToString();
                act(name, dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            return count;
        }

        private void btnNewPW_Click(object sender, EventArgs e)
        {
            Action<string, string> act = (name, psw) => { ;};
            int k = GetSelectUserCount(act);
            if (k == 0)
            {
                CommonMethod.OutLog("没有选中用户");
                return;
            }
            FrmChangePWByAdmin frm = new FrmChangePWByAdmin();
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            act = (name,psw) =>{
                USER user = BaseDA.Retrive<USER>(name);
                user.PASSWORD = frm.NewPW;
                BaseDA.Update<USER>(user);
            };
            k = GetSelectUserCount(act);
            RefreshGridView();
            CommonMethod.OutLog("修改成功");
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        private void RefreshGridView()
        {
            QueryCollection qc = new QueryCollection();
            qc.AddQueryParam("ROLETYPE", 1);
            IList<USER> lst = BaseDA.QueryForList<USER>(CommonMethod.PrepareQuery(qc.QueryParams));
            dataGridView1.DataSource = lst;
            CommonMethod.ChangeHead(dataGridView1);
        }


    }
}
