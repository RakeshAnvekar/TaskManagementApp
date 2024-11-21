--1	Personal
--2	Work
--3	Fitness
--4	Household
--5	Learning
use TaskManagementDb
insert into dbo.TaskCategory values('Personal')
insert into dbo.TaskCategory values('Work')
insert into dbo.TaskCategory values('Fitness')
insert into dbo.TaskCategory values('Household')
insert into dbo.TaskCategory values('Learning')

--1	Low
--2	Medium
--3	High

insert into  dbo.TaskPriority values('Low');
insert into  dbo.TaskPriority values('Medium');
insert into  dbo.TaskPriority values('High');
--1	"Buy groceries"	"Milk, eggs, bread, and vegetables"	0	2024-11-18 17:00:00	1	2
--2	"Finish project"	"Complete the task management project"	0	2024-11-20 23:59:59	2	3
--3	"Read a book"	"Read 'The Catcher in the Rye'	1	2024-11-16 20:00:00	1	1
--4	"Workout"	"30 minutes of cardio and strength training"	1	2024-11-16 08:00:00	3	2
--5	"Call mom"	"Check in with mom and chat for a while"	0	2024-11-17 19:00:00	1	1
--6	"Learn React"	"Complete React tutorial on freeCodeCamp"	0	2024-11-18 14:00:00	5	3
--7	"Plan vacation"	"Research flights and hotels for a summer vacation in Paris"	0	2024-12-01 23:59:59	2	2
--8	"Clean the house"	"Vacuum, mop, and dust all rooms in the house"	0	2024-11-19 12:00:00	4	1
--9	"Take out the trash"	"Take the trash bins to the curb"	1	2024-11-16 07:30:00	4	1
--10	"Attend meeting"	"Meeting with the team at 10 AM to discuss project updates"	0	2024-11-17 10:00:00	2	3

  INSERT INTO Tasks (TaskTitle, TaskDescription, IsCompleted, Deadline, TaskCategoryId, TaskPriorityId,isActive) VALUES
( 'Buy groceries', 'Milk, eggs, bread, and vegetables', 0, '2024-11-18 17:00:00', 1, 2,1),
( 'Finish project', 'Complete the task management project', 0, '2024-11-20 23:59:59', 2, 3,1),
( 'Read a book', 'Read ''The Catcher in the Rye''', 1, '2024-11-16 20:00:00', 1, 1,1),
( 'Workout', '30 minutes of cardio and strength training', 1, '2024-11-16 08:00:00', 3, 2,1),
( 'Call mom', 'Check in with mom and chat for a while', 0, '2024-11-17 19:00:00', 1, 1,1),
('Learn React', 'Complete React tutorial on freeCodeCamp', 0, '2024-11-18 14:00:00', 5, 3,1),
('Plan vacation', 'Research flights and hotels for a summer vacation in Paris', 0, '2024-12-01 23:59:59', 2, 2,1),
('Clean the house', 'Vacuum, mop, and dust all rooms in the house', 0, '2024-11-19 12:00:00', 4, 1,1),
('Take out the trash', 'Take the trash bins to the curb', 1, '2024-11-16 07:30:00', 4, 1,1),
( 'Attend meeting', 'Meeting with the team at 10 AM to discuss project updates', 0, '2024-11-17 10:00:00', 2, 3,1);


insert into UserType values('Admin',1);
insert into UserType values('Registered User',1);
insert into UserType values('Guest User',1);


insert into [User] values('Rakesh','Rakesh@gmail.com','Rakesh@123','Rakesh@123',GETDATE(),1,1)
insert into [User] values('Deeksha','Deeksha@gmail.com','Deeksha@123','Deeksha@123',GETDATE(),2,1)
insert into [User] values('Roshan','Roshan@gmail.com','Roshan@123','Roshan@123',GETDATE(),3,1)




