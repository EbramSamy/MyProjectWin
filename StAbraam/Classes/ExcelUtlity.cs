using StAbraam.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;

namespace StAbraam.Classes
{
    public class ExcelUtlity
    {
        /// <summary>
        /// FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = ReporType;
                excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

                // loop through each row and add values to our sheet
                int rowcount = 2;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 3)
                        {
                            if (i == dataTable.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }

        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                if (!IsPropertyACollection(prop))
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                else
                {
                    table.Columns.Add(prop.Name);//, System.String);
                }

            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    if (!IsPropertyACollection(prop))
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    else
                    {
                        var val = prop.GetValue(item);
                        if (val != null)
                        {
                            if (prop.PropertyType.FullName.Contains("Doctor_Cities"))
                            {
                                List<string> list = ((HashSet<Doctor_Cities>)prop.GetValue(item)).Select(i => i.City.CityName).ToList();
                                //DataTable t = list;
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += " " + i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Countries"))
                            {
                                List<string> list = ((HashSet<Doctor_Countries>)prop.GetValue(item)).Select(i => i.Country.CountryName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += " " + i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Clinic"))
                            {
                                List<string> landLineList = ((HashSet<Doctor_Clinic>)prop.GetValue(item)).Select(i => i.Clinic.Landline).ToList();
                                List<string> buildingNoList = ((HashSet<Doctor_Clinic>)prop.GetValue(item)).Select(i => i.Clinic.Address.BuildingNo).ToList();
                                List<string> districtList = ((HashSet<Doctor_Clinic>)prop.GetValue(item)).Select(i => i.Clinic.Address.District).ToList();
                                List<string> streetNameList = ((HashSet<Doctor_Clinic>)prop.GetValue(item)).Select(i => i.Clinic.Address.StreetName).ToList();
                                string res = "";
                                for (int i = 0; i < landLineList.Count; i++)
                                {
                                    res += $"({landLineList[i]}) , {buildingNoList[i]} , {streetNameList[i]} , {districtList[i]} \n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_CurrentService"))
                            {
                                List<string> list = ((HashSet<Doctor_CurrentService>)prop.GetValue(item)).Select(i => i.Service.ServiceName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += " " + i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Languages"))
                            {
                                List<string> list = ((HashSet<Doctor_Languages>)prop.GetValue(item)).Select(i => i.Language.LanguageName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += " " + i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_PreferedPeriod"))
                            {
                                List<string> list = ((HashSet<Doctor_PreferedPeriod>)prop.GetValue(item)).Select(i => $"From : { i.Period.From.ToString("d/M")} To :  {i.Period.To.ToString("d/M")}").ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Specialty"))
                            {
                                List<string> list = ((HashSet<Doctor_Specialty>)prop.GetValue(item)).Select(i => i.Specialty.SpecialtyName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Sub_Specialty"))
                            {
                                List<string> list = ((HashSet<Doctor_Sub_Specialty>)prop.GetValue(item)).Select(i => i.Sub_Specialty.Sub_SpecialtyName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += " - " + i+"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_Suggestion"))
                            {
                                List<string> list = ((HashSet<Doctor_Suggestion>)prop.GetValue(item)).Select(i=> $"{i.Suggestion.Service.ServiceName } : {i.Suggestion.Suggestion1}" ).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res += $" {i} \n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Mobile"))
                            {
                                List<string> list = ((HashSet<Mobile>)prop.GetValue(item)).Select(i=>i.MobileNo).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res +=  i +"\n";
                                }
                                row[prop.Name] = res;
                            }
                            if (prop.PropertyType.FullName.Contains("Doctor_ToJoinServices"))
                            {
                                List<string> list = ((HashSet<Doctor_ToJoinServices>)prop.GetValue(item)).Select(i=>i.Service.ServiceName).ToList();
                                string res = "";
                                foreach (var i in list)
                                {
                                    res +=  i+"\n";
                                }
                                row[prop.Name] = res;
                            }

                        }

                        else
                        {
                            val = DBNull.Value;
                        }
                    }
                table.Rows.Add(row);
            }
            return table;

        }

        private static bool IsPropertyACollection(PropertyDescriptor property)
        {
            //return property.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
            // return (typeof(IEnumerable).IsAssignableFrom(property.PropertyType));
            return (property.PropertyType.FullName.Contains("Collection"));
        }

        private static bool IsUserDefiened(PropertyDescriptor property)
        {
            return !(property.PropertyType.FullName.Contains("mscorlib"));

        }
    }
}
