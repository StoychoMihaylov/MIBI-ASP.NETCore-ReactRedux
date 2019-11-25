namespace MIBI.Utilities
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Primitives;

    public class Authorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                string brearer = authToken.First();
                string token = brearer.Split(' ')[1];
                string storedToken = string.Empty;

                storedToken = CheckIfTokenExistInDB(token);

                if (storedToken == string.Empty)
                {
                    context.Result = new ContentResult { StatusCode = 401, Content = "User Unauthorized!" };
                }
            }
            else
            {
                context.Result = new ContentResult { StatusCode = 401, Content = "User Unauthorized!" };
            }
        }

        private string CheckIfTokenExistInDB(string token)
        {
            string result = string.Empty;

            string connectionString = "Server =.\\SQLEXPRESS; Database = MIBI; Integrated Security = True; Trusted_Connection = True; MultipleActiveResultSets = true";
            string sql = $"SELECT * FROM Tokens WHERE Value = '{token}'";
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetString(dataReader.GetOrdinal("Value"));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }

            return result;
        }
    }
}
