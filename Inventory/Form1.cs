using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {

        private String _ProductName;
        private String _Category;
        private String _MfgDate;
        private String _ExpDate;
        private String _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;



        public frmAddProduct()
        {

            showProductList = new BindingSource();


            InitializeComponent();
        }


        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {

                }


            }
            catch (StringFormatException ex)
            {
                Console.WriteLine(ex.Message);

            }
            return name;
        }

        public int Quantity(string qty)
        {
            try
            {
              
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {

                }
            }
            
            catch (NumberFormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Convert.ToInt32(qty);

            }
        

        public double SellingPrice(string price)
        {
            try {
                if(!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {


                }
            }

            catch (StringFormatException num)
            {
                Console.WriteLine(num.Message);
                
            }
            return Convert.ToDouble(price);

        }
    
           


        class NumberFormatException : Exception
        {
            public NumberFormatException(int num) : base(String.Format("Invalid Input", num))
            {
                
            }
        }

        class StringFormatException : Exception
        {
            public StringFormatException(string name) : base(String.Format("Invalid Input", name))
            {
                
            }
        }

        class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(int num1) : base(String.Format("Invalid Input", num1))
            {
            }
        }




        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };
            for (int i = 0; i < 8; i++)
            {
                cbCategory.Items.Add(ListOfProductCategory[i].ToString());
            }



        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description)); gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; gridViewProductList.DataSource = showProductList;

        }

    }
}
