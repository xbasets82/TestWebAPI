using System.Text;

namespace RedArbor.DAL.SQL
{
    class Querys
    {
        public static string GetSelectAllQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine("Id,CompanyID,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,");
            query.AppendLine("PortalId, RoleId, StatusId, Telephone, UpdatedOn, Username");
            query.AppendLine("from Employees");

            return query.ToString();
        }

        public static string GetSelectByIdQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine("Id,CompanyID,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,");
            query.AppendLine("PortalId, RoleId, StatusId, Telephone, UpdatedOn, Username");
            query.AppendLine("from Employees where Id = @Id");

            return query.ToString();
        }

        public static string GetSelectByLastIdQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine("Id,CompanyID,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,");
            query.AppendLine("PortalId, RoleId, StatusId, Telephone, UpdatedOn, Username");
            query.AppendLine("from Employees where Id = (" + GetLastIdQuery() + ")");

            return query.ToString();
        }

        public static string GetLastIdQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT TOP 1 (Id) FROM EMPLOYEES ORDER BY ID DESC");

            return query.ToString();
        }
        public static string GetInsertEmployeeQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO EMPLOYEES");
            query.AppendLine("(CompanyId,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,PortalId,RoleId,");
            query.AppendLine("StatusId,Telephone,UpdatedOn,Username)");
            query.AppendLine("OUTPUT INSERTED.* ");
            query.AppendLine("VALUES ");
            query.AppendLine("(@CompanyId,@CreatedOn,@DeletedOn,@Email,@Fax,@Name,@Lastlogin,@Password,@PortalId,@RoleId,");
            query.AppendLine("@StatusId,@Telephone,@UpdatedOn,@Username) ");

            return query.ToString();
        }

        public static string GetUpdateEmployeeQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("UPDATE EMPLOYEES ");
            query.AppendLine("SET CompanyId = @CompanyId, CreatedOn = @CreatedOn, DeletedOn = @DeletedOn, ");
            query.AppendLine("Email = @Email, Fax = @Fax, Name = @Name, LastLogin = @LastLogin, Password = @Password, ");
            query.AppendLine("PortalId = @PortalId, RoleId = @RoleId, StatusId = @StatusId, Telephone = @Telephone, UpdatedOn = @UpdatedOn, ");
            query.AppendLine("Username = @Username ");
            query.AppendLine("WHERE Id = @Id");

            return query.ToString();
        }

        public static string GetDeleteEmployeeQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("DELETE FROM EMPLOYEES WHERE ID = @Id");

            return query.ToString();
        }

    }
}
