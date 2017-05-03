CREATE PROCEDURE [dbo].[AuthenticateUser]
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
	SELECT Id, Username 
	FROM
	Users 
	WHERE Username = @Username and Password = @Password
RETURN 0
