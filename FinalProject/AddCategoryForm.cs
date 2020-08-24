using DAO;
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
    public partial class AddCategoryForm : Form
    {
        PrjDAO db;
        List<int> t;
        public AddCategoryForm()
        {
            
            db = new PrjDAO();
            InitializeComponent();
            dataGridView1.DataSource = db.getCategory();
            dataGridView1.AutoGenerateColumns = false;
            DataTable tb = db.getCategory();
            t = new List<int>();
            for (int i = 0; i <tb.Rows.Count; i++)
            {
                t.Add(Convert.ToInt32(tb.Rows[i][0]));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Category name can't be blank");
            }
            else
            {
                int parsedValue;
                if (txtID.Text.Trim().Equals(""))
                {
                    MessageBox.Show("ID can not be blank");
                    return;
                }

                else if (!int.TryParse(txtID.Text, out parsedValue))
                {
                    MessageBox.Show("This is a number only field");
                    return;
                }
                else
                {
                    int r = Convert.ToInt32(txtID.Text);
                    foreach (int i in t)
                    {
                        if (r == i)
                        {
                            MessageBox.Show("ID can not duplicate");
                            return;
                        }
                    }
                    db.addCategory(Convert.ToInt32(txtID.Text), txtName.Text);
                    MessageBox.Show("Add successfully");
                    dataGridView1.DataSource = db.getCategory();
                    dataGridView1.Refresh();
                
            }
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Are you sure ?", "Notice", MessageBoxButtons.YesNo);
           if(result == DialogResult.Yes)
            {
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    DataTable tb = db.getCategory();
                    db.deleteCategory(Convert.ToInt32(tb.Rows[rowindex][0]));
            }
            dataGridView1.DataSource = db.getCategory();
            dataGridView1.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
