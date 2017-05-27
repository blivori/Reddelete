using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedditSharp;
using System.Security.Authentication;
using RedditSharp.Things;
using System.IO;
using Reddelete2;

namespace Reddelete2
{
    public partial class Main : Form
    {
        Functions f = new Functions();

        public Main()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var r = f.Login(txtUsername.Text,txtPassword.Text);

            if (r == null)
            {
                txtConsole.AppendText("[Login failure]");
                txtConsole.AppendText(Environment.NewLine);
            }
            else
            {
                txtConsole.AppendText("[Logged in as: " + r.User.Name + "]");
                txtConsole.AppendText(Environment.NewLine);
            }
            
        }

        private void tblPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool includePosts = false;
            bool includeComments = false;
            bool overwriteComments = false;
            bool overwritePosts = false;

            if (clbOptions.GetItemCheckState(0).ToString() == "Checked")
                includePosts = true;

            if (clbOptions.GetItemCheckState(1).ToString() == "Checked")
                includeComments = true;

            if (clbOptions.GetItemCheckState(2).ToString() == "Checked")
                overwriteComments = true;

            if (clbOptions.GetItemCheckState(4).ToString() == "Checked")
                overwritePosts = true;

            txtConsole.AppendText("Delete Posts: " + includePosts);
            txtConsole.AppendText(Environment.NewLine);
            txtConsole.AppendText("Delete Comments: " + includeComments);
            txtConsole.AppendText(Environment.NewLine);
            txtConsole.AppendText("Overwrite Comments: " + overwriteComments);
            txtConsole.AppendText(Environment.NewLine);
            txtConsole.AppendText("Overwrite Posts: " + overwritePosts);
            txtConsole.AppendText(Environment.NewLine);

            f.DeleteAll(includeComments, includePosts, overwriteComments, overwritePosts);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reddelete2.Dictionary dForm = new Reddelete2.Dictionary();
            dForm.Show();
        }
    }
    }

