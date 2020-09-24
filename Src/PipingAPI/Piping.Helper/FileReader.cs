﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Piping.Helper
{
    public static class FileReader
    {
      public static string Read(string file, string fileType = "xlsx")
        {
            DataTable dtTable = new DataTable();
            switch (fileType)
            {
                case "xlsx":

                    List<string> rowList = new List<string>();
                    ISheet sheet;
                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        stream.Position = 0;
                        XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                        sheet = xssWorkbook.GetSheetAt(0);
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = headerRow.GetCell(j);
                            if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                            {
                                dtTable.Columns.Add(cell.ToString());
                            }
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue;
                            if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                    {
                                        rowList.Add(row.GetCell(j).ToString());
                                    }
                                    else
                                    {
                                        rowList.Add(string.Empty);
                                    }
                                }
                            }
                            if (rowList.Count > 0)
                                dtTable.Rows.Add(rowList.ToArray());
                            rowList.Clear();
                        }
                        break;
                    }
            }
            return JsonConvert.SerializeObject(dtTable,Formatting.Indented);
        }
    }
}
