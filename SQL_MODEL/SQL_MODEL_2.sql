/****** Script for SelectTopNRows command from SSMS  ******/
/*
SELECT TOP 1000 [IDT_TRANSACTION]
      ,[IDT_CONTA]
      ,[DTA_TRANSACAO]
      ,[VLR_TRANSACAO]
      ,[DTA_AGENDAMENTO]
      ,[BANCO_CONTRAPARTE]
      ,[AGENCIA_CONTRAPARTE]
      ,[CONTA_CONTRAPARTE]
      ,[DOCUMENTO_CONTRAPARTE]
  FROM

   */
   DECLARE @TOTAL AS INT 
   SET @TOTAL = 1
   WHILE @TOTAL < 999
   BEGIN
   PRINT 'ALGUMA COISA '+CONVERT(varchar(3), @TOTAL)
  INSERT INTO
   [DB_BAAS].[dbo].[TB_TRANSACAO]
  SELECT 2, 
DATEADD(d,(FLOOR(RAND() * (10 - 1 + 1)) + 1) -1, GETDATE()), 
CONVERT(numeric(18,2),FLOOR(RAND() * (1000 - 1 + 1)) + 1),
NULL, 
CONVERT(varchar(3),FORMAT(FLOOR(RAND() * (999 - 1 + 1)) + 1,'000')),
CONVERT(varchar(4),FORMAT(FLOOR(RAND() * (9999 - 1 + 1)) + 1,'0000')), 
CONVERT(varchar(10),FORMAT(FLOOR(RAND() * (9999999999 - 1 + 1)) + 1,     '0000000000')), 
CONVERT(varchar(14),FORMAT(FLOOR(RAND() * (99999999999999 - 1 + 1)) + 1, '00000000000000'))

   SET @TOTAL = @TOTAL +1
   END
