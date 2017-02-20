using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace TestCT
{
    public class XtraGridSupportExt
    {
        //public static void BitGridColumn(GridColumn column)
        //{
        //    BitGridColumn(column, null);
        //}

        //public static void BitGridColumn(GridColumn column, string FieldName)
        //{
        //    HelpGridColumn.CotCheckEdit(column, FieldName);
        //}

        //public static GridColumn BitGridColumn(GridView Grid, string Caption, string FieldName)
        //{
        //    GridColumn column = CreateGridColumn(Grid, Caption);
        //    BitGridColumn(column, FieldName);
        //    return column;
        //}

        //public static GridColumn CloseButton(GridControl Ctrl, GridView Grid)
        //{
        //    return HelpGridColumn.CotPLDong(Ctrl, Grid);
        //}

        //public static RepositoryItemImageComboBox ComboboxGridColumn(GridColumn column, DataTable data, string ValueField, string DisplayField)
        //{
        //    return ComboboxGridColumn(column, data, ValueField, DisplayField, null);
        //}

        //public static RepositoryItemLookUpEdit ComboboxGridColumn(GridColumn column, string LookupTable, string ValueField, string DisplayField)
        //{
        //    return ComboboxGridColumn(column, LookupTable, ValueField, DisplayField, null);
        //}

        public static RepositoryItemImageComboBox ComboboxGridColumn(GridColumn column, DataTable data, string ValueField, string DisplayField, string fieldName)
        {
            RepositoryItemImageComboBox box = new RepositoryItemImageComboBox();
            //foreach (DataRow row in data.Rows)
            //{
            //    box.get_Items().Add(new ImageComboBoxItem(row[DisplayField].ToString() ?? "", row[ValueField]));
            //}
            //column.set_ColumnEdit(box);
            //if (fieldName != null)
            //{
            //    column.set_FieldName(fieldName);
            //}
            return box;
        }

        //public static RepositoryItemLookUpEdit ComboboxGridColumn(GridColumn column, string LookupTable, string ValueField, string DisplayField, string InputField)
        //{
        //    return HelpGridColumn.CotCombobox(column, LookupTable, ValueField, DisplayField, InputField);
        //}

        //public static RepositoryItemImageComboBox CreateDuyetGridColumn(GridColumn col)
        //{
        //    return HelpGridColumn.CotPLDuyet(col, "DUYET");
        //}

        public static GridColumn CreateGridColumn(GridView Grid, string Caption)
        {
            return HelpGridColumn.ThemCot(Grid, Caption, -2, -1);
        }

        public static GridColumn CreateGridColumn(GridView Grid, string Caption, int VisibleIndex)
        {
            return HelpGridColumn.ThemCot(Grid, Caption, VisibleIndex, -1);
        }

        public static GridColumn CreateGridColumn(GridView Grid, string Caption, int VisibleIndex, int Width)
        {
            return HelpGridColumn.ThemCot(Grid, Caption, VisibleIndex, Width);
        }

        public static RepositoryItemDateEdit DateTimeGridColumn(GridColumn column)
        {
            return DateTimeGridColumn(column, null);
        }

        public static RepositoryItemDateEdit DateTimeGridColumn(GridColumn column, string fieldName)
        {
            return HelpGridColumn.CotDateEdit(column, fieldName);
        }

        public static GridColumn DateTimeGridColumn(GridView Grid, string Caption, string FieldName)
        {
            GridColumn column = CreateGridColumn(Grid, Caption);
            DateTimeGridColumn(column, FieldName);
            return column;
        }

        //public static RepositoryItemCalcEdit DecimalGridColumn(GridColumn Column)
        //{
        //    return DecimalGridColumn(Column, null);
        //}

        //public static RepositoryItemCalcEdit DecimalGridColumn(GridColumn Column, string FieldName)
        //{
        //    return DecimalGridColumn(Column, FieldName, 2);
        //}

        //public static RepositoryItemCalcEdit DecimalGridColumn(GridColumn Column, string FieldName, int SoThapPhan)
        //{
        //    return HelpGridColumn.CotCalcEdit(Column, FieldName, SoThapPhan);
        //}

        //public static GridColumn DecimalGridColumn(GridView Grid, string Caption, string FieldName)
        //{
        //    GridColumn column = CreateGridColumn(Grid, Caption);
        //    DecimalGridColumn(column, FieldName);
        //    return column;
        //}

        //public static RepositoryItemLookUpEdit IDGridColumn(GridColumn column, string ValueField, string DisplayField, string TableName)
        //{
        //    return ComboboxGridColumn(column, TableName, ValueField, DisplayField);
        //}

        //public static RepositoryItemLookUpEdit IDGridColumn(GridColumn column, string ValueField, string DisplayField, string TableName, string FieldName)
        //{
        //    return ComboboxGridColumn(column, TableName, ValueField, DisplayField, FieldName);
        //}

        //public static RepositoryItemComboBox InitGridColumnCotVAT(GridColumn Column, string InputField)
        //{
        //    return HelpGridColumn.CotVAT(Column, InputField);
        //}

        public static RepositoryItemMemoExEdit InitGridColumnMemoEdit(GridColumn Column, string InputField)
        {
            return HelpGridColumn.CotMemoExEdit(Column, InputField);
        }

        //public static RepositoryItemSpinEdit IntegerGridColum(GridColumn Column)
        //{
        //    return IntegerGridColum(Column, null);
        //}

        //public static RepositoryItemSpinEdit IntegerGridColum(GridColumn Column, string FieldName)
        //{
        //    return HelpGridColumn.CotSpinEditInt(Column, FieldName, -79228162514264337593543950335M, 79228162514264337593543950335M, true);
        //}

        //public static RepositoryItemSpinEdit IntegerGridColum(GridColumn Column, string FieldName, int SoThapPhan)
        //{
        //    return HelpGridColumn.CotSpinEditInt(Column, FieldName, -79228162514264337593543950335M, 79228162514264337593543950335M, true);
        //}

        //public static GridColumn IntegerGridColum(GridView Grid, string Caption, string FieldName)
        //{
        //    GridColumn column = CreateGridColumn(Grid, Caption);
        //    IntegerGridColum(column, FieldName);
        //    return column;
        //}

        //public static RepositoryItemLookUpEdit LookUpGridColumn(GridColumn column, string ValueField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions)
        //{
        //    return LookUpGridColumn(column, ValueField, DisplayField, LookupTable, LookupVisibleFields, Captions, null, null);
        //}

        //public static RepositoryItemLookUpEdit LookUpGridColumn(GridColumn column, string ValueField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions, string FieldName)
        //{
        //    return LookUpGridColumn(column, ValueField, DisplayField, LookupTable, LookupVisibleFields, Captions, FieldName, null);
        //}

        //public static RepositoryItemLookUpEdit LookUpGridColumn(GridColumn column, string ValueField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions, string FieldName, int[] widths)
        //{
        //    return HelpGridColumn.CotLookUp(column, ValueField, DisplayField, LookupTable, LookupVisibleFields, Captions, FieldName, widths);
        //}

        public static void TextCenterColumn(GridColumn Column, string FieldName)
        {
            HelpGridColumn.CotTextCenter(Column, FieldName);
        }

        public static void TextLeftColumn(GridColumn Column, string FieldName)
        {
            HelpGridColumn.CotTextLeft(Column, FieldName);
        }

        public static void TextRightColumn(GridColumn Column, string FieldName)
        {
            HelpGridColumn.CotTextRight(Column, FieldName);
        }
    }
}

