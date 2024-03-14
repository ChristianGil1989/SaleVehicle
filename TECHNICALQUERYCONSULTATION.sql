USE [SaleVehicle]
GO

INSERT INTO [dbo].[TemporalOders]
           ([UserId]
           ,[VehicleId]
           ,[OrderStatus]
           ,[Value]
           ,[Remarks]
		   ,[Date])
     VALUES
           ((SELECT ID FROM [dbo].[AspNetUsers] WHERE [IdentificationNumber] = '012345678')
           ,1
           ,1
           ,250000
           ,''
		   ,SYSDATETIME()),
		   ((SELECT ID FROM [dbo].[AspNetUsers] WHERE [IdentificationNumber] = '123456789')
           ,2
           ,1
           ,350000
           ,''
		   ,SYSDATETIME())

SELECT 
	CONCAT(Users.Name,' ',Users.LastName) AS nombreComprador,
	Torders.Value,
	Torders.Date,
	Torders.OrderStatus,
	Vehicle.Model
FROM 
	[dbo].[TemporalOders] AS Torders
INNER JOIN [dbo].[AspNetUsers] AS Users
ON Users.Id = Torders.UserId
INNER JOIN [dbo].[Vehicles] AS Vehicle
ON Vehicle.Id = Torders.VehicleId
WHERE Users.[Id] = (SELECT ID FROM [dbo].[AspNetUsers] WHERE [IdentificationNumber] = '012345678')
AND Vehicle.Id = 1
