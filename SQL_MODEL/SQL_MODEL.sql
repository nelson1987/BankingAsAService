/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT * FROM [DB_BAAS].[dbo].[TB_CLIENTE]
--SELECT * FROM [DB_BAAS].[dbo].[TB_CONTA]
--SELECT * FROM [DB_BAAS].[dbo].[TB_CONTA_CLIENTE]
--SELECT * FROM [DB_BAAS].[dbo].[TB_EMPRESA]
--SELECT * FROM [DB_BAAS].[dbo].[TB_TRANSACAO]
USE [DB_BAAS]
DECLARE @sql varchar(max) = ''
DECLARE @stringToFind AS VARCHAR(100) = '770'
DECLARE @sqlCommand AS VARCHAR(max) = ''

SELECT @sqlCommand = @sqlCommand + COLUMN_NAME+' LIKE ''%' + @stringToFind + '%'' OR '
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'TB_TRANSACAO' 
AND DATA_TYPE IN ('char','nchar','ntext','nvarchar','text','varchar', 'numeric')
SET @sqlCommand = left(@sqlCommand,len(@sqlCommand)-3)
PRINT @sqlCommand


SET @sql = @sql +'SELECT 
	* 
FROM 
	[DB_BAAS].[dbo].[TB_TRANSACAO]
WHERE ' +@sqlCommand
+' ORDER BY
	DTA_TRANSACAO'

PRINT @sql
EXEC(@sql)