using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ruleta.Domain.DAL.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        public List<DocumentTypeModel> GetAllDocumentType()
        {
            List<DocumentTypeModel> documentTypeModel = new List<DocumentTypeModel>();
            //string connectionString = "Data Source=localhost,1433;Initial Catalog=Ruleta;persist security info=True;User Id=;Password=;MultipleActiveResultSets=true;";
            string connectionString = "Data Source=(local);Initial Catalog=Ruleta;"
            + "Integrated Security=true";

            string queryString = "select * from develop.DocumentType where state = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DocumentTypeModel documentType = new DocumentTypeModel();
                        documentType.Id = (long)reader[0];
                        documentType.Name = reader[1].ToString();
                        documentType.Code = reader[2].ToString();
                        documentType.State = (bool)reader[3];
                        documentType.CreationDate = (DateTime)reader[4];
                        documentTypeModel.Add(documentType);
                    }
                    reader.Close();                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return documentTypeModel;
            }
        }
    }
}
