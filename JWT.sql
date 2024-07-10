Use Northwind
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
    [LastName] [varchar](50) NOT NULL,
    [UserName] [varchar](50) NOT NULL,
    [Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE PROCEDURE UsersGetByUserAndPassword
(
    @UserName varchar(50),
    @Password varchar(50)
)
AS
BEGIN
    SELECT UserId, FirstName, LastName, UserName, NULL as Password
    FROM Users
    WHERE UserName = @UserName and Password = @Password
END
GO

Insert into Users(UserId, FirstName, LastName, UserName, [Password]) values (1, 'User Name 1', 'User 1 Last Name','User1', '123456')
GO
