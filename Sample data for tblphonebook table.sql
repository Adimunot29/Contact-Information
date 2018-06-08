//Sample data

USE [PhoneBookDB]
GO

SET IDENTITY_INSERT tblphonebook ON
GO
Insert into dbo.[tblphonebook] ([ContactID], [FirstName], [LastName], [PhoneNumber], [Email], [Status]) values (1, 'Mark', 'Hastings', 9876543210, 'Mark@gmail.com', 'Active');
Insert into  dbo.[tblphonebook] ([ContactID], [FirstName], [LastName], [PhoneNumber], [Email], [Status]) values (2, 'Steve', 'Pound', 9876543210, 'Steve@gmail.com', 'Inactive');
Insert into  dbo.[tblphonebook] ([ContactID], [FirstName], [LastName], [PhoneNumber], [Email], [Status]) values (3, 'Ben', 'Hoskins', 9876543210, 'Ben@gmail.com', 'Inactive');
Insert into  dbo.[tblphonebook] ([ContactID], [FirstName], [LastName], [PhoneNumber], [Email], [Status]) values (4, 'Philip', 'Hastings', 9876543210, 'Philip@gmail.com', 'Active');
SET IDENTITY_INSERT tblphonebook OFF
GO