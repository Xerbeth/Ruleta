using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ruleta.Domain.DAL.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        public DocumentTypeRepository(IConfiguration configuration) 
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Class repository method to get all records from DocumentType table
        /// </summary>
        /// <returns> List of table records </returns>
        public List<DocumentTypeModel> GetAllDocumentType()
        {            
            List<DocumentTypeModel> documentTypeModel = new List<DocumentTypeModel>();
            string queryString = "SELECT * FROM develop.DocumentType WHERE state = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                    throw new ArgumentException("Error 02: Ocurrió un error consultando la base de datos.");
                }

                return documentTypeModel;
            }
        }
        
    }
}
