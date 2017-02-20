using System;
using System.Data;
using System.Windows.Forms;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu.ControlEntity;

namespace SGC_Tool
{
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
            IsOk = false;
            txtUserName.Focus();
        }

        public bool IsOk;
        public string MaNV;
        public string MaST;
        public string ID;
        public string TenNV;
        public bool _isfirt = true;
        //public string _IDNhanVien;
        private void ckHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(ckHienMatKhau.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
            }
        }

        #region delegate

        // khai báo 1 hàm delegate
        public delegate void LoadFormImg();
        // khai báo 1 kiểu hàm delegate
        public LoadFormImg Loadf;      

        #endregion


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            try
            {
                string sqlString = string.Format(@"SELECT nv.*,st.TenSieuThi
                                                FROM   NhanVien nv
                                                       LEFT JOIN SieuThi st
                                                            ON  st.MaST = nv.MaST
                                                WHERE  nv.TenDangNhap = '{0}'", userName);
                DataTable kq = ConnectDb.ExcuteQuery(sqlString);
                if (kq.Rows.Count == 0)
                {
                    FrmMessage frm = new FrmMessage("Tên đăng nhập không tồn tại.");
                    frm.ShowDialog();
                    IsOk = false;
                    return;
                }

                byte[] pass = (byte[])(kq.Rows[0]["MatKhau"]);
                string password = Ctl_LogIn.DEF(pass);
                if (txtPassword.Text != password)
                {
                    FrmMessage frm = new FrmMessage("Mật khẩu không chính xác");
                    frm.ShowDialog();
                    IsOk = false;
                    return;
                }

                string sqlCauHinh = string.Format(@"select SieuThi From CauHinh");
                object MaST_CauHinh = ConnectDb.ExcuteScalar(sqlCauHinh);
                if (MaST_CauHinh is DBNull || MaST_CauHinh == null)
                {
                    FrmMessage frm = new FrmMessage("Không có cấu hình siêu thị");
                    frm.ShowDialog();
                    return;
                }
                if (Convert.ToString(MaST_CauHinh).Equals(kq.Rows[0]["MaST"]) == false)
                {
                    FrmMessage frm = new FrmMessage("Vui lòng dùng thông tin của siêu thị " + MaST_CauHinh + " để đăng nhập");
                    frm.ShowDialog();
                    return;
                }
                IsOk = true;
                MaNV = userName;
                MaST = Convert.ToString(kq.Rows[0]["TenSieuThi"]);
                ID = Convert.ToString(kq.Rows[0]["MaNV"]);
                TenNV = Convert.ToString(kq.Rows[0]["TenNV"]);
                this.Visible = false;
                if (Loadf != null)
                {
                    Loadf();
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("LogIn_Click ", ex.Message);
                return;
                throw;
            }
        }


        private void FrmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(btnLogIn, null);
            }
        }

    }
}
