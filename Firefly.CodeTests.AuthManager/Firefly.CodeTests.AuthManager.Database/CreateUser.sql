CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
	INSERT INTO Users
	(Username, Password)
	VALUES
	(@Username, @Password)
RETURN 0
