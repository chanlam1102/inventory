using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using Entity;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        PrjDAO db;
        
        public Form1()
        {
            InitializeComponent();
            db = new PrjDAO();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<User> u = db.GetUsers();
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            foreach(User u1 in u)
            {
                if (u1.username.Equals(user) && u1.password.Equals(pass))
                {
                    pnContent.Controls.Clear();
                    pnContent.Controls.Add(new mainControl(user));
                }
                else MessageBox.Show("Login Failed");
            }
        }
    }
}
