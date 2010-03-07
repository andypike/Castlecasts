
    create table [User] (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(50) not null,
       LastName NVARCHAR(50) not null,
       Email NVARCHAR(100) not null unique,
       PasswordSalt NVARCHAR(50) not null,
       PasswordHash NVARCHAR(50) not null,
       Token UNIQUEIDENTIFIER null,
       primary key (Id)
    )

    create table Tag (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(50) not null,
       primary key (Id)
    )

    create table EpisodeTag (
        Tag_Id INT not null,
       Episode_Id INT not null
    )

    create table Comment (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(50) not null,
       Email NVARCHAR(255) null,
       CreatedAt DATETIME null,
       Text nvarchar(max) not null,
       Episode INT not null,
       primary key (Id)
    )

    create table Episode (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) not null,
       Description nvarchar(max) not null,
       MovieHTML nvarchar(max) not null,
       InfoHTML nvarchar(max) not null,
       CreatedAt DATETIME not null,
       CreatedBy INT not null,
       primary key (Id)
    )

    alter table EpisodeTag 
        add constraint FK72BE0FC97E425716 
        foreign key (Episode_Id) 
        references Episode

    alter table EpisodeTag 
        add constraint FK72BE0FC936D6F3F7 
        foreign key (Tag_Id) 
        references Tag

    alter table Comment 
        add constraint FKE2466703580584FB 
        foreign key (Episode) 
        references Episode

    alter table Episode 
        add constraint FK5324C13CACD68749 
        foreign key (CreatedBy) 
        references [User]

GO