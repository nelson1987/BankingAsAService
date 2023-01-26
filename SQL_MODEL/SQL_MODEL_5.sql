IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'SearchAllColumns'
    AND ROUTINE_TYPE = N'PROCEDURE'
)

DROP PROCEDURE dbo.SearchAllColumns
GO


CREATE PROCEDURE dbo.SearchAllColumns
    @searchValue VARCHAR(1000) 
AS
BEGIN

    CREATE TABLE #output ( 
        SchemaName VARCHAR(500), 
        TableName VARCHAR(500), 
        ColumnName VARCHAR(500), 
        ColumnValue VARCHAR(8000),
        PrimaryKeyColumn VARCHAR(500), 
    )

    SELECT  TABLE_NAME,
            COLUMN_NAME,
            TABLE_SCHEMA,
            'Select top 1 ''' + TABLE_SCHEMA + ''',''' + Table_Name + ''',''' + Column_Name + ''',' 
			+ quotename(COLUMN_NAME) + ' as [ColumnValue] from '+ QUOTENAME(TABLE_SCHEMA) + '.' 
			+ QUOTENAME(TABLE_NAME) + '(nolock) where ' +  quotename(COLUMN_NAME) + ' like ''%' + @searchValue + '%''' AS SQL1
    INTO #Test
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE Data_Type IN ('char','varchar','text','nchar','nvarchar','ntext')

    DECLARE @TABLE_NAME VARCHAR(500)
    DECLARE @COLUMN_NAME VARCHAR(500)
    DECLARE @TABLE_SCHEMA VARCHAR(500)
    DECLARE @SQL1 VARCHAR(max)

    DECLARE db_cursor CURSOR FOR
    SELECT TABLE_NAME,COLUMN_NAME,TABLE_SCHEMA, SQL1
    FROM #test

    OPEN db_cursor
    FETCH NEXT FROM db_cursor INTO @TABLE_NAME, @COLUMN_NAME,@TABLE_SCHEMA,@SQL1

    WHILE @@FETCH_STATUS = 0
    BEGIN
    INSERT INTO #output
    EXEC (@SQL1)

    FETCH NEXT FROM db_cursor INTO @TABLE_NAME, @COLUMN_NAME,@TABLE_SCHEMA,@SQL1
    END

    CLOSE db_cursor
    DEALLOCATE db_cursor

    SELECT * 
    FROM #output

END
GO