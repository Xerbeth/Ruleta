using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ruleta.Domain.DAL.Repository
{
    public class BetTypeRepository : IBetTypeRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        public BetTypeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> List of records stored in table </returns>
        public List<BetTypeModel> GetAllBetType()
        {
            List<BetTypeModel> betTypeModel = new List<BetTypeModel>();           
            string queryString = "SELECT * FROM develop.BetType WHERE State = 1;";            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BetTypeModel betType = new BetTypeModel();
                        betType.Id = (long)reader[0];
                        betType.Name = reader[1].ToString();
                        betType.Code = reader[2].ToString();
                        betType.Description = reader[3].ToString();
                        betType.Pay = float.Parse(reader[4].ToString());
                        betType.State = (bool)reader[5];
                        betType.CreationDate = (DateTime)reader[6];
                        betTypeModel.Add(betType);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 01: Ocurrió un error consultando la base de datos.");
                }
                return betTypeModel;
            }
        }

        public BetTypeModel GetBetTypeByCode(string code)
        {
            BetTypeModel betTypeModel = new BetTypeModel();
            string queryString = "SELECT * FROM develop.BetType WHERE Code = '"+ code +"' AND State = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        betTypeModel.Id = (long)reader[0];
                        betTypeModel.Name = reader[1].ToString();
                        betTypeModel.Code = reader[2].ToString();
                        betTypeModel.Description = reader[3].ToString();
                        betTypeModel.Pay = float.Parse(reader[4].ToString());
                        betTypeModel.State = (bool)reader[5];
                        betTypeModel.CreationDate = (DateTime)reader[6];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 11: Ocurrió un error consultando la base de datos.");
                }
                return betTypeModel;
            }
        }
    }
}
