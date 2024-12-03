
If OBJECT_ID('dbo.SP_SelectAllActiveTaskItems') is not null
begin
drop procedure dbo.SP_SelectAllActiveTaskItems
end
Go 
Create Procedure dbo.SP_SelectAllActiveTaskItems
as 
begin
Select T.TaskId,
TP.TaskPriorityId,
Tc.TaskCategoryId,
T.TaskTitle, 
T.TaskDescription, 
T.IsCompleted, 
T.Deadline,
TC.[Category],
Tp.[Priority] 
from Tasks T
left outer join TaskCategory TC
on T.TaskCategoryId=tc.TaskCategoryId
Left outer join TaskPriority TP
on T.TaskPriorityId = Tp.TaskPriorityId
where T.isActive=1 and T.IsCompleted=0
end