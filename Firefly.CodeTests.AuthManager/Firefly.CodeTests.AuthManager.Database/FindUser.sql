CREATE PROCEDURE [dbo].[FindUser]
	@Username nvarchar(50)
AS
	SELECT Id, Username
	FROM Users
	Where Username = @Username
RETURN 0
