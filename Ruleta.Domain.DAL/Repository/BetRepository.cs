using Microsoft.Extensions.Configuration;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ruleta.Domain.DAL.Repository
{
    public class BetRepository : IBetRepository
    {
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        public BetRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Method for creating the bet
        /// </summary>
        /// <param name="createBet"> Object for the creation of the bet </param>
        /// <returns> Creation flag </returns>
        public long CreateBet(CreateBetDTO createBet)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("develop.CreateBet", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PlayerId", SqlDbType.BigInt));
                    sqlCommand.Parameters["@PlayerId"].Value = createBet.PlayerId;
                    sqlCommand.Parameters.Add(new SqlParameter("@BetTypeId", SqlDbType.BigInt));
                    sqlCommand.Parameters["@BetTypeId"].Value = createBet.BetTypeId;
                    sqlCommand.Parameters.Add(new SqlParameter("@RouletteId", SqlDbType.BigInt));
                    sqlCommand.Parameters["@RouletteId"].Value = createBet.RouletteId;
                    sqlCommand.Parameters.Add(new SqlParameter("@Bet", SqlDbType.NVarChar, 10));
                    sqlCommand.Parameters["@Bet"].Value = createBet.Bet;
                    sqlCommand.Parameters.Add(new SqlParameter("@Prize", SqlDbType.Float));
                    sqlCommand.Parameters["@Prize"].Value = createBet.Prize;
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
                        throw new ArgumentException("Error 13: Ocurrió un error consultando la base de datos.");
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return id;
                }
            }
        }
    }
}
