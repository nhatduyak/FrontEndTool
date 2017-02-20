using System.Text;
using SGC_Tool.FrmScaleAdappterTool;
using TOOLChuyenDuLieu;

namespace TOOLChuyenDuLieu
{
    public class PLMenu
    {
        public static string CreateMenu()
        {
            StringBuilder str = new StringBuilder("");
            GenID G = new GenID();

            #region Scale adapper tool
            string GThongtin = G.NewGroup();
            str.Append(MenuBuilder.CreateRootItem(GThongtin, "Scale adapper tool", ""));
            //MenuBuilder.CreateItem(str, typeof(FrmScaleAddTool).FullName, "Scale adapper tool", GThongtin, true, typeof(FrmScaleAddTool).FullName, true, false, "Image\\DM_KhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(FrmScaleAddTool).FullName, "Load data", typeof(DesktopForm).FullName, true, typeof(FrmScaleAddTool).FullName, false, true, "Image\\DM_KhachHang.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmDuyetRSS).FullName, "Tin tổng hợp RSS", GThongtin, true, typeof(frmDuyetRSS).FullName, true, false, "fwBusiness.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmDien_DanQL).FullName, "Diễn đàn", GThongtin, true, typeof(frmDien_DanQL).FullName, true, true, "mnbToChuc.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmBaiViet).FullName, "Tạo bài viết", typeof(frmDien_DanQL).FullName, true, typeof(frmBaiViet).FullName, false, true, "mnbToChuc.png", false, "", "", true);

            //str.Append(frmDanhba.MenuItem(GThongtin, true));

            //MenuBuilder.CreateItem(str, typeof(frmWebsite_QL).FullName, "Danh bạ Website", GThongtin, true, typeof(frmWebsite_QL).FullName, true, false, "mnbHSoUngVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmThemMoi).FullName, "Thêm mới", typeof(frmWebsite_QL).FullName, true, typeof(frmThemMoi).FullName, false, true, "mnbHSoUngVien.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmQLTaiLieu).FullName, "Quản lý tài liệu", GThongtin, true, typeof(frmQLTaiLieu).FullName, true, true, "mnbHSoUngVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmThem_TL).FullName, "Thêm mới", typeof(frmQLTaiLieu).FullName, true, typeof(frmThem_TL).FullName, false, true, "mnbHSoUngVien.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmImageGallery).FullName, "Quản lý ảnh", GThongtin, true, typeof(frmImageGallery).FullName, true, false, "fwBusiness.png", false, "", "", true);

            #endregion
            #region Nghiệp vụ
            string GHangngay = G.NewGroup();
            str.Append(MenuBuilder.CreateRootItem(GHangngay, "Công việc", ""));

            //MenuBuilder.CreateItem(str, typeof(DesktopForm).FullName, "Thời gian làm việc", GHangngay, true, typeof(FrmScaleAddTool).FullName, true, false, "Image\\DM_KhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(FrmScaleAddTool).FullName, "Ghi thời gian", typeof(DesktopForm).FullName, true, typeof(FrmScaleAddTool).FullName, false, true, "Image\\DM_KhachHang.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmTimeRecordQL).FullName, "Nhật ký làm việc", GHangngay, true, typeof(frmTimeRecordQL).FullName, true, false, "mnbToChuc.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmTimeTable).FullName, "Tạo mới", typeof(frmTimeRecordQL).FullName, true, typeof(frmTimeTable).FullName, false, true, "mnsNhanVien.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmQLHoTro).FullName, "Yêu cầu hỗ trợ", GHangngay, true, typeof(frmQLHoTro).FullName, true, true, "mnbCHinhHeThong.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmHotroSupport).FullName, "Tạo mới", typeof(frmQLHoTro).FullName, true, typeof(frmHotroSupport).FullName, false, true, "mnbCHinhHeThong.png", false, "", "", true);

            //str.Append(frmLichlamviec.MenuItem(GHangngay, true));
            //str.Append(frmQLCongviecQL1N.MenuItem(GHangngay, false));
            //MenuBuilder.CreateItem(str, typeof(Congviec).FullName, "Tạo mới", typeof(frmQLCongviecQL1N).FullName, true, typeof(Congviec).FullName, false, false, "mnbToChuc.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmQL_DuAn).FullName, "Quản lý dự án", GHangngay, true, typeof(frmQL_DuAn).FullName, true, true, "mnbHSoUngVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmDuAn_CongViec).FullName, "Thêm mới", typeof(frmQL_DuAn).FullName, true, typeof(frmDuAn_CongViec).FullName, false, true, "mnbHSoUngVien.png", false, "", "", true);

            //MenuBuilder.CreateItem(str, typeof(frmQL_Bug).FullName, "Quản lý bug", GHangngay, true, typeof(frmQL_Bug).FullName, true, false, "mnbHSoUngVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmThemBug).FullName, "Thêm mới", typeof(frmQL_Bug).FullName, true, typeof(frmThemBug).FullName, false, false, "mnbHSoUngVien.png", false, "", "", true);

            //str.Append(frmChamCongNew.MenuItem(GHangngay, true));

            #region Nội bộ            

            #endregion

            #region Kinh doanh
            string GKinhdoanh = G.NewGroup();
            str.Append(MenuBuilder.CreateRootItem(GKinhdoanh, "Kinh doanh", ""));
            MenuBuilder.CreateItem(str, typeof(FrmScaleAddTool).FullName, "Quản trị quan hệ khách hàng", GKinhdoanh, true, typeof(FrmScaleAddTool).FullName, true, false, "Image\\DM_KhachHang.png", false, "", "", true);
            #endregion

            //#region Hành chính
            //string GHanhchinh = G.NewGroup();
            //str.Append(MenuBuilder.CreateRootItem(GHanhchinh, "Hành chính", ""));

            //MenuBuilder.CreateItem(str, typeof(frmHoSoQL).FullName, "Hồ sơ ứng viên", GHanhchinh, true, typeof(frmHoSoQL).FullName, true, false, "mnbHSoUngVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(HoSo).FullName, "Tạo mới", typeof(frmHoSoQL).FullName, true, typeof(HoSo).FullName, false, false, "mnbToChuc.png", false, "", "", true);

            //str.Append(frmPhongVanQL.MenuItem(GHanhchinh, false));
            //str.Append(frmLichLamViecQLN.MenuItem(GHanhchinh, true));
            //#endregion

            //#region Tài chính
            //string GTaichinh = G.NewGroup();
            //str.Append(MenuBuilder.CreateRootItem(GTaichinh, "Tài chính", ""));

            //MenuBuilder.CreateItem(str, typeof(frmDieuChinhLuongQLN).FullName, "Thang bảng lương", GTaichinh, true, typeof(frmDieuChinhLuongQLN).FullName, true, false, "mnbDieuChinhLuong.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmDieuChinhLuong).FullName, "Tạo mới", typeof(frmDieuChinhLuongQLN).FullName, true, typeof(frmDieuChinhLuong).FullName, false, false, "mnbDieuChinhLuong.png", false, "", "", true);

            //str.Append(frmLuongQLNew.MenuItem(GTaichinh, false));

            //MenuBuilder.CreateItem(str, typeof(frmThuChiQL).FullName, "Thu chi", GTaichinh, true, typeof(frmThuChiQL).FullName, true, true, "mnbThuChi.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmPhieuThuChi).FullName, "Tạo mới", typeof(frmThuChiQL).FullName, true, typeof(frmPhieuThuChi).FullName, false, true, "mnbThuChi.png", false, "", "", true);

            //#endregion

            #endregion

            //#region Báo cáo
            //str.Append(MenuBuilder.CreateRootItem("4.0", "Báo cáo", ""));
            //str.Append(MenuBuilder.CreateItem("4.1", "Thông tin ứng viên NC", "4.0", true, "ProtocolVN.Framework.Win.frmBaseReport?param=1.1", true, false, "mnbHSoUngVien.png", false, "", ""));
            //str.Append(MenuBuilder.CreateItem("4.2", "Bảng chấm công NC", "4.0", true, "ProtocolVN.Framework.Win.frmBaseReport?param=1.2", true, true, "mnbChamCong.png", false, "", ""));
            //#endregion

            //#region Hệ thống
            //str.Append(MenuBuilder.CreateRootItem("5.0", "Hệ thống", ""));
            //str.Append(MenuBuilder.CreateItem("5.1", "Tree Quản lý người dùng", "5.0", true, PLPermission.permissionForm,
            //    true, false, "mnbQLyNguoiDung.png", false, "", ""));
            //str.Append(MenuBuilder.CreateItem("5.2", "List Quản lý người dùng", "5.0", true, typeof(frmUserManExt).FullName,
            //    true, false, "mnbQLyNguoiDung.png", false, "", ""));
            //#endregion

            //#region Nhóm DEV
            //string gDev = G.NewGroup();
            //str.Append(MenuBuilder.CreateRootItem(gDev, "Đang phát triển", ""));

            //string gDanhBa = G.NewGroup();
            //str.Append(MenuBuilder.CreateItem(gDanhBa, "Danh bạ", gDev, true, "", true, false, "", false, "", ""));
            //str.Append(frmDanhba.MenuItem(gDanhBa, false));

            //string gBangTheoDoi = G.NewGroup();
            //str.Append(PLTimeSheetMenu.BuildMenu(G, gDev));
            //str.Append(pl.office.form.frmTheoDoi_TT_HL_TVQL.MenuItem(gDev, true));
            //str.Append(MenuBuilder.CreateItem(typeof(frmBangTheoDoiQL).FullName, "Bảng theo dõi", gDev, true, typeof(frmBangTheoDoiQL).FullName, true, false, "", false, "", ""));
            //str.Append(MenuBuilder.CreateItem(G.NewItem(), "Kết quả thực hiện công việc", typeof(frmBangTheoDoiQL).FullName, true, "pl.office.Training.ModDiemTheoDoi.frmQuanLyThucHien", true, false, "mnsPhongBan.png", true, "", ""));
            //str.Append(MenuBuilder.CreateItem("LCV", "Thêm loại công việc", "BTD", true, "pl.office.Training.ModDiemTheoDoi.form.frmLoaiCongViec", true, false, "mnsPhongBan.png", true, "", ""));
            //str.Append(frmChamCongTuDongQL.MenuItem(gDev, true, true));
            //#endregion

            //#region Danh mục
            //str.Append(MenuBuilder.CreateRootItem("1.0", "Danh mục", ""));
            //str.Append(MenuBuilder.CreateItem("1.1", "Tổ chức", "1.0", true, "", true, false, "mnbToChuc.png", false, "", ""));
            //str.Append(DMNhanVien_PO.I.MenuItem(FWFormName.frmCategory, "1.1", false));
            //str.Append(DMFWPhongBan.I.MenuItem(FWFormName.frmCategory, "1.1", false));
            //str.Append(MenuBuilder.CreateItem("1.2", "Tuyển dụng", "1.0", true, "", true, true, "mnbTuyenDung.png", false, "", ""));
            //str.Append(DMDotTuyenDung.I.MenuItem(FWFormName.frmCategory, "1.2", false));
            //str.Append(DMViTriUngTuyen.I.MenuItem(FWFormName.frmCategory, "1.2", false));
            //str.Append(DMTinhTrangHoSo.I.MenuItem(FWFormName.frmCategory, "1.2", false));
            //str.Append(MenuBuilder.CreateItem("1.3", "Chi phí", "1.0", true, "", true, true, "mnbChiPhi.png", false, "", ""));
            //str.Append(DMLoaiChiPhi.I.MenuItem(FWFormName.frmCategory, "1.3", false));
            //str.Append(MenuBuilder.CreateItem("1.4", "Loại yêu cầu", "1.0", true, "", true, true, "mnbChiPhi.png", false, "", ""));
            //str.Append(DMLoaiYeuCau.I.MenuItem(FWFormName.frmCategory, "1.4", false));
            //str.Append(MenuBuilder.CreateItem("1.5", "Tình trạng công việc", "1.0", true, "", true, true, "mnbChiPhi.png", false, "", ""));
            //str.Append(DMTinhTrangCongViec.I.MenuItem(FWFormName.frmCategory, "1.5", false));
            //str.Append(MenuBuilder.CreateItem("1.6", "Nhóm tin tức", "1.0", true, "", true, true, "mnbHSoUngVien.png", false, "", ""));
            //str.Append(DMNhomTinTuc.I.MenuItem(FWFormName.frmCategory, "1.6", false));
            //str.Append(MenuBuilder.CreateItem("1.7", "Loại công việc", "1.0", true, "", true, true, "mnbHSoUngVien.png", false, "", ""));
            //str.Append(DMLoaiCongViec.I.MenuItem(FWFormName.frmCategory, "1.7", true));
            //str.Append(MenuBuilder.CreateItem("1.8", "Nhóm danh bạ", "1.0", true, "", true, true, "mnsNotePad.png", false, "", ""));
            //str.Append(DMNhomDanhBa.I.MenuItem(FWFormName.frmCategory, "1.8", true));
            //str.Append(MenuBuilder.CreateItem("1.9", "Diễn đàn", "1.0", true, "", true, true, "mnbToChuc.png", false, "", ""));
            //str.Append(DMNhomDienDan.I.MenuItem(FWFormName.frmCategory, "1.9", false));
            //str.Append(DMChuyenMuc.I.MenuItem(FWFormName.frmCategory, "1.9", false));
            //str.Append(MenuBuilder.CreateItem("1.10", "Phân loại Website", "1.0", true, "", true, true, "mnbToChuc.png", false, "", ""));
            //str.Append(DMWebsite.I.MenuItem(FWFormName.frmCategory, "1.10", false));
            //str.Append(MenuBuilder.CreateItem("1.11", "Danh mục nghiệp vụ", "1.0", true, "", true, true, "mnbToChuc.png", false, "", ""));
            //str.Append(DMNghiepVu.I.MenuItem(FWFormName.frmCategory, "1.11", false));
            //str.Append(MenuBuilder.CreateItem("1.12", "Danh mục tin RSS", "1.0", true, "", true, true, "mnsNotePad.png", false, "", ""));
            //str.Append(DM_THU_MUC_RSS.I.MenuItem(FWFormName.frmCategory, "1.12", false));
            //str.Append(DM_LIEN_KET_RSS.I.MenuItem(FWFormName.frmCategory, "1.12", false));
            //str.Append(MenuBuilder.CreateItem("1.13", "Danh mục thư mục hình ảnh", "1.0", true, "", true, true, "mnsNotePad.png", false, "", ""));
            //str.Append(DM_TM_HINH_ANH.I.MenuItem(FWFormName.frmCategory, "1.13", false));
            //str.Append(MenuBuilder.CreateItem("1.14", "Danh mục tài liệu", "1.0", true, "", true, true, "mnsNotePad.png", false, "", ""));
            //str.Append(DM_LoaiTaiLieu.I.MenuItem(FWFormName.frmCategory, "1.14", false));
            //#endregion

            return str.ToString();
        }

        public static string CreateRibbonMenu()
        {
            StringBuilder str = new StringBuilder("");
            return str.ToString();
        }
    }
}
