

DECLARE @PageNumber AS INT
DECLARE @RowsOfPage AS INT
DECLARE @SortingCol AS VARCHAR(100) ='DTA_TRANSACAO'
DECLARE @SortType AS VARCHAR(100) = 'DESC'
DECLARE @SearchText AS varchar(255) = '327'
SET @PageNumber=1
SET @RowsOfPage=8
DECLARE @TableName nvarchar(256) = 'TB_TRANSACAO';
--PRIVATE
DECLARE @offsetNumber AS VARCHAR(10) = (@PageNumber-1)*@RowsOfPage
DECLARE @rowNumber AS VARCHAR(10) = @RowsOfPage
DECLARE @filter nvarchar(max) = '';
DECLARE @colunas nvarchar(max) = '';
SET @colunas =	'IDT_TRANSACTION,'+
				'IDT_CONTA,'+
				'DTA_TRANSACAO,'+
				'VLR_TRANSACAO,'+
				'DTA_AGENDAMENTO,'+
				'BANCO_CONTRAPARTE,'+
				'AGENCIA_CONTRAPARTE,'+
				'CONTA_CONTRAPARTE,'+
				'DOCUMENTO_CONTRAPARTE'

SELECT @filter = @filter + COLUMN_NAME+' LIKE ''%' + @SearchText + '%'' OR '
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = @TableName
AND DATA_TYPE IN ('char','nchar','ntext','nvarchar','text','varchar', 'numeric')
SET @filter = left(@filter,len(@filter)-3)
PRINT @filter


DECLARE @sql nvarchar(max) = '';
SET @sql ='SELECT '+ @colunas + 
' FROM '+ @TableName + 
' WHERE ' + @filter + 
' ORDER BY '+ CONCAT(@SortingCol, ' ', @SortType) +
' OFFSET '+ @offsetNumber +' ROWS FETCH NEXT '+ @rowNumber +' ROWS ONLY'


--DTA_TRANSACAO	VLR_TRANSACAO	DTA_AGENDAMENTO	BANCO_CONTRAPARTE	AGENCIA_CONTRAPARTE	CONTA_CONTRAPARTE	DOCUMENTO_CONTRAPARTE

--PRINT @sql
--EXEC(@sql)
