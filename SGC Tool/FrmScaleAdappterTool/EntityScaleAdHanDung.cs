using System;
using System.Collections.Generic;
using System.Text;

namespace SGC_Tool.FrmScaleAdappterTool
{
    class EntityScaleAdHanDung
    {
        private string mSKU;
        private int mHanDung;
        private string mNode;

        public string SKU
        {
            get { return mSKU; }
            set { mSKU = value; }
        }
        public int HanDung
        {
            get { return mHanDung; }
            set { mHanDung = value; }
        }
        public string Node
        {
            get { return mNode; }
            set { mNode = value; }
        }
    }
}
