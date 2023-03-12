using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GayaProject
{
    class DatabaseManager
    {
        private string connectionString = "";

        public List<CalculationRecord> GetRecentRecords()
        {
            List<CalculationRecord> records = new List<CalculationRecord>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TOP 3 * FROM CalculationHist ORDER BY Id DESC", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CalculationRecord record = new CalculationRecord();
                            record.StrInput1 = reader.GetString(1);
                            record.StrInput1 = reader.GetString(2);
                            record.Operation = reader.GetString(3);
                            record.Result = reader.GetDouble(4);
                            record.Date = reader.GetDateTime(5);

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }


    }
}
