using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ruleta.Domain.DAL.Repository
{
    public class RouletteConfigurationRepository : IRouletteConfigurationRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        private readonly string _context = "develop.RouletteConfiguration";
        public RouletteConfigurationRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public List<RouletteConfigurationModel> GetAllRouletteConfiguration()
        {
            List<RouletteConfigurationModel> listRouletteConfiguration = new List<RouletteConfigurationModel>();
            string queryString = "SELECT * FROM " + _context + " WHERE state = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RouletteConfigurationModel rouletteConfiguration = new RouletteConfigurationModel();
                        rouletteConfiguration.Id = (long)reader[0];
                        rouletteConfiguration.Number = reader[1].ToString();
                        rouletteConfiguration.Color = reader[2].ToString();
                        rouletteConfiguration.Code = reader[3].ToString();
                        rouletteConfiguration.RouletteId = (long)reader[4];
                        rouletteConfiguration.State = (bool)reader[5];
                        rouletteConfiguration.CreationDate = (DateTime)reader[6];
                        listRouletteConfiguration.Add(rouletteConfiguration);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 03: Ocurrió un error consultando la base de datos.");
                }

                return listRouletteConfiguration;
            }
        }

        public List<RouletteConfigurationModel> GetAllRouletteConfigurationByRoulette(long rouletteId)
        {
            List<RouletteConfigurationModel> listRouletteConfiguration = new List<RouletteConfigurationModel>();
            string queryString = "SELECT * FROM " + _context + " WHERE rouletteId = "+ rouletteId + " AND state = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RouletteConfigurationModel rouletteConfiguration = new RouletteConfigurationModel();
                        rouletteConfiguration.Id = (long)reader[0];
                        rouletteConfiguration.Number = reader[1].ToString();
                        rouletteConfiguration.Color = reader[2].ToString();
                        rouletteConfiguration.Code = reader[3].ToString();
                        rouletteConfiguration.RouletteId = (long)reader[4];                        
                        rouletteConfiguration.State = (bool)reader[5];
                        rouletteConfiguration.CreationDate = (DateTime)reader[6];
                        listRouletteConfiguration.Add(rouletteConfiguration);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 03: Ocurrió un error consultando la base de datos.");
                }

                return listRouletteConfiguration;
            }
        }

        public void CreateRouletteConfiguration(long rouletteId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("develop.CreateRouletteConfiguration", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RouletteId", SqlDbType.BigInt));
                    sqlCommand.Parameters["@RouletteId"].Value = rouletteId;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("Error 04: Ocurrió un error consultando la base de datos.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public bool ValidateNumberByRouletteId(ValidateBetDTO validateBet)
        {
            bool flag = false;
            string queryString = "SELECT * FROM develop.RouletteConfiguration WHERE rouletteId = " + 
                                  validateBet.RouletteId + " AND Number = " + validateBet.Bet + " AND state = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        flag = true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 11: Ocurrió un error consultando la base de datos.");
                }

                return flag;
            }
        }

        public bool ValidateColorByRouletteId(ValidateBetDTO validateBet)
        {
            bool flag = false;
            string queryString = "SELECT * FROM develop.RouletteConfiguration WHERE rouletteId = " 
                                  + validateBet.RouletteId + " AND Color = '" + validateBet.Bet + "' AND state = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        flag = true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 12: Ocurrió un error consultando la base de datos.");
                }

                return flag;
            }
        }
    }
}
