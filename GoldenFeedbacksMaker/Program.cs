using GoldenFeedbacksMaker.Classes;
using GoldenFeedbacksMaker.Controllers;
using GoldenFeedbacksMaker.Helpers;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Data;

namespace GoldenFeedbacksMaker
{
    class Program
    {
        public const String DEST = "TheGoldenFeedbacks.pdf";

        static void Main(string[] args)
        {
            CreateBook();
        }

        private static DataTable GetQuestions()
        {
            DataSet dsQuestions = null;
            using (DBController dbController = new DBController())
            {
                dsQuestions = dbController.GetAllQuestions();
            }

            return dsQuestions.Tables[0];
        }

        static void CreateBook()
        {
            var writer = new PdfWriter(DEST);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);

            document.SetMargins(50, 50, 50, 50);

            DataTable dtQuestions = GetQuestions();

            for (var i = 0; i < dtQuestions.Rows.Count; i++)
            {
                Question q = new Question();
                q.Number = Convert.ToInt32(dtQuestions.Rows[i]["Number"]);
                q.Content = dtQuestions.Rows[i]["Question"].ToString();
                document.Add(q.GetQuestion());

                Answer a = new Answer();
                a.Number = Convert.ToInt32(dtQuestions.Rows[i]["Number"]);
                a.Content = dtQuestions.Rows[i]["Answer"].ToString();
                document.Add(a.GetAnswer());

                if (dtQuestions.Rows[i]["Title"] != DBNull.Value)
                {
                    Comment c = new Comment();
                    c.Title = dtQuestions.Rows[i]["Title"].ToString();
                    c.Content = dtQuestions.Rows[i]["Comment"].ToString();
                    document.Add(c.GetComment());
                }
            }

            HeaderFooterHelper headerFooterHelper = new HeaderFooterHelper();
            Document doc = new Document(pdf);
            headerFooterHelper.AddHeaderAndFooter(pdf, ref doc, "The Golden Feedbacks 2018 - Anatomy", 1, 1);

            document.Close();
        }
       
    }
}
