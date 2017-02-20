using System;

namespace TOOLChuyenDuLieu.ControlEntity
{
    class ConvertBarCode
    {
        public string CheckSum(string TxtCode)
        {
            
            // Taïo ra kyù töï CheckSum cho Maõ Haøng Hoaù
            bool Ok = false;
            int[] Kt = new int[13];
            string Temp = null;
            byte i = 0;
            int Chan = 0;
            int Le = 0;
            int KQ = 0;
            Temp = "*";
            Ok = true;

            if (TxtCode.Length != 12)
                Ok = false;
            if (Ok)
            {
                for (i = 0; i <= 11; i++)
                {
                    if (strMid.InStr("0123456789", strMid.Mid(TxtCode, i + 1, 1)) != 0)
                    {
                        Kt[i] = Convert.ToInt32(strMid.Mid(TxtCode, i + 1, 1));
                    }
                    else
                    {
                        Ok = false;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            if (Ok)
            {
                Le = Kt[1] + Kt[3] + Kt[5] + Kt[7] + Kt[9] + Kt[11];
                Le = Le * 3;
                Chan = Kt[0] + Kt[2] + Kt[4] + Kt[6] + Kt[8] + Kt[10];
                KQ = 10 - ((Le + Chan) % 10);
                if (KQ == 10)
                    KQ = 0;
                Temp = (Convert.ToString(KQ)).Trim();
            }
            return TxtCode + Temp;

        }

        public string Rotation(string Chuoi, byte At)
        {
            //Quay chuoi 5 ky so tai vi tri thu At
            string Temp = null;
            string DblChuoi = null;
            byte i = 0;
            Temp = "*";
            if (Chuoi.Length != 5)
                goto Kthuc;
            for (i = 1; i <= 5; i++)
            {
                if (strMid.InStr("0123456789", strMid.Mid(Chuoi, i, 1)) == 0)
                    goto Kthuc;
            }
            DblChuoi = Chuoi.Trim() + Chuoi.Trim();
            Temp = strMid.Mid(DblChuoi, At, 5);
        Kthuc:
            return Temp;
        }

        public string CreaBarCode(string MySTT)
        {
            // Cho ra BarCode tu MyStt
            string Temp = null;
            string Compl = null;
            string FirstTxt = null;
            byte i = 0;
            long ValTest = 0;
            byte MyAt = 0;
            Temp = "*";
            if (MySTT.Length != 7)
                goto Kthuc;
            for (i = 1; i <= 7; i++)
            {
                if (strMid.InStr("0123456789", strMid.Mid(MySTT, i, 1)) == 0)
                    goto Kthuc;
            }
            FirstTxt = strMid.Right(MySTT, 5);
            ValTest = Convert.ToInt64(MySTT);
            Compl = "";
            for (i = 1; i <= 5; i++)
            {
                Compl = Compl + Convert.ToString(9 - Convert.ToByte(strMid.Mid(FirstTxt, i, 1)));
            }
            MyAt = (byte)(ValTest <= 999 ? 1 : (ValTest <= 9999 ? 2 : (ValTest <= 99999 ? 3 : (ValTest <= 999999 ? 4 : 5))));
            Temp = Rotation(Compl, MyAt) + MySTT;
            Temp = CheckSum(Temp);
        Kthuc:
            return Temp;
        }

        public string CreaBarCodeTV(string MySTT)
        {
            // Cho ra BarCode tu MyStt
            string Temp = null;
            string Compl = null;
            string MyChar = null;
            byte i = 0;
            long ValTest = 0;
            byte MyAt = 0;
            Temp = CreaBarCode(MySTT);
            MyChar = strMid.Mid(Temp, 5, 1);
            MyChar = strMid.Right((Convert.ToString(Convert.ToInt32(MyChar) + 1)).Trim(), 1);
            Temp = strMid.Left(Temp, 4) + MyChar + strMid.Mid(Temp, 6, 7);
            Temp = CheckSum(Temp);
        // ERROR: Not supported in C#: OnErrorStatement

    Kthuc:
            return Temp;
        }

    }



    
}
