using System;
using System.Collections.Generic;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace SGC_Tool.FrmDonDatHang
{
    class ExcelHelper
    {
        static public bool exportDataToExcel(string tieude, DataTable dt,string PathFile,string name,string dienthoai,string dc)
        {
            bool result = false;
            //khoi tao cac doi tuong Com Excel de lam viec
            Excel.ApplicationClass xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.ApplicationClass();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
            int socot=8;
            int sohang=dt.Rows.Count;
            int i,j;
            decimal tongsoluong = 0;
            decimal tonggiagoc = 0;
            decimal tongthanhtien = 0;
            //SaveFileDialog f = new SaveFileDialog();
            //f.Filter = "Excel file (*.xls)|*.xls";
            //if (f.ShowDialog() == DialogResult.OK)
            //{
                //set thuoc tinh cho tieu de
                xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1").Merge(false);
                Excel.Range caption = xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1");
                caption.Select();
                caption.FormulaR1C1 = tieude;
                //căn lề cho tiêu đề
                caption.HorizontalAlignment = Excel.Constants.xlCenter;
                caption.Font.Bold = true;
                caption.VerticalAlignment = Excel.Constants.xlCenter;
                caption.Font.Size = 15;
                //màu nền cho tiêu đề
                caption.Interior.ColorIndex = 20;
                caption.RowHeight = 30;

                Excel.Range ICIM = xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + "5");
                ICIM.Select();
                xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + "2").Merge(false);
                xlSheet.get_Range("A3", Convert.ToChar(socot + 65) + "3").Merge(false);
                xlSheet.get_Range("A4", Convert.ToChar(socot + 65) + "4").Merge(false);
                xlSheet.Cells[2, 1] = "Họ tên KH: "+name;
                xlSheet.Cells[3, 1] = "Điện thoại: " + dienthoai;
                xlSheet.Cells[4, 1] = "Địa chỉ: " + dc;
            ICIM.Font.Bold = true;
            ICIM.Font.Size = 12;
            ICIM.Font.Name = "Times New Roman";
            ICIM.Interior.ColorIndex = 19;
            ICIM.HorizontalAlignment = Excel.Constants.xlLeft;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A5", Convert.ToChar(socot + 65) + "5");
                header.Select();
            header.Columns.AutoFit();
            foreach (Excel.Range column in header.Columns)
            {
                column.ColumnWidth = (double)column.ColumnWidth + 10;
                if(column.Column==4)
                {
                    column.ColumnWidth = 30;
                }
                if (column.Column == 3)
                {
                    
                }

            }
                header.HorizontalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
            int rowtemp = sohang + 5;
                //điền tiêu đề cho các cột trong file excel
                //for (i = 0; i < socot; i++)
                xlSheet.Cells[5, 2] = "SKU";
         
                xlSheet.Cells[5, 3] = "UPC";
               
                xlSheet.Cells[5, 4] = "Tên sản phẩm";
               
                xlSheet.Cells[5, 5] = "Số lượng";
              
                xlSheet.Cells[5, 6] = "Giá gốc";
         
                xlSheet.Cells[5, 7] = "Giá khuyến mãi";
               
                xlSheet.Cells[5, 8] = "Thành tiền";
            
                xlSheet.Cells[5, 9] = "Ghi chú";
             
                //dien cot stt
                xlSheet.Cells[5, 1] = "STT";
                header.Interior.ColorIndex =15;
            //sua lai format excel
                //for (i = 0; i < sohang; i++)
                for (i = 0; i < sohang; i++)
                    xlSheet.Cells[i + 6, 1] = i + 1;
                //dien du lieu vao sheet


                for (i = 0; i < sohang; i++)
                {
                    for (j = 0; j < socot; j++)
                    {
                        if(j>=4&&j<=6)
                        {
                            ((Excel.Range)xlSheet.Cells[i + 6, j + 2]).NumberFormat = "#,##0.00_);(#,##0.00)";
                            xlSheet.Cells[i + 6, j + 2] = dt.Rows[i][j];
                        }
                        if(j==1)
                        {
                            ((Excel.Range)xlSheet.Cells[i + 6, j + 2]).NumberFormat = "##0_);(##0)";
                            xlSheet.Cells[i + 6, j + 2] = dt.Rows[i][j];
                        }
                        else
                        {
                            xlSheet.Cells[i + 6, j + 2] =""+ Convert.ToString(dt.Rows[i][j]);
                        }

                    }
                    tongsoluong += Convert.ToDecimal(dt.Rows[i]["SoLuong"]);
                    tongthanhtien += Convert.ToDecimal(dt.Rows[i]["ThanhTien"]);
                    tonggiagoc += Convert.ToDecimal(dt.Rows[i]["GiaGoc"]);
                }
                    
                //autofit độ rộng cho các cột
                //sua lai format excel 
                //for (i = 0; i < sohang; i++)
                for (i = 0; i < socot; i++)
                    ((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();

                int temp = sohang + 6;
                Excel.Range foodter = xlSheet.get_Range("A"+temp,"I"+temp);
               foodter.Select();
                foodter.Font.Size = 10;
                foodter.Interior.ColorIndex = 48;
                xlSheet.Cells[temp, 5] = tongsoluong;
                ((Excel.Range)xlSheet.Cells[temp, 5]).NumberFormat = "#,##0.00_);(#,##0.00)";
                xlSheet.Cells[temp, 6] = tonggiagoc;
                ((Excel.Range)xlSheet.Cells[temp , 6]).NumberFormat = "#,##0.00_);(#,##0.00)";
                xlSheet.Cells[temp, 8] = tongthanhtien;
                ((Excel.Range)xlSheet.Cells[temp, 8]).NumberFormat = "#,##0.00_);(#,##0.00)";
                //xlSheet.get_Range("A" + sohang + 3, Convert.ToChar(socot + 65) + (sohang + 3).ToString()).Merge(false);
                //save file
                xlBook.SaveAs(PathFile, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
               
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                result = true;
            //}
            return result;
        }
     static  public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
               throw new  Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
   
        //static public bool exportReport(int type,ReportDocument repd)
        //{
        //     SaveFileDialog f  = new SaveFileDialog();
        //     bool result=false;
        //    switch(type)
        //    {
        //        case 1:
             
        //            f.Filter = "Word file(*.doc)|*.doc";
        //            if (f.ShowDialog() == DialogResult.OK)
        //            {
        //                repd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, f.FileName);
        //                result = true;
        //            }
        //            break;
        //        case 2:
                   
        //            f.Filter = "Pdf file(*.pdf)|*.pdf";
        //            if (f.ShowDialog() == DialogResult.OK)
        //            {
        //                repd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, f.FileName);
        //                result = true;
        //            }
        //            break;
        //        case 3:
                   
        //            f.Filter = "Excel file(*.xls)|*.xls";
        //            if (f.ShowDialog() == DialogResult.OK)
        //            {
        //                repd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, f.FileName);
        //                result = true;
        //            }
        //            break;
        //        default:
        //            MessageBox.Show("Khong chon dung loai ");
        //            break;

                   
        //    }
        //    return result;
        //}
//    }
//}
         

    }
}
