using System;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlServerCe;
using StAbraam.Model;
using System.Windows;
using System.Data.Entity.Infrastructure;
using Microsoft.Win32;
using System.Collections.Generic;

namespace StAbraam.Classes
{
    public class Utils
    {
        public static string DoctorAddedMessage = "Doctor Added";
        public static string subSpecialtyAddedMessage = "subSpecialty Added";

        public static string CityAddedMessage = "City Added";
        public static string CountryAddedMessage = "Country Added";
        public static string LanguageAddedMessage = "Language Added";
        public static string ServiceAddedMessage = "Service Added";
        public static string SpecialtyAddedMessage = " Specialty Added";

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }







        #region Report Utils UnUsed

        public static void EntityToExcelSheet(string excelFilePath,
       string sheetName, IQueryable result, ObjectContext ctx)
        {
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRange;
            //try
            //{
                // Start Excel and get Application object.
                oXL = new Excel.Application();

                // Set some properties
                oXL.Visible = true;
                oXL.DisplayAlerts = false;

                // Get a new workbook. 
                oWB = oXL.Workbooks.Add(Missing.Value);

                // Get the active sheet 
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = sheetName;

                // Process the DataTable
                // BE SURE TO CHANGE THIS LINE TO USE *YOUR* DATATABLE 
                DataTable dt = EntityToDataTable(result, ctx);

                int rowCount = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through 
                        if (rowCount == 2)
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }

                // Resize the columns 
                oRange = oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[rowCount, dt.Columns.Count]];
                oRange.Columns.AutoFit();

                // Save the sheet and close 
                oSheet = null;
                oRange = null;
                oWB.SaveAs(excelFilePath, Excel.XlFileFormat.xlWorkbookNormal, Missing.Value,
                  Missing.Value, Missing.Value, Missing.Value,
                  Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value,
                  Missing.Value, Missing.Value, Missing.Value);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oWB = null;
                oXL.Quit();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public static DataTable EntityToDataTable(IQueryable result, ObjectContext ctx)
        {
            //try
            //{
                EntityConnection conn = ctx.Connection as EntityConnection;
                using (SqlCeConnection SQLCon = new SqlCeConnection(conn.StoreConnection.ConnectionString))
                {
                var dbQuery = result;
                var internalQueryField = dbQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_internalQuery"));
                var internalQuery = internalQueryField.GetValue(dbQuery);
                var objectQueryField = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_objectQuery"));

                // Here's your ObjectQuery!
                var objectQuery = objectQueryField.GetValue(internalQuery) as ObjectQuery<Doctor>;
                var query = objectQuery;
               // ObjectQuery query = result as ObjectQuery;
                    using (SqlCeCommand Cmd = new SqlCeCommand(query.ToTraceString(), SQLCon))
                    {
                        foreach (var param in query.Parameters)
                        {
                            Cmd.Parameters.AddWithValue(param.Name, param.Value);
                        }
                        using (SqlCeDataAdapter da = new SqlCeDataAdapter(Cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }



        public static void saveDoctorTable()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "Doctors.xls";
            // set filters - this can be done in properties as well
            savefile.Filter = "Excel files (*.xls)|*.xls";
            bool res = savefile.ShowDialog()??false;
            if (res)
            {
                using (StAbraamEntities db = new StAbraamEntities())
                {
                    var query = db.Doctors.Select(i => i).AsQueryable();
                    var adapter = (IObjectContextAdapter)db;
                    var objectContext = adapter.ObjectContext;
                    //try
                    //{
                    EntityToExcelSheet(savefile.FileName, "Doctors", query, objectContext);
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Error: " + ex.Message,
                    //      "Error Creating Excel File");
                    //}
                }
            }
            
        }
        #endregion



    }
}
