using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RedArbor.DAL
{
    public class EmployeeDAL : Admin.Base, Interfaces.IEmployeeDAL
    {

        private readonly IConfiguration _configuration;

        public EmployeeDAL(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<DAL.Models.Employee> GetAll()
        {
            List<DAL.Models.Employee> employees = new List<Models.Employee>();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand dbCommand = new SqlCommand(SQL.Querys.GetSelectAllQuery(), sqlConnection);
                    using (SqlDataReader sqlDataReader = dbCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            employees.Add(GetEmployee(sqlDataReader));
                        }
                    }
                    sqlConnection.Close();
                    return employees;
                };
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public DAL.Models.Employee GetByID(int id)
        {
            DAL.Models.Employee employee = new Models.Employee();
            bool employeeExists = false;
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand dbCommand = new SqlCommand(SQL.Querys.GetSelectByIdQuery(), sqlConnection);
                    dbCommand.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader sqlDataReader = dbCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeExists = true;
                            employee = GetEmployee(sqlDataReader);
                        }
                    }
                    sqlConnection.Close();
                    if (employeeExists)
                    {
                        return employee;
                    }
                    else
                    {
                        throw new Exception("the employee does not exist");
                    }
                };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public DAL.Models.Employee Add(DAL.Models.Employee employee)
        {
            DAL.Models.Employee employeeAdded = new Models.Employee();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand dbCommand = new SqlCommand(SQL.Querys.GetInsertEmployeeQuery(), sqlConnection);
                    AddParameters(dbCommand, employee);
                    using (SqlDataReader sqlDataReader = dbCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeAdded = GetEmployee(sqlDataReader);
                        }
                    }
                    sqlConnection.Close();
                    return employeeAdded;
                };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(int id, DAL.Models.Employee employee)
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand dbCommand = new SqlCommand(SQL.Querys.GetUpdateEmployeeQuery(), sqlConnection);
                    AddParameters(dbCommand, employee);
                    AddIdParameter(dbCommand, id);
                    int afectedRows = dbCommand.ExecuteNonQuery();
                    if (afectedRows != 1)
                    {
                        throw new InvalidOperationException("Error at Update SQL");
                    }

                };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand dbCommand = new SqlCommand(SQL.Querys.GetDeleteEmployeeQuery(), sqlConnection);
                    AddIdParameter(dbCommand, id);
                    int afectedRows = dbCommand.ExecuteNonQuery();
                    if (afectedRows != 1)
                    {
                        throw new InvalidOperationException("Error at Delete SQL");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #region "Private methods"
     
        private void AddParameters(SqlCommand dbCommand, Models.Employee employee)
        {
            dbCommand.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            dbCommand.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
            dbCommand.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
            dbCommand.Parameters.AddWithValue("@Email", employee.Email);
            dbCommand.Parameters.AddWithValue("@Fax", employee.Fax);
            dbCommand.Parameters.AddWithValue("@Name", employee.Name);
            dbCommand.Parameters.AddWithValue("@Lastlogin", employee.LastLogin);
            dbCommand.Parameters.AddWithValue("@Password", employee.Password);
            dbCommand.Parameters.AddWithValue("@PortalId", employee.PortalId);
            dbCommand.Parameters.AddWithValue("@RoleId", employee.RoleId);
            dbCommand.Parameters.AddWithValue("@StatusId", employee.StatusId);
            dbCommand.Parameters.AddWithValue("@Telephone", employee.Telephone);
            dbCommand.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
            dbCommand.Parameters.AddWithValue("@Username", employee.Username);
        }

        private void AddIdParameter(SqlCommand dbCommand, int id)
        {
            dbCommand.Parameters.AddWithValue("@Id", id);
        }
        private Models.Employee GetEmployee(SqlDataReader sqlDataReader)
        {
            return new Models.Employee()
            {
                Id = (int)sqlDataReader["Id"],
                CompanyId = (int)sqlDataReader["CompanyId"],
                CreatedOn = ParseDateTime(sqlDataReader["CreatedOn"].ToString()),
                DeletedOn = ParseDateTime(sqlDataReader["DeletedOn"].ToString()),
                Email = (string)sqlDataReader["Email"],
                Fax = (string)sqlDataReader["Fax"],
                Name = (string)sqlDataReader["Name"],
                LastLogin = ParseDateTime(sqlDataReader["Lastlogin"].ToString()),
                Password = (string)sqlDataReader["Password"],
                PortalId = (int)sqlDataReader["PortalId"],
                RoleId = (int)sqlDataReader["RoleId"],
                StatusId = (int)sqlDataReader["StatusId"],
                Telephone = (string)sqlDataReader["Telephone"],
                UpdatedOn = ParseDateTime(sqlDataReader["UpdatedOn"].ToString()),
                Username = (string)sqlDataReader["Username"]
            };
        }

        private DateTime ParseDateTime(string dateString)
        {
            return !string.IsNullOrEmpty(dateString) ? DateTime.Parse(dateString) : DateTime.MinValue;
        }

        #endregion
    }
}

