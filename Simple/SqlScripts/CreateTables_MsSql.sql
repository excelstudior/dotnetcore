create table city (
	Id int primary key,
	Name nvarchar(50),
	[Description] nvarchar(200)
)

create table PointOfInterest (
	Id int primary key,
	Name nvarchar(50),
	[Description] nvarchar(200),
	CityId int Foreign Key references City(Id)
)
create table Customer (
	Id uniqueidentifier primary key,
	Name nvarchar(100) Unique
)