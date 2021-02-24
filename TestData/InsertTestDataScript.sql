USE [ATMWeb]
GO

INSERT INTO [dbo].[Accounts]
           ([FirstName],[MiddleName],[LastName],[AccountNumber],[AccountPIN],[AccountType],[AccountStatus],[InitialAmountDeposit],[DateCreated])
     VALUES
           ('Sherlee','Dino','Dizon','1560238360','$2a$11$eTgZJ7GA8B8u2cSDCYKdxecNVz9pUicb3/Agd0hvP9g4awImERNki',1,1,2000,getdate()),
		   ('Anna','Luna','Gomez','1234567890','$2a$11$QBEASrk11Tr15X95VPZ36ObnxHTwXJN9iWr6Ktb9A6mdHxJU.r6Fa',2,1,4000,getdate()),
		   ('Mike','Lapid','Depensor','9834567890','$2a$11$KV/zsCJLy/raL/Vv8W5PZeFdoKLIu27q5qtmZDA6mcs9kv5ZLrP3O',2,1,3000,getdate()),
		   ('King','Eman','Dizon','1234567888','$2a$11$kyzpxBDmeZxW4gOec11FTeQ0cVhxG9VEVfyCLsemRA0W0kuolaFN6',1,1,5000,getdate())

GO

--PIN 
--022677
--123456
--060915
--0609

--[AccountType]
-- 1 = Savings
-- 2 = Current

--TransactionTypes
-- 1 - Inquiry
-- 2 - Withdrawal
-- 3 - Deposit