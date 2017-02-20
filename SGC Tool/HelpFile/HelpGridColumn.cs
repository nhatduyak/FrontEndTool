using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace TestCT
{
    public class HelpGridColumn
    {
        public static void AnCot(GridColumn Column)
        {
            HideGridColumn(Column);
        }
        //public static RepositoryItemLookUpEdit CotCombobox(GridColumn column, DataSet ds, string IDField, string DisplayField, string ColumnField)
        //{
        //    RepositoryItemLookUpEdit edit = CotPLLookUp(column, IDField, DisplayField, ds.Tables[0], new string[] { DisplayField }, new string[] { "Caption" }, ColumnField, new int[] { column.VisibleWidth });
        //    edit.ShowHeader=false;
        //    return edit;
        //}
        
        //public static RepositoryComboboxAdd CotComboboxAdd(GridView gridView, GridColumn column, string ColumnField, string ValueField, string DisplayField, string TableName)
        //{
        //    column.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
        //    column.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
        //    column.set_FieldName(ColumnField + DisplayField);
        //    RepositoryComboboxAdd add = new RepositoryComboboxAdd(TableName, ColumnField, ValueField, DisplayField, "G_FW_DM_ID", gridView);
        //    add._init();
        //    column.set_ColumnEdit(add);
        //    return add;
        //}
        public static RepositoryItemDateEdit CotDateEdit(GridColumn Column, string ColumnField)
        {
            return CotDateEdit(Column, ColumnField, "d");
        }

        public static RepositoryItemDateEdit CotDateEdit(GridColumn Column, string ColumnField, string Format)
        {
            SetHorzAlignment(Column,HorzAlignment.Default);
            SetDateDisplayFormat(Column, Format);
            Column.ColumnEdit=(HelpRepository.GetDateEdit(Format));
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
            return (RepositoryItemDateEdit) Column.ColumnEdit;
        }

        //public static RepositoryItemSelectDMTreeGroup CotDMTreeReadOnly(GridView gridView, GridColumn column, string ColumnField, string getField, string GroupTableName, int[] RootID, string IDField, string ParentIDField, string[] VisibleFields, string[] Captions, string FilterField)
        //{
        //    column.set_FieldName(ColumnField + getField);
        //    RepositoryItemSelectDMTreeGroup group = new RepositoryItemSelectDMTreeGroup();
        //    group.InitReadOnly(gridView, GroupTableName, RootID, IDField, ParentIDField, VisibleFields, Captions, ColumnField, getField, FilterField);
        //    column.set_ColumnEdit(group);
        //    return group;
        //}

        //public static RepositoryItemSelectDMTreeGroup CotDMTreeReadOnly(TreeList treeList, TreeListColumn column, DataTable dtSource, string ColumnField, string getField, string GroupTableName, int[] RootID, string IDField, string ParentIDField, string[] VisibleFields, string[] Captions, string FilterField)
        //{
        //    column.set_FieldName(ColumnField + getField);
        //    RepositoryItemSelectDMTreeGroup group = new RepositoryItemSelectDMTreeGroup();
        //    group.InitReadOnly(treeList, GroupTableName, dtSource, RootID, IDField, ParentIDField, VisibleFields, Captions, ColumnField, getField, FilterField);
        //    column.set_ColumnEdit(group);
        //    return group;
        //}

        //public static RepositoryItemSelectDMTreeGroup CotDMTreeUpdate(GridView gridView, GridColumn column, string GroupTableName, int[] RootID, string IDField, string ParentIDField, string[] VisibleFields, string[] Captions, string GenName, object[] InputColumnType, FieldNameCheck[] Rules, string ColumnField, string getField, string FilterField)
        //{
        //    column.set_FieldName(ColumnField + getField);
        //    RepositoryItemSelectDMTreeGroup group = new RepositoryItemSelectDMTreeGroup();
        //    group.InitUpdate(gridView, GroupTableName, RootID, IDField, ParentIDField, VisibleFields, Captions, GenName, InputColumnType, Rules, ColumnField, getField, FilterField);
        //    column.set_ColumnEdit(group);
        //    return group;
        //}

        //public static RepositoryItemLookUpEdit CotLookUp(GridColumn column, string IDField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions, string ColumnField, int[] Widths)
        //{
        //    return CotLookUp(column, IDField, DisplayField, LookupTable, LookupVisibleFields, Captions, ColumnField, Widths, false, false);
        //}

        //public static RepositoryItemLookUpEdit CotLookUp(GridColumn column, string IDField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions, string ColumnField, int[] Widths, bool UsingVisible)
        //{
        //    return CotLookUp(column, IDField, DisplayField, LookupTable, LookupVisibleFields, Captions, ColumnField, Widths, UsingVisible, false);
        //}

        //public static RepositoryItemLookUpEdit CotLookUp(GridColumn column, string IDField, string DisplayField, string LookupTable, string[] LookupVisibleFields, string[] Captions, string ColumnField, int[] Widths, bool UsingVisible, bool AllowBlank)
        //{
        //    DataTable dataLookup = null;
        //    if (!UsingVisible)
        //    {
        //        dataLookup = DABase.getDatabase().LoadDataSet(HelpSQL.SelectAll(LookupTable, LookupVisibleFields[0], 1)).Tables[0];
        //    }
        //    else
        //    {
        //        dataLookup = DABase.getDatabase().LoadDataSet(HelpSQL.SelectWhere(LookupTable, "VISIBLE_BIT = 'Y'", LookupVisibleFields[0], 1)).Tables[0];
        //    }
        //    return CotPLLookUp(column, IDField, DisplayField, dataLookup, LookupVisibleFields, Captions, ColumnField, AllowBlank, Widths);
        //}

        public static RepositoryItemMemoEdit CotMemoEdit(GridView grid, GridColumn Column, string ColumnField)
        {
            RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();
            edit.BeginInit();
            Column.ColumnEdit=edit;
            edit.Name="MemoEditColumn";
            Column.FieldName=ColumnField;
            edit.EndInit();
            edit.LinesCount=2;
            edit.AutoHeight=true;
            grid.OptionsView.RowAutoHeight=true;
            return edit;
        }

        public static RepositoryItemMemoExEdit CotMemoExEdit(GridColumn Column, string ColumnField)
        {
            SetHorzAlignment(Column, HorzAlignment.Far);
            Column.ColumnEdit=HelpRepository.GetMemoExEdit();
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
            return (RepositoryItemMemoExEdit) Column.ColumnEdit;
        }
        //public static RepositoryItemLookUpEdit CotPLCombobox(GridColumn Column, DataSet Src, string IDField, string DisplayField, string ColumnField)
        //{
        //    return CotCombobox(Column, Src, IDField, DisplayField, ColumnField);
        //}

        public static RepositoryItemDateEdit CotPLDate(GridColumn Column, string ColumnField, bool HasInput)
        {
            if (HasInput)
            {
                return CotDateEdit(Column, ColumnField, "d");
            }
            CotReadOnlyDate(Column, ColumnField, "d");
            return null;
        }
        
        public static RepositoryItemDateEdit CotPLFullDate(GridColumn Column, string ColumnField, bool HasInput)
        {
            if (HasInput)
            {
                return CotDateEdit(Column, ColumnField, "d");
            }
            CotReadOnlyDate(Column, ColumnField, "d");
            return null;
        }

        //public static RepositoryItemCheckEdit CotPLHienThi(GridColumn column, string ColumnField)
        //{
        //    RepositoryItemCheckEdit edit = CotCheckEdit(column, ColumnField);
        //    column.get_OptionsColumn().set_FixedWidth(true);
        //    column.set_Width(70);
        //    return edit;
        //}

        public static RepositoryItemCheckEdit CotPLImageCheck(GridColumn Column, string ColumnField)
        {
            SetHorzAlignment(Column, HorzAlignment.Far);
            //Column.ColumnEdit=HelpRepository.GetCheckEdit(true);
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
            return (RepositoryItemCheckEdit) Column.ColumnEdit;
        }

        //public static RepositoryItemLookUpEdit CotPLLookUp(GridColumn column, string IDField, string DisplayField, DataTable DataLookup, string[] LookupVisibleFields, string[] Captions, string ColumnField, params int[] Widths)
        //{
        //    return CotPLLookUp(column, IDField, DisplayField, DataLookup, LookupVisibleFields, Captions, ColumnField, true, Widths);
        //}
              
      

        //public static RepositoryItemTimeEdit CotPLTimeEdit(GridColumn Column, string ColumnField)
        //{
        //    return CotPLTimeEdit(Column, ColumnField, null);
        //}

      

      
        public static void CotReadOnlyDate(GridColumn Column, string ColumnField)
        {
            CotReadOnlyDate(Column, ColumnField, "d");
        }

        public static void CotReadOnlyDate(GridColumn Column, string ColumnField, string Format)
        {
            SetHorzAlignment(Column,HorzAlignment.Far);
            SetDateDisplayFormat(Column, Format);
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
        }

       

        public static void CotRepository(GridColumn Column, string ColumnField, RepositoryItem Repos, HorzAlignment HorzAlign)
        {
            SetHorzAlignment(Column, HorzAlign);
            Column.ColumnEdit=Repos;
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
        }

        public static void CotText(GridColumn Column, string ColumnField, HorzAlignment Alignment)
        {
            SetHorzAlignment(Column, Alignment);
            if (ColumnField != null)
            {
                Column.FieldName=ColumnField;
            }
        }

        public static void CotTextCenter(GridColumn Column, string ColumnField)
        {
            CotText(Column, ColumnField, HorzAlignment.Default);
        }

        public static void CotTextLeft(GridColumn Column, string ColumnField)
        {
            CotText(Column, ColumnField, HorzAlignment.Far);
        }

        public static void CotTextRight(GridColumn Column, string ColumnField)
        {
            CotText(Column, ColumnField, HorzAlignment.Near);
        }
        public static GridColumn CreateGridColumn(GridView grid, string caption, int VisibleIndex, int Width)
        {
            GridColumn column = new GridColumn();
            column.Caption=caption;
            column.Name=caption;
            if (VisibleIndex != -2)
            {
                if (VisibleIndex == -1)
                {
                    column.Visible=false;
                    column.OptionsColumn.AllowFocus=false;
                    column.OptionsColumn.ReadOnly=true;
                    column.OptionsColumn.AllowEdit=false;
                    column.Width=0;
                    column.OptionsColumn.FixedWidth=true;
                }
                else
                {
                    column.VisibleIndex=VisibleIndex;
                }
            }
            if (Width != -1)
            {
                column.Width=Width;
            }
            grid.Columns.Add(column);
            return column;
        }

        public static GridColumn[] CreateGridColumns(string[] Captions, bool[] Visible, params int[] Widths)
        {
            GridColumn[] columnArray = new GridColumn[Captions.Length];
            int num = -1;
            for (int i = 0; i < Captions.Length; i++)
            {
                columnArray[i] = new GridColumn();
                columnArray[i].Caption=Captions[i];
                columnArray[i].Name=Captions[i];
                if (!Visible[i])
                {
                    num = -1;
                }
                else
                {
                    num = i;
                }
                if (num == -1)
                {
                    columnArray[i].Visible=false;
                    columnArray[i].OptionsColumn.AllowFocus=false;
                    columnArray[i].OptionsColumn.ReadOnly=true;
                    columnArray[i].OptionsColumn.AllowEdit=false;
                    columnArray[i].Width=0;
                    columnArray[i].OptionsColumn.FixedWidth=true;
                }
                else
                {
                    columnArray[i].VisibleIndex=num;
                }
                if ((Widths != null) && (Widths[i] != -1))
                {
                    columnArray[i].Width=Widths[i];
                }
            }
            return columnArray;
        }

        public static void HideGridColumn(GridColumn Column)
        {
            Column.OptionsColumn.AllowFocus=false;
            Column.OptionsColumn.AllowSize=false;
            Column.OptionsColumn.FixedWidth=true;
            Column.OptionsColumn.ShowCaption=false;
            Column.OptionsColumn.ReadOnly=true;
            Column.Visible=false;
            Column.Width=0;
            Column.VisibleIndex=-1;
        }

        public static void SetDateDisplayFormat(GridColumn column, string formatStr)
        {
            column.DisplayFormat.FormatType=FormatType.Custom;
            column.DisplayFormat.FormatString=formatStr;
        }

        public static void SetHorzAlignment(GridColumn Column, HorzAlignment Content)
        {
            Column.AppearanceHeader.Options.UseTextOptions=true;
            Column.AppearanceHeader.TextOptions.HAlignment=HorzAlignment.Far;
            Column.AppearanceCell.Options.UseTextOptions=true;
            Column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
        }
        public static GridColumn ThemCot(GridView Grid, string Caption, int VisibleIndex, int Width)
        {
            return CreateGridColumn(Grid, Caption, VisibleIndex, Width);
        }
        
    }
}

