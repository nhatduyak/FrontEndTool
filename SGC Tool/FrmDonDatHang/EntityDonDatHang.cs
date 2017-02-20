using System;
using System.Collections.Generic;
using System.Text;

namespace SGC_Tool.FrmDonDatHang
{
    public class EntityDonDatHang
    {
        public EntityDonDatHang()
        {

        }
        private string mID;
        private string mHoTen;
        private string mDT;
        private string mDiaChi;
        private DateTime mNgayTao;
        private decimal mSoLuong;
        private decimal mThanhTien;
        private string mGhiChu;
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string HoTen
        {
            get { return mHoTen; }
            set { mHoTen = value; }
        }
        public string DT
        {
            get { return mDT; }
            set { mDT = value; }
        }
        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        public DateTime NgayTao
        {
            get { return mNgayTao; }
            set { mNgayTao = value; }
        }
        public decimal SoLuong
        {
            get { return mSoLuong; }
            set { mSoLuong = value; }
        }
        public decimal ThanTien
        {
            get { return mThanhTien; }
            set { mThanhTien = value; }
        }
        public string GhiChu
        {
            get { return mGhiChu; }
            set { mGhiChu = value; }
        }
    }
}
