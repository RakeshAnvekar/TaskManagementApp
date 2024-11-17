
Select T.TaskId, T.TaskTitle, T.TaskDescription, T.IsCompleted, T.Deadline,TC.[Category],Tp.[Priority] from Tasks T
left outer join TaskCategory TC
on T.TaskCategoryId=tc.TaskCategoryId
Left outer join TaskPriority TP
on T.TaskPriorityId =Tp.TaskPriorityId