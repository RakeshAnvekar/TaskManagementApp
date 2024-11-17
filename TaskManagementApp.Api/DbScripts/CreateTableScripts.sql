--Create Db Scripts starts here---
Create Database TaskManagementDb
Go
use TaskManagementDb



--Create Table Scripts starts here--
 create Table TaskPriority(
  TaskPriorityId INT IDENTITY(1,1) PRIMARY KEY,
  [Priority] varchar(100) not null
  )


  Create Table TaskCategory(
  TaskCategoryId INT IDENTITY(1,1) PRIMARY KEY,
  [Category] varchar(100) not null
  )

 

  Create Table Tasks (
  TaskId INT IDENTITY(1,1) PRIMARY KEY,
  TaskTitle varchar(200) not null,
  TaskDescription varchar(MAX) not null,
  IsCompleted bit not null,
  Deadline datetime not null,
  TaskCategoryId int not null,
  isActive bit,
  Foreign key(TaskCategoryId) references TaskCategory(TaskCategoryId),
  TaskPriorityId int not null,
  Foreign key(TaskPriorityId) references TaskPriority(TaskPriorityId)
  )

 

