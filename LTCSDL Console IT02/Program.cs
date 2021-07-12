using System;
using System.Data;
using System.Data.SqlClient;

namespace LTCSDL_Console_IT02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /// Tao COnnection
            string cnstr = "Server = localhost; Database = Northwind; Integrated Security = true;";
            SqlConnection cnn = new SqlConnection(cnstr);

            // Taso command
            //string sql = "Insert Into Categories(CategoryName, [Description])";
            //sql = sql + " Values('Xe Oto 1234', 'Hyunhdai, Toyota, Honda...')";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "CustOrderHist";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@CustomerID", "ANTON"));

            // Mo ket noi
            try
            {
                cnn.Open();

                //cmd.ExecuteNonQuery();
                //Console.WriteLine("Them moi thanh cong!!!");

                
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.Write("Product Name : " + sdr["ProductName"]);
                    Console.Write("\t\t\tTotal: " + sdr["Total"]);
                    Console.WriteLine();
                }

                // Dong ket noi
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);                
            }
            finally
            {
                cnn.Close();
            }

        }
    }
}
