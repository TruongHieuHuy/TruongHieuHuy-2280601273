using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Dethi_02
{
    public partial class frmSanpham : Form
    {
        private string connectionString;

        public frmSanpham()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(cbLoaiSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewSanPham.Rows.Add(
                txtMaSP.Text,                    
                txtTenSP.Text,                  
                dtpNgayNhap.Value.ToShortDateString(), 
                cbLoaiSP.Text                     
            );

            txtMaSP.Clear();
            txtTenSP.Clear();
            cbLoaiSP.SelectedIndex = -1;
            dtpNgayNhap.Value = DateTime.Now;

            txtMaSP.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Model1 context = new Model1();

            List<Sanpham> students = context.Sanphams.ToList();
            dataGridViewSanPham.DataSource = students;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                string maSP = txtMaSP.Text;

                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("chọn sản phẩm cần sửa!");
                    return;
                }

                Model1 context = new Model1();
                var sanpham = context.Sanphams.FirstOrDefault(sp => sp.SPCode == maSP);

                if (sanpham != null)
                {
                    sanpham.SPName = txtTenSP.Text;
                    sanpham.DateTime = dtpNgayNhap.Value;
                    sanpham.TypeCode = cbLoaiSP.SelectedValue.ToString();
                    context.SaveChanges();
                    LoaddataGridViewSanPham();
                    MessageBox.Show("sửa thành công.");
                }
                else
                {
                    MessageBox.Show("không tồn tại.");
                }
        }
        private void LoaddataGridViewSanPham()
        {
            using (Model1 context = new Model1())
            {
                var products = context.Sanphams.ToList();

                dataGridViewSanPham.Items.Clear();
                foreach (var sp in products)
                {
                    ListViewItem item = new ListViewItem(sp.SPCode);
                    item.SubItems.Add(sp.SPName);
                    item.SubItems.Add(sp.DateTime.ToShortDateString() ?? "");
                    item.SubItems.Add(sp.TypeCode);
                    dataGridViewSanPham.Items.Add(item);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewSanPham.SelectedRows)
                {
                    // Xóa dòng được chọn
                    dataGridViewSanPham.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
           
        }
    }
}
