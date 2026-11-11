using System;

namespace SolidRefactoringLab
{

    public class ReportManager
    {
        private readonly IReportFormatter _formatter;

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // 1. Choose the formatter (OCP)
            IReportFormatter pdf = new PdfFormatter();
            IReportFormatter word = new WordFormatter();
            IReportFormatter text = new PlainTextFormatter();

            // 2. Pass it to the manager
            ReportManager pdfManager = new ReportManager(pdf);
            pdfManager.GenerateReport();

            ReportManager wordManager = new ReportManager(word);
            wordManager.GenerateReport();

            ReportManager textManager = new ReportManager(text);
            textManager.GenerateReport();

            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }

    }
}