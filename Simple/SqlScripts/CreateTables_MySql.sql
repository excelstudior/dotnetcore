create table city (
    Id int ,
    Name nvarchar(50) not null,        
    primary key (Id),
    Description nvarchar(200) not null
);

create table PointOfInterest (
    Id int primary key,
    Name nvarchar(50) not null,
    Description nvarchar(200) not null,
    CityId int null,
    Foreign Key (CityId) references City(Id)
);
create table Customer (
    Id char(36) not null primary key,
    Name nvarchar(100),
    Unique (Name)
);