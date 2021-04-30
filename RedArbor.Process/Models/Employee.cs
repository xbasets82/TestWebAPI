using System;

namespace RedArbor.Process.Models
{
  public  class Employee
    {
      
            private int id;
            private int companyId;
            private DateTime createdOn;
            private DateTime deletedOn;
            private string email;
            private string fax;
            private string name;
            private DateTime lastLogin;
            private string password;
            private int portalId;
            private int roleId;
            private int statusId;
            private string telephone;
            private DateTime updatedOn;
            private string username;


            public int Id { get => id; set => id = value; }
            public int CompanyId { get => companyId; set => companyId = value; }
            public DateTime CreatedOn { get => createdOn; set => createdOn = value; }
            public DateTime DeletedOn { get => deletedOn; set => deletedOn = value; }
            public string Email { get => email; set => email = value; }
            public string Fax { get => fax; set => fax = value; }
            public string Name { get => name; set => name = value; }
            public DateTime LastLogin { get => lastLogin; set => lastLogin = value; }
            public string Password { get => password; set => password = value; }
            public int PortalId { get => portalId; set => portalId = value; }
            public int RoleId { get => roleId; set => roleId = value; }
            public int StatusId { get => statusId; set => statusId = value; }
            public string Telephone { get => telephone; set => telephone = value; }
            public DateTime UpdatedOn { get => updatedOn; set => updatedOn = value; }
            public string Username { get => username; set => username = value; }
        }
    }

