using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SieuThiBHX
{
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }
        public Image AnhSanPham
        {
            get
            {
                return imgProduct.Image;
            }
            set
            {
                imgProduct.Image = value;
            }
        }
        public string TenSanPham
        {
            get { return lbTenSanPham.Text; }
            set { lbTenSanPham.Text = value; }

        }
        public string SoLuong
        {
            get { return amountItem.Text; }
            set { amountItem.Text = value; }

        }
        public string Gia
        {
            get { return priceItem.Text; }
            set { priceItem.Text = value; }
        }
        public Guna2PictureBox pbSanPham
        {
            get { return imgProduct; }
            set { imgProduct = value; }
        }
        public Label lbTenSanPham
        {
            get { return lbnameSanPham; }
            set { lbnameSanPham = value; }
        }
        public Label lbGia
        {
            get { return priceItem; }
            set { priceItem = value; }
        }
        public Label lbSoLuong
        {
            get { return amountItem; }
            set { amountItem = value; }
        }
    }
}
