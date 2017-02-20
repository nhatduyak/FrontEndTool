using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC_Tool.HelpFile;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TPMessageBox;

namespace SGC_Tool.FrmDonDatHang
{
    public class CTLDonDatHang
    {
        public static DataTable GetDonDatHang(string HoTen, string DT, string DC, bool isdate, DateTime From, DateTime To)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLHelper sqlHelper = new SQLHelper();
                string where = "";
                if (HoTen != string.Empty)
                {
                    where += " and ddh.HoTen like '%" + HoTen + "%' ";
                }
                if (DT != string.Empty)
                {
                    where += " and ddh.DienThoai like '%" + DT + "%' ";
                }
                if (DC != string.Empty)
                {
                    where += " and ddh.DiaChi like '%" + DC + "%'";
                }
                if (isdate)
                {
                    where += " and ddh.NgayTao between @tungay and @denngay";
                    sqlHelper.AddParameterToSQLCommand("@tungay", SqlDbType.DateTime);
                    sqlHelper.AddParameterToSQLCommand("@denngay", SqlDbType.DateTime);
                    sqlHelper.SetSQLCommandParameterValue("@tungay",new DateTime(From.Year,From.Month,From.Day,0,0,0) );
                    sqlHelper.SetSQLCommandParameterValue("@denngay", new DateTime(To.Year, To.Month, To.Day, 23, 59, 59));
                }
                string sql = string.Format(@"SELECT ddh.ID,
                                                       ddh.HoTen,
                                                       ddh.DienThoai,
                                                       ddh.DiaChi,
                                                       ddh.SoLuong,
                                                       ddh.ThanhTien,
                                                       ddh.NgayTao,
                                                       ddh.GhiChu
                                                FROM   [" + Config._DBNameFrontEnd + @"].dbo.DonDatHang ddh
                                                where 1=1       
                                                    {0}", where);
                dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("GetDonDatHang ", ex.Message);
                return null;
                throw;
            }
        }
      
        public static DataTable SearchCTDDH(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"SELECT cdh.ID,
                                                   cdh.SKU,
                                                   cdh.IDDonDatHang,
                                                   cdh.UPC,
                                                   cdh.TenSP,
                                                   cdh.SoLuong,
                                                   cdh.GiaGoc,
                                                   cdh.ThanhTien,
                                                   cdh.GiaKM,
                                                   cdh.GhiChu
                                            FROM   [" + Config._DBNameFrontEnd + @"].dbo.CTDonDatHang cdh
		                                            INNER JOIN [" + Config._DBNameFrontEnd + @"].dbo.DonDatHang ddh
		                                            ON ddh.ID=cdh.IDDonDatHang
                                            WHERE cdh.IDDonDatHang= '{0}'", id);
                dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("SearchCTDDH where ID ", ex.Message);
                return null;
                throw;
            }
        }
        public static bool InsertCTDDH(EntityCTDonDatHang ct)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"INSERT INTO [" + Config._DBNameFrontEnd + @"].dbo.CTDonDatHang
                                                                (
	                                                                ID,
	                                                                IDDonDatHang,
	                                                                SKU,
	                                                                UPC,
	                                                                TenSP,
	                                                                SoLuong,
	                                                                GiaGoc,
	                                                                ThanhTien,
	                                                                GiaKM,
	                                                                GhiChu
                                                                )
                                                                VALUES
                                                                (
	                                                                '{0}'/* ID	*/,
	                                                                '{1}'/* IDDonDatHang	*/,
	                                                                '{2}'/* SKU	*/,
	                                                                '{3}'/* UPC	*/,
	                                                                '{4}'/* TenSP	*/,
	                                                                {5}/* SoLuong	*/,
	                                                                {6}/* GiaGoc	*/,
	                                                                {7}/* ThanhTien	*/,
	                                                                {8}/* GiaKM	*/,
	                                                                '{9}'/* GhiChu	*/
                                                                )", ct.ID,
                                                                  ct.IDDonDatHang,
                                                                  ct.SKU,
                                                                  ct.UPC,
                                                                  ct.TenSP,
                                                                  ct.SoLuong,
                                                                  ct.GiaGoc,
                                                                  ct.ThanTien,
                                                                  ct.GiaKM,
                                                                  ct.GhiChu);
                sqlHelper.GetExecuteNonQueryByCommand(sql);
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("InsertCTDDH ", ex.Message);
                return false;
                throw;
            }
        }
        public static bool InsertDonDatHang(EntityDonDatHang dh,DataTable ctdh)
        {
            SQLHelper sqlHelper = new SQLHelper();
            decimal soluong = 0;
            decimal thanhtien = 0;
            try
            {
                sqlHelper.BeginTransaction("InsertDDH");
                string sql = string.Format(@"
                                                    INSERT INTO [" + Config._DBNameFrontEnd + @"].dbo.DonDatHang
                                                    (
	                                                    ID,
	                                                    HoTen,
	                                                    DienThoai,
	                                                    DiaChi,
	                                                    SoLuong,
	                                                    ThanhTien,
	                                                    NgayTao,
	                                                    GhiChu
                                                    )
                                                    VALUES
                                                    (
	                                                    '{0}'/* ID	*/,
	                                                    '{1}'/* HoTen	*/,
	                                                    '{2}'/* DienThoai	*/,
	                                                    '{3}'/* DiaChi	*/,
	                                                    {4}/* SoLuong	*/,
	                                                    {5}/* ThanhTien	*/,
	                                                    @ngaytao/* NgayTao	*/,
	                                                    '{6}'/* GhiChu	*/
                                                    )", dh.ID,
                                                      dh.HoTen,
                                                      dh.DT,
                                                      dh.DiaChi,
                                                      dh.SoLuong,
                                                      dh.ThanTien,
                                                      dh.GhiChu);
                sqlHelper.AddParameterToSQLCommand("@ngaytao", SqlDbType.DateTime);
                //sqlHelper.AddParameterToSQLCommand("@image", SqlDbType.Image);
                sqlHelper.SetSQLCommandParameterValue("@ngaytao", dh.NgayTao);
                //sqlHelper.SetSQLCommandParameterValue("@image", a.Image);
                bool kq = sqlHelper.GetExecuteNonQueryByCommand(sql)>0;
                if (!kq)
                {
                    InfoMessage.HienThi("Lưu đơn hàng không thành công!", "Lưu đơn đặt hàng", "Thong Bao",
                                        HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    return false;
                }
                foreach (DataRow row in ctdh.Rows)
                {
                    EntityCTDonDatHang ct=new EntityCTDonDatHang();
                    ct.ID = Guid.NewGuid().ToString();
                    ct.IDDonDatHang = dh.ID;
                    ct.SKU = row["SKU"].ToString();
                    ct.UPC = row["UPC"].ToString();
                    ct.GhiChu = (""+row["GhiChu"]).ToString();
                    ct.TenSP = row["Description"].ToString();
                    ct.SoLuong = Convert.ToDecimal(row["SoLuong"]);
                    ct.GiaGoc = Convert.ToDecimal(row["GiaGoc"]);
                    ct.GiaKM = Convert.ToDecimal("0"+row["GiaKM"]);
                    ct.ThanTien = Convert.ToDecimal(row["ThanhTien"]);
                    kq &= InsertCTDDH(ct);
                    soluong += ct.SoLuong;
                    thanhtien += ct.ThanTien;
                }
               
                //kq &= UpdateDonDatHang(dh.ID, soluong, thanhtien);
                if (!kq)
                {
                    InfoMessage.HienThi("Lưu đơn hàng không thành công!", "Lưu đơn đặt hàng", "Thong Bao",
                                      HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    return false;
                }
                sqlHelper.Commit();
                InfoMessage.HienThi("Lưu đơn hàng thành công!!!", "Lưu đơn đặt hàng", "Thong Bao",
                                    HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                return true;
            }
            catch (Exception ex)
            {
                sqlHelper.Rollback("InsertDDH");
                InfoMessage.HienThi("Lưu đơn hàng không thành công!", "Lưu đơn đặt hàng", "Thong Bao",
                                        HinhAnhThongBao.LOI, NutThongBao.DONGY);
                CTLError.WriteError("InsertDonDatHang ", ex.Message);
                return false;
                throw;
            }
        }
        public static bool UpdateDonDatHang(string id,decimal soluong,decimal thanhtien)
        {
            try
            {

                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"
                                                    UPDATE [" + Config._DBNameFrontEnd + @"].dbo.DonDatHang
                                                    SET
	                                                    SoLuong = {1},
	                                                    ThanhTien = {2}
                                                    WHERE id='{0}'", id,
                                                                soluong,
                                                                thanhtien);
               
                int kq = sqlHelper.GetExecuteNonQueryByCommand(sql);
                if (kq <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("UpdateDonDatHang ", ex.Message);
                return false;
                throw;
            }
        }
        public void CreateTableCTDonDatHang()
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"IF (Not EXISTS (SELECT * FROM [" + Config._DBNameFrontEnd + @"].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'))
                                                        BEGIN                    
                                                        CREATE TABLE [" + Config._DBNameFrontEnd + @"].dbo.CTDonDatHang (                                                          
                                                          [ID] [nvarchar](36) NULL,
	                                                        [IDDonDatHang] [nvarchar](36) NULL,
	                                                        [SKU] [varchar](10) NULL,
	                                                        [UPC] [varchar](20) NULL,
	                                                        [TenSP] [nvarchar](255) NULL,
	                                                        [SoLuong] [decimal](19, 2) NULL,
	                                                        [GiaGoc] [decimal](19, 2) NULL,
	                                                        [ThanhTien] [decimal](19, 2) NULL,
	                                                        [GiaKM] [decimal](19, 2) NULL,
	                                                        [GhiChu] [nvarchar](255) NULL
                                                        ); END", "CTDonDatHang");
                int resl = sqlHelper.GetExecuteNonQueryByCommand(sql);
                return;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmDonDatHang CreateTableCTDonDatHang ", exception.Message);
                return;
                throw;
            }
        }
        public void CreateTableDonDatHang()
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"IF (Not EXISTS (SELECT * FROM [" + Config._DBNameFrontEnd + @"].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'))
                                                        BEGIN                    
                                                        CREATE TABLE [" + Config._DBNameFrontEnd + @"].dbo.DonDatHang (                                                          
                                                        [ID] [nvarchar](36) NOT NULL,
	                                                    [HoTen] [nvarchar](255) NULL,
	                                                    [DienThoai] [nvarchar](255) NULL,
	                                                    [DiaChi] [nvarchar](255) NULL,
	                                                    [SoLuong] [decimal](19, 2) NULL,
	                                                    [ThanhTien] [decimal](19, 2) NULL,
	                                                    [NgayTao] [datetime] NULL,
	                                                    [GhiChu] [nvarchar](255) NULL,
                                                    
                                                        ); END", "DonDatHang");
                int resl = sqlHelper.GetExecuteNonQueryByCommand(sql);
                return;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmDonDathang CreateTableDonDatHang ", exception.Message);
                return;
                throw;
            }
        }
    }
}
