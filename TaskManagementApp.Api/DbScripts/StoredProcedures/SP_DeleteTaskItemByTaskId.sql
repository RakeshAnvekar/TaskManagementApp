-- Check if the procedure already exists, and drop it if it does
IF OBJECT_ID('dbo.SP_DeleteTaskItemByTaskId', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.SP_DeleteTaskItemByTaskId;
END
GO

-- Create the procedure
CREATE PROCEDURE dbo.SP_DeleteTaskItemByTaskId
    @TaskId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Update the task status to inactive (isActive = 0) for the given TaskId
    UPDATE dbo.tasks
    SET isActive = 0
    WHERE TaskId = @TaskId;

     IF @@ROWCOUNT > 0
    BEGIN
        SELECT 'Task status successfully updated to inactive.' AS Message;
    END
    ELSE
    BEGIN
        SELECT 'Task not found or already inactive.' AS Message;
    END
END;
GO
