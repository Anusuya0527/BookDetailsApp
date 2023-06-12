using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookDetailsApp
{
    public class BookDetailsDbContext : DbContext
    {
        public BookDetailsDbContext(DbContextOptions<BookDetailsDbContext> options) : base(options)
        {
        }

        public List<T> CallStoredProcedure<T>(string storedProcedureName, params SqlParameter[] parameters)
                where T : class
        {
            using (SqlConnection connection = new SqlConnection(Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var entityList = new List<T>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var entity = MapEntity<T>((SqlDataReader)reader);
                                entityList.Add(entity);
                            }
                        }
                        return entityList;
                    }
                }
            }
        }

        private T MapEntity<T>(SqlDataReader reader)
    where T : class
        {
            var entity = Activator.CreateInstance<T>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var propertyName = reader.GetName(i);
                var property = typeof(T).GetProperty(propertyName);

                if (property != null && !reader.IsDBNull(i))
                {
                    var value = reader.GetValue(i);
                    property.SetValue(entity, value);
                }
            }

            return entity;
        }


        public decimal ExecuteScalar(string storedProcedureName, params SqlParameter[] parameters)
        {
            decimal result = 0;
            using (SqlConnection connection = new SqlConnection(Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    // Execute the stored procedure and retrieve the decimal value
                    result = (decimal)command.ExecuteScalar();
                }
            }

            return result;
        }
    }
}