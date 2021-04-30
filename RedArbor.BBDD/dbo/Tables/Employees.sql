CREATE TABLE [dbo].[Employees] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [CreatedOn] DATETIME       NOT NULL,
    [DeletedOn] DATETIME       NULL,
    [Email]     VARCHAR (100)  NULL,
    [Fax]       VARCHAR (11)   NULL,
    [Name]      VARCHAR (100)  NULL,
    [Lastlogin] DATETIME       NULL,
    [Password]  NVARCHAR (MAX) NULL,
    [PortalId]  INT            NULL,
    [RoleId]    INT            NULL,
    [StatusId]  INT            NULL,
    [Telephone] VARCHAR (11)   NULL,
    [UpdatedOn] DATE           NULL,
    [Username]  VARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

