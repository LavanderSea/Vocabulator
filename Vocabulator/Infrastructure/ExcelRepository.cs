using System;
using System.Drawing;
using System.IO;
using NetOffice.ExcelApi.Tools.Contribution;
using Vocabulator.Models;
using Excel = NetOffice.ExcelApi;

namespace Vocabulator.Infrastructure
{
    public class ExcelRepository : IDisposable
    {
        private readonly Excel.Application _application;

        private double _color = 100;
        private int _row = 1;

        public ExcelRepository()
        {
            _application = new Excel.Application {Visible = true, DisplayAlerts = false};
        }

        public void Dispose()
        {
            _application.Quit();
            _application.Dispose();
        }

        public void AddStringToFile(Excel.Worksheet worksheet, params string[] strings)
        {
            var firstChar = Const.BeginningColumnSymbol;
            var lastChar = (char) (firstChar + Const.ColumnCount - 1);

            if (_row % 2 == 0)
                worksheet.Range("$" + firstChar + _row + ":$" + lastChar + _row).Interior.Color = _color;

            for (var i = 1; i < Const.ColumnCount; i++)
                worksheet.Cells[_row, i].Value = strings[i - 1];

            _row++;
        }

        public void AddWord(Word word, string path)
        {
            if (!File.Exists(path))
                CreateFile(path);

            EditFile(word, path);
        }

        public void EditFile(Word word, string path)
        {
            var workbook = _application.Workbooks.Open(path) ?? _application.Workbooks[1];
            var worksheet = (Excel.Worksheet) workbook.Worksheets[1];
            CountRow(worksheet);
            AddStringToFile(
                worksheet,
                word.Value,
                word.PartOfSpeech,
                word.Transcription,
                word.Definition,
                word.Example);
            workbook.Save();
            worksheet.Dispose();
            workbook.Dispose();
        }

        public void SetColor(Color color)
        {
            var utils = new CommonUtils(_application);
            _color = utils.Color.ToDouble(color);
            utils.Dispose();
        }

        private void CountRow(Excel.Worksheet workbook)
        {
            while (workbook.Cells[_row, 1].Value != null)
                _row++;
        }

        public void CreateFile(string path)
        {
            _row = 1;
            var workbook = _application.Workbooks.Add();
            var worksheet = (Excel.Worksheet) workbook.Worksheets[1];
            for (var i = 1; i <= Const.ColumnCount; i++)
                worksheet.Columns[i].ColumnWidth = Const.ColumnWidths[i - 1];

            AddStringToFile(worksheet, Const.FirstStrings);
            workbook.SaveAs(path);
            worksheet.Dispose();
            workbook.Dispose();
        }
    }
}