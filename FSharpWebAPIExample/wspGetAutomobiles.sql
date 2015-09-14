CREATE PROCEDURE [dbo].[wspGetAutomobiles]
	@Id int,
	@Make nvarchar(100)
AS
BEGIN
	SELECT *
	FROM Automobiles a WITH (NOLOCK)
	WHERE (@Id = 0 OR a.ID = @ID)
	AND (@Make = '' Or a.Make = @Make)
END
