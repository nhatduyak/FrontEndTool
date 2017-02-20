using System.Collections.Generic;
using DevExpress.XtraGrid;

namespace TOOLChuyenDuLieu.HelpFile
{
    public class DelegationLib
    {
        public delegate void CallFunction_GridControlIn_NoOut(GridControl grid);

        public delegate void CallFunction_MulIn_NoOut(List<object> data);

        public delegate object CallFunction_MulIn_SinOut(List<object> data);

        public delegate object[] CallFunction_NoIn_MulOut();

        public delegate void CallFunction_NoIn_NoOut();

        public delegate object CallFunction_NoIn_SinOut();

        public delegate object[] CallFunction_SinIn_MulOut(object data);

        public delegate void CallFunction_SinIn_NoOut(object data);

        public delegate object CallFunction_SinIn_SinOut(object data);

        public delegate List<object> DefinePermission(object frmCategory);
    }
}
