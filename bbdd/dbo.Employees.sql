CREATE TABLE [dbo].[Employees] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [CreatedOn] DATETIME       NOT NULL,
    [DeletedOn] DATETIME       NULL,
    [Email]     VARCHAR (100)  NOT NULL,
    [Fax]       VARCHAR (11)   NOT NULL,
    [Name]      VARCHAR (100)  NOT NULL,
    [Lastlogin] DATETIME       NOT NULL,
    [Password]  NVARCHAR (MAX) NOT NULL,
    [PortalId]  INT            NOT NULL,
    [RoleId]    INT            NOT NULL,
    [StatusId]  INT            NOT NULL,
    [Telephone] VARCHAR (11)   NOT NULL,
    [UpdatedOn] DATE           NOT NULL,
    [Username]  VARCHAR (100)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

