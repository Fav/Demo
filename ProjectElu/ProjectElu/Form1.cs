using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectElu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "admin";
            string pw = CommonMethod.MD5Encrypt("admin");
            USER user = BaseDA.Retrive<USER>(name);
            if (user==null )
            {
                return;
            }
            if (user.USERNAME== name && user.PASSWORD==pw)
            {
                MessageBox.Show("Test");
            }

        }


    }

    public class Response 
    {
        public static void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
