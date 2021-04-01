CREATE DATABASE Project1;
USE Project1;

CREATE TABLE ACustomer( 
ID int NOT NULL,
FName varChar(50),
LName varchar(50),
PRIMARY KEY (ID));

CREATE TABLE AStore( 
ID int NOT NULL,
StoreName varchar(50),
PRIMARY KEY (ID));

Create Table AnItem(
ID int Not Null,
ItemName varchar(50),
Price decimal(10,2),
Primary Key(ID));

Create Table InventoryDetail(
InventoryID int,
StoreID int,
ItemID int,
Amount int,
Primary Key(InventoryID),
FOREIGN KEY (StoreID) References Astore(ID),
FOREIGN KEY (ItemID) References AnItem(ID)
);

Create Table AOrder(
OrderID int,
CustomerID int,
StoreID int,
OrderTime DateTime,
Total Decimal(10,2),
Primary Key(OrderID),
FOREIGN KEY (CustomerID) References ACustomer(ID),
FOREIGN KEY (StoreID) References AStore(ID));

Create Table AOrderDetail(
ID int,
OrderID int,
ItemID int,
Total Decimal(10,2),
Primary Key(ID),
FOREIGN KEY(OrderID) References AOrder(ORDERID),
FOREIGN KEY(ItemID) References AnItem(ID));

Create Table AnItemDetail(
ID int,
Descript varChar(1000),
SrcImg varChar(1000),
Primary Key(ID),
Foreign Key(ID) references AnItem(ID)
)
Create table AStoreDetail(
ID int,
Descript varChar(1000),
SrcImg varChar(1000),
Primary Key(ID),
Foreign Key(ID) references AStore(ID)
)