using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Input : Form
    {
        string username;
        List<ProductControl> ps;
        PrjDAO db;
        public Input(string username)
        {
            db = new PrjDAO();
            ps = new List<ProductControl>();
            this.username = username;
            InitializeComponent();
            ProductControl p = new ProductControl(username);
            ps.Add(p);
            flowLayoutPanel1.Controls.Add(p);
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            ProductControl p = new ProductControl(username);
            ps.Add(p);
            flowLayoutPanel1.Controls.Add(p);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            List < Entity.Input > inputs = new List<Entity.Input>();
            foreach(ProductControl p in ps)
            {
                inputs.Add(p.GetInput());
            }

            foreach(Entity.Input input in inputs)
            {
                db.insertInput(input.date,input.pid,input.quantity,input.user);
                db.InputProduct(input.quantity, input.pid);
            }
            MessageBox.Show("Input successfully");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
