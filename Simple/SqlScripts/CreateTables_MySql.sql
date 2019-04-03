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
----insert into customer values (UUID(),'JJ Import');
--Invoice with trigger
create table Invoice(
    Id char(36) not null primary key,
    CustomerId char(36)  
    Foreign Key (CustomerId) references Customer(Id),
    CreatedDateTime datetime,
    UpdatedDateTime datetime
)
----Row creation Trigger 
DELIMITER $$
CREATE TRIGGER Before_Invoice_insert 
    Before INSERT ON Invoice
    FOR EACH ROW 
BEGIN
    Set NEW.CreatedDateTime=Now(),New.UpdatedDateTime=Now();
END$$
DELIMITER ;

------insert into Invoice (Id,CustomerId) values (uuid(),'bf947fee-5606-11e9-9399-62cacb9daf94');
----Row update Trigger
DELIMITER $$
CREATE TRIGGER Before_Invoice_update
    Before Update ON Invoice
    FOR EACH ROW 
BEGIN
    Set New.UpdatedDateTime=Now();
END$$
DELIMITER ;