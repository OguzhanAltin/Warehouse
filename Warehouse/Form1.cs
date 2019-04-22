using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.DAL.ORM.Context;
using Warehouse.DAL.ORM.Entity;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();

        public void Cleaner()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        public void BringProductList()
        {
            dataGridView1.DataSource = db.Products.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated).ToList();
        }

        public void BringCategoryList()
        {
            dataGridView1.DataSource = db.Categories.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated).ToList();
        }

        public void BringSupplierList()
        {
            dataGridView1.DataSource = db.Suppliers.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated).ToList();
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            BringProductList();
            Cleaner();
        }

        private void btnListCategory_Click(object sender, EventArgs e)
        {
            BringCategoryList();
            Cleaner();
        }

        private void btnListSupplier_Click(object sender, EventArgs e)
        {
            BringSupplierList();
            Cleaner();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            Product product = new Product();
            product.ProductName = txtAddProductName.Text;
            product.ProductDescription = txtAddProductDescription.Text;
            product.UnitPrice = decimal.Parse(txtAddPrice.Text);
            product.UnitsInStock = short.Parse(txtAddProductStock.Text);

            db.Products.Add(product);
            db.SaveChanges();

            BringProductList();
            Cleaner();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {  
                Category cat = new Category();
                cat.CategoryName = txtAddCategoryName.Text;
                cat.CategoryDescription = txtAddCategoryDescription.Text;

                db.Categories.Add(cat);
                db.SaveChanges();

                BringCategoryList();
                Cleaner();           
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.CompanyName = txtAddSupplierCompanyName.Text;
            sup.ContactName = txtAddSupplierContactName.Text;
            sup.Country = txtAddSupplierCountry.Text;
            sup.PhoneNumber = maskedTxtAddPhone.Text;

            db.Suppliers.Add(sup);
            db.SaveChanges();

            BringSupplierList();
            Cleaner();
        }

        int id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1 != null)
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                txtUpdateProductName.Text = dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();
                txtUpdateProductDescription.Text = dataGridView1.CurrentRow.Cells["ProductDescription"].Value.ToString();
                txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells["UnitPrice"].Value.ToString();
                txtUpdateStock.Text = dataGridView1.CurrentRow.Cells["UnitInStock"].Value.ToString();
                txtUpdateCategoryName.Text = dataGridView1.CurrentRow.Cells["CategoryName"].Value.ToString();
                txtUpdateCategoryDescription.Text = dataGridView1.CurrentRow.Cells["CategoryDescription"].Value.ToString();
                txtUpdateSupplierCompanyName.Text = dataGridView1.CurrentRow.Cells["CompanyName"].Value.ToString();
                txtUpdateContactName.Text = dataGridView1.CurrentRow.Cells["ContactName"].Value.ToString();
                txtUpdateSupplierCountry.Text = dataGridView1.CurrentRow.Cells["Country"].Value.ToString();
                maskedTxtUpdatePhone.Text = dataGridView1.CurrentRow.Cells["PhoneNumber"].Value.ToString();
                txtDelete.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            Product product = db.Products.FirstOrDefault(x => x.ID == id);
            product.ProductName = txtUpdateProductName.Text;
            product.ProductDescription = txtUpdateProductDescription.Text;
            product.UnitPrice = decimal.Parse(txtUpdatePrice.Text);
            product.UnitsInStock = short.Parse(txtUpdateStock.Text);

            product.Status = DAL.ORM.Enum.Status.Updated;

            db.SaveChanges();

            BringProductList();
            Cleaner();

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            Category cat = db.Categories.FirstOrDefault(x => x.ID == id);
            cat.CategoryName = txtUpdateCategoryName.Text;
            cat.CategoryDescription = txtUpdateCategoryDescription.Text;

            cat.Status = DAL.ORM.Enum.Status.Updated;

            db.SaveChanges();

            BringCategoryList();
            Cleaner();
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            Supplier sup = db.Suppliers.FirstOrDefault(x => x.ID == id);
            sup.CompanyName = txtUpdateSupplierCompanyName.Text;
            sup.ContactName = txtUpdateContactName.Text;
            sup.Country = txtUpdateSupplierCountry.Text;
            sup.PhoneNumber = maskedTxtUpdatePhone.Text;

             sup.Status = DAL.ORM.Enum.Status.Updated;

            db.SaveChanges();

            BringSupplierList();
            Cleaner();

            
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product pro = db.Products.FirstOrDefault(x => x.ID == id);


            pro.Status = DAL.ORM.Enum.Status.Deleted;

            db.SaveChanges();

            BringProductList();

            Cleaner();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            Category cat = db.Categories.FirstOrDefault(x => x.ID == id);

            cat.CategoryName = txtUpdateCategoryName.Text;
            cat.CategoryDescription = txtUpdateCategoryDescription.Text;
            cat.Status = DAL.ORM.Enum.Status.Deleted;

            db.SaveChanges();

            BringCategoryList();

            Cleaner();
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            Supplier sup = db.Suppliers.FirstOrDefault(x => x.ID == id);

            sup.CompanyName = txtUpdateSupplierCompanyName.Text;
            sup.ContactName = txtUpdateContactName.Text;
            sup.Country = txtUpdateSupplierCountry.Text;
            sup.PhoneNumber = maskedTxtUpdatePhone.Text;
            sup.Status = DAL.ORM.Enum.Status.Deleted;

              db.SaveChanges();

            BringSupplierList();

              Cleaner();

        }

    }
}
