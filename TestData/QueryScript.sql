select * from [dbo].[Accounts]
select * from [dbo].[AccountTransactions]

-- 3 - Deposit
select * from [dbo].[AccountTransactions] where  TransactionType = 3

-- 2 - Withdrawal
select * from [dbo].[AccountTransactions] where  TransactionType = 2


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