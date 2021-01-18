using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.Common.Utils;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ruleta.Domain.DAL.Repository
{
    public class RouletteRepository : IRouletteRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        private readonly string _context = "develop.Roulette";
        public RouletteRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public List<RouletteModel> GetAllRoulette()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            List<RouletteModel> listRoulette = new List<RouletteModel>();
            string queryString = queryBuilder.ConstructorSelectAll(_context);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RouletteModel roulette = new RouletteModel();
                        roulette.Id = (long)reader[0];
                        roulette.Name = reader[1].ToString();
                        roulette.Code = reader[2].ToString();
                        roulette.AllowBets = (bool)reader[3];
                        roulette.State = (bool)reader[4];
                        roulette.CreationDate = (DateTime)reader[5];
                        listRoulette.Add(roulette);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 05: Ocurrió un error consultando la base de datos.");
                }

                return listRoulette;
            }
        }

        public long CreateRoulette(RouletteModel roulette)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("develop.CreateRoulette", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Name"].Value = roulette.Name;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 10));
                    sqlCommand.Parameters["@Code"].Value = roulette.Code;
                    sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt));
                    sqlCommand.Parameters["@Id"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        id = (long)sqlCommand.Parameters["@Id"].Value;
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("Error 06: Ocurrió un error consultando la base de datos.");
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return id;
                }
            }
        }

        public RouletteModel GetRouletteById(string rouletteId)
        {
            RouletteModel roulette = new RouletteModel();
            string queryString = "SELECT * FROM develop.Roulette WHERE Id = " + rouletteId + " AND State = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {                        
                        roulette.Id = (long)reader[0];
                        roulette.Name = reader[1].ToString();
                        roulette.Code = reader[2].ToString();
                        roulette.AllowBets = (bool)reader[3];
                        roulette.State = (bool)reader[4];
                        roulette.CreationDate = (DateTime)reader[5];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 06: Ocurrió un error consultando la base de datos.");
                }

                return roulette;
            }
        }

        public bool RouletteOpening(string rouletteId)
        {
            string queryString = "UPDATE develop.Roulette SET AllowBets = 1 WHERE Id = " + rouletteId + " AND state = 1;" ;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteReader();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 07: Ocurrió un error consultando la base de datos.");
                }                
            }
        }
    }
}