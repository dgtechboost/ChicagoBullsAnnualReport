using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace ChicagoBullsAnnualReport.Core
{
    /// <summary>
    /// Helper class to process and manipulate content of the file/files
    /// </summary>
    public class FileHelper : IFileHelper
    {
        private List<List<string>> listOfRows = new List<List<string>>();

        public virtual List<List<string>> ExtractContent()
        {
            var pathToCSVFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Artefacts\", "chicago-bulls.csv");

            using (TextFieldParser parser = new TextFieldParser(pathToCSVFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var listOfFields = new List<string>();

                    foreach (var field in fields)
                    {
                        listOfFields.Add(field);
                    }

                    listOfRows.Add(listOfFields);
                }
            }

            return listOfRows;
        }
    }
}
