﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ruleta.Domain.DAL
{
    public class TestConecction
    {
        public TestConecction()
        {
            //string connectionString = "Data Source=localhost,1433;Initial Catalog=Ruleta;persist security info=True;User Id=;Password=;MultipleActiveResultSets=true;";
            string connectionString = "Data Source=(local);Initial Catalog=Ruleta;"
            + "Integrated Security=true";


            // Provide the query string with a parameter placeholder.
            string queryString = "select * from develop.TipoDocumento";

            // Specify the parameter value.
            int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var test = reader[0];
                        //Console.WriteLine("\t{0}\t{1}\t{2}",
                        //    reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }        
    }
}
