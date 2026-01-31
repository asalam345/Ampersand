using Domain.Contexts;
//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    // In your service/component
    public class RoleService
    {
        private readonly DefaultContext _dbContext;

        public RoleService(DefaultContext dbContext)
        {
            _dbContext = dbContext;

            // Force RFCoreDbContext to load connection string
            _ = _dbContext.Database;  // OR
                                      // _ = _dbContext.Model;  // OR
                                      // _dbContext.ChangeTracker;  // Any EF Core property triggers initialization
        }

        public void InsertData(string id, int userId)
        {
            var roleId = "6b49feb2-7488-4356-90ac-a345e9feb730";
            string query = "INSERT INTO AspNetUserRoles (UserId, RoleId, AppUserId) VALUES (@id, @roleId, @appUserId)";
            // NOW ConnectionString should be populated
            using (SqlConnection conn = new SqlConnection(_dbContext.ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = id;
                cmd.Parameters.Add("@roleId", SqlDbType.NVarChar, 255).Value = roleId;
                cmd.Parameters.Add("@appUserId", SqlDbType.NVarChar, 255).Value = userId;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            //using (var conn = new SqlConnection(connString))
            //{
            //    // ... your ADO.NET code
            //}
        }
    }
}
