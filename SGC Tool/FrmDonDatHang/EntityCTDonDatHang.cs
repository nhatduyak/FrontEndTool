using System;
using System.Collections.Generic;
using System.Text;

namespace SGC_Tool.FrmDonDatHang
{
    public class EntityCTDonDatHang
    {
        public EntityCTDonDatHang()
        {

        }
        private string mID;
        private string mIDDonDatHang;
        private string mSKU;
        private string mUPC;
        private string mTenSP;
        
        private decimal mSoLuong;
        private decimal mThanhTien;
        private decimal mGiaGoc;
        private decimal mGiaKM;
        private string mGhiChu;
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string IDDonDatHang
        {
            get { return mIDDonDatHang; }
            set { mIDDonDatHang = value; }
        }
        public string SKU
        {
            get { return mSKU; }
            set { mSKU = value; }
        }
        public string UPC
        {
            get { return mUPC; }
            set { mUPC = value; }
        }
        public string TenSP
        {
            get { return mTenSP; }
            set { mTenSP = value; }
        }
        public decimal SoLuong
        {
            get { return mSoLuong; }
            set { mSoLuong = value; }
        }
        public decimal GiaGoc
        {
            get { return mGiaGoc; }
            set { mGiaGoc = value; }
        }
        public decimal GiaKM
        {
            get { return mGiaKM; }
            set { mGiaKM = value; }
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
