using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ActiveDirectoryExample
{
    public class SqlServerImplementation : IHRSystem
    {

        public async Task<JArray> GetAllHowdyUsersAsync()
        {
            var employees = new JArray();

            var connectionString = ConfigurationManager.ConnectionStrings["sqlServerConnectionString"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();

                using (var sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.CommandText = File.ReadAllText(Path.GetFullPath(".\\EmployeeList.sql"));

                    var reader = sqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (await reader.ReadAsync())
                    {
                        var employee = new JObject();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            employee.Add(ConvertToJProperty(reader, i));
                        }
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        private JProperty ConvertToJProperty(SqlDataReader reader, int i)
        {
            var value = reader.GetValue(i);
            var name = reader.GetName(i);
            switch (value)
            {
                case string stringValue: return new JProperty(name, stringValue);
                case int intValue: return new JProperty(name, intValue);
                case Boolean boolValue: return new JProperty(name, boolValue);
                case DateTime dateTimeValue: return new JProperty(name, dateTimeValue.ToString("s"));
                case DBNull _: return new JProperty(name, null);
                default: throw new Exception($"Unknown type for column {name}: {value.GetType().Name}");
            }
        }
    }
}
