using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace TestCT
{
    public class HelpRepository
    {

        public static RepositoryItemLookUpEdit GetCotPLLookUp(string IDField, string DisplayField, DataTable DataLookup, string[] LookupVisibleFields, string[] Captions, string ColumnField, bool AllowBlank, params int[] Widths)
        {
            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();
            if (AllowBlank)
            {
                DataRow row = DataLookup.NewRow();
                row[IDField] = -1;
                row[DisplayField] = "";
                DataLookup.Rows.InsertAt(row, 0);
            }
            edit.DataSource=DataLookup;
            edit.ValueMember=IDField;
            edit.DisplayMember=DisplayField;
            edit.ImmediatePopup=true;
            edit.ShowLines=true;
            //edit.NullText=GlobalConst.NULL_TEXT);
            int num = 0;
            if (LookupVisibleFields != null)
            {
                for (int i = 0; i < LookupVisibleFields.Length; i++)
                {
                    LookUpColumnInfo info = new LookUpColumnInfo();
                    info.FieldName=LookupVisibleFields[i];
                    info.Caption=Captions[i];
                    if (Widths != null)
                    {
                        info.Width=Widths[i];
                    }
                    else
                    {
                        info.Width=40;
                    }
                    num += info.Width;
                    edit.Columns.Add(info);
                }
            }
            edit.PopupWidth=num;
            edit.TextEditStyle=0;
            if (Widths == null)
            {
                edit.BestFit();
            }
            return edit;
        }
        public static RepositoryItemDateEdit GetDateEdit(string Format)
        {
            RepositoryItemDateEdit edit = new RepositoryItemDateEdit();
            edit.EditFormat.FormatType=FormatType.DateTime;
            edit.EditFormat.FormatString=Format;
            edit.Mask.MaskType = MaskType.DateTime;
            edit.Mask.EditMask="dd/MM/yyyy";
            return edit;
        }

        public static RepositoryItemMemoExEdit GetMemoExEdit()
        {
            return new RepositoryItemMemoExEdit();
        }
       
    }
}

