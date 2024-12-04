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

 
 Create Table UserType(
 UserTypeId int identity not null primary key,
 UserType varchar(100) not null,
 Active bit not null
 )

 Create Table [User](
 UserId int not null identity(1,100) primary key,
 UserName varchar(100) not null,
 UserEmailId varchar(100) not null,
 UserPassword varchar(100) not null,
 UserConfirmPassword varchar(100) not null,
 CreatedDate datetime not null,
 UserTypeId int not null,
 IsActive Bit not null,
 IsLoggedIn bit,
 foreign key(UserTypeId) references UserType(UserTypeId)
 )

 CREATE TABLE UnauthorizedRequestLogs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IPAddress NVARCHAR(50),
    Path NVARCHAR(255),
    Method NVARCHAR(10),
    Timestamp DATETIME
);


