using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLibrary.WinControls;
using WeifenLuo.WinFormsUI.Docking;

namespace ProjectElu
{
    public partial class FormMain : Form
    {
        FrmMenu _frmMenu = new FrmMenu();
        public FormMain()
        {
            InitializeComponent();
            _frmMenu.ItemClickEvent += _frmMenu_ItemClickEvent;
            _frmMenu.Show(this.dockPanel1);
            _frmMenu.DockTo(this.dockPanel1, DockStyle.Left);
            _frmMenu.CloseButton = false;
            DeviceManager();
            labCurrent.Text = "     " + CommonMethod.g_User.USERNAME;

        }

        void _frmMenu_ItemClickEvent(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                case "设备管理":
                    DeviceManager();
                    break;
                case "报废管理":
                    ReimburseManager();
                    break;
                case "用户管理":
                    UserManager();
                    break;
                default:
                    break;
            }
        }

        private void ReimburseManager()
        {
            FrmManagerReimburse frm = new FrmManagerReimburse();
            AddDockFrm(frm);

        }

        private void AddDockFrm(DockContent frm)
        {
            foreach (IDockContent content in dockPanel1.Documents)
            {
                if (content.DockHandler.TabText == frm.Text)
                {
                    content.DockHandler.Activate();
                    return;
                }
            }
            frm.Show(this.dockPanel1);
            //frm.DockTo(this.dockPanel1, DockStyle.Fill);
        }

        private void UserManager()
        {
            FrmManagerUser frm = new FrmManagerUser();
            AddDockFrm(frm);
        }

        private void DeviceManager()
        {
            FrmManagerDevice frm = new FrmManagerDevice();
            AddDockFrm(frm);
        }

        private void tsbQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tslChangePSW_Click(object sender, EventArgs e)
        {
            FrmChangePW frm = new FrmChangePW(CommonMethod.g_User.USERNAME, CommonMethod.g_User.PASSWORD);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            CommonMethod.g_User.PASSWORD = frm.NewPW;
            BaseDA.Update<USER>(CommonMethod.g_User);
            CommonMethod.OutLog("修改密码成功");
        }

        private void btnChangePSW_Click(object sender, EventArgs e)
        {
            FrmChangePW frm = new FrmChangePW(CommonMethod.g_User.USERNAME, CommonMethod.g_User.PASSWORD);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            CommonMethod.g_User.PASSWORD = frm.NewPW;
            BaseDA.Update<USER>(CommonMethod.g_User);
            CommonMethod.OutLog("修改密码成功");
        }

        private void labExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                return;
            this.Close();
        }

        private void labChangePaW_Click(object sender, EventArgs e)
        {
            FrmChangePW frm = new FrmChangePW(CommonMethod.g_User.USERNAME, CommonMethod.g_User.PASSWORD);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            CommonMethod.g_User.PASSWORD = frm.NewPW;
            BaseDA.Update<USER>(CommonMethod.g_User);
            CommonMethod.OutLog("修改密码成功");
        }
    }
}
