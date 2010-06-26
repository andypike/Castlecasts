	create table Submission (
       Id INT IDENTITY NOT NULL,
	   [Name] NVARCHAR(255) not null,
	   Email NVARCHAR(255) not null,
       Title NVARCHAR(255) not null,
       Description nvarchar(max) not null,
       MovieHTML nvarchar(max) not null,
       ExtraInfo nvarchar(max) null,
       CreatedAt DATETIME not null,
	   [Status] int default(0) not null,
       primary key (Id)
    )

GO