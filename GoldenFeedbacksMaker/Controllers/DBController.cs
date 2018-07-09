using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenFeedbacksMaker.Controllers
{
    public class DBController : IDisposable
    {
        private const string connectionString = "Data Source=ROOMPC;Initial Catalog = GoldenFeedbacks; Integrated security = true";

        SqlConnection sqlConnection { get; set; }

        public DBController()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataSet GetAllQuestions()
        {
            try
            {
                string commandText = @"SELECT Q.Number, Q.Question, Q.Answer, C.[Description] as Chapter, CM.Title, CM.Comment
                                        FROM
                                        tbQuestions Q
                                        INNER JOIN tbChapters C ON Q.idChapter = C.id
                                        LEFT JOIN tbComments CM ON C.id = CM.idQuestion
                                        ";

                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(commandText, sqlConnection);

                DataSet dsResult = new DataSet();
                adapter.Fill(dsResult);

                sqlConnection.Close();

                return dsResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
