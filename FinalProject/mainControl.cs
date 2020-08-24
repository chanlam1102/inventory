using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
namespace FinalProject
{
    public partial class mainControl : UserControl
    {
        PrjDAO db;
        string user;
        public mainControl(string username)
        {
            user = username;
            InitializeComponent();
            label1.Text = "Hello " + username ;
            db = new PrjDAO();
            dataGridView1.DataSource = db.getProducts();
        }

        private void mainControl_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            AddCategoryForm a = new AddCategoryForm();
            a.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct a = new AddProduct();
            a.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.getProducts();
            dataGridView1.Refresh();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Input input = new Input(user);
            input.Show();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            OutputScreen o = new OutputScreen(user);
            o.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
        }
    }
}
