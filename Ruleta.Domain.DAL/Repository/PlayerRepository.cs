using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Data.SqlClient;

namespace Ruleta.Domain.DAL.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        public PlayerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public float GetPlayerBalanceById(long playerId)
        {
            float balance = 0f;
            string queryString = "SELECT Balance FROM develop.Player WHERE Id = "+ playerId + " AND State = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        balance = Convert.ToSingle(reader[0]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 09: Ocurrió un error consultando la base de datos.");
                }

                return balance;
            }
        }

        public PlayerModel GetPlayerById(long playerId)
        {
            PlayerModel player = new PlayerModel();
            string queryString = "SELECT * FROM develop.Player WHERE Id = " + playerId + " AND State = 1;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        player.Id = (long)reader[0];
                        player.FirstName = reader[1].ToString();
                        player.SecondName = (reader[2] == DBNull.Value) ? string.Empty: reader[2].ToString();
                        player.Surname = (string)reader[3];
                        player.SecondSurname = (reader[4] == DBNull.Value) ? string.Empty : reader[4].ToString();
                        player.Birthdate = (DateTime)reader[5];
                        player.DocumentTypeId = (long)reader[6];
                        player.Document = (string)reader[7];
                        player.Balance = Convert.ToSingle(reader[8]);
                        player.State = (bool)reader[9];
                        player.CreationDate = (DateTime)reader[10];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 10: Ocurrió un error consultando la base de datos.");
                }

                return player;
            }
        }
    }
}
