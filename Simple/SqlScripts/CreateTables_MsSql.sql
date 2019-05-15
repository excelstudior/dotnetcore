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
	Reference nvarchar(6) Unique,
	Name nvarchar(100) Unique
)
--Invoice with trigger
create table Invoice(
	Id uniqueidentifier primary key,
	CustomerId uniqueidentifier  Foreign Key references Customer(Id),
	CreatedDateTime datetime,
	UpdatedDateTime datetime
)
--insert into Invoice (Id,CustomerId) values (NewID(),'3B7F641A-EE90-4864-A954-06C2C6A9A476')
----Row creation Trigger 
CREATE TRIGGER [dbo].[Invoice_Inserted] ON [dbo].[Invoice]
    AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
                  
    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
    
    DECLARE @Id uniqueidentifier
    DECLARE @DateTime DateTime    
    SELECT @Id = INSERTED.Id
    FROM INSERTED
    SET @DateTime=GETDATE()      
    UPDATE dbo.Invoice
    SET CreatedDateTime=@DateTime
	,UpdatedDateTime =@DateTime
    WHERE Id = @Id
END

----Row update Trigger
CREATE TRIGGER [dbo].[Invoice_UPDATE] ON [dbo].[Invoice]
    AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
                  
    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
    
    DECLARE @Id uniqueidentifier
        
    SELECT @Id = INSERTED.Id
    FROM INSERTED
          
    UPDATE dbo.Invoice
    SET UpdatedDateTime = GETDATE()
    WHERE Id = @Id
END
--End
--If Datebase need to update
	alter table customer add Reference nvarchar(6)
	alter table customer add unique(reference)
--