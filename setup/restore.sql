-- Uncomment SETVAR statements and select Query > SQLCMD mode menu option for testing in SSMS
--:SETVAR DatabaseName "TEST"
--:SETVAR BackupDirectoryPath "C:\temp"

declare @DatabaseName varchar(max), @BackupDirectoryPath varchar(max), @DryRun bit, @Sql varchar(max)
set @DatabaseName = '$(DatabaseName)'
set @BackupDirectoryPath = '$(BackupDirectoryPath)'
set @DryRun = 0

-- Get the default data and log directory locations for the current server - only way to do this is
-- to create a new database without specifying file locations, then see where files are created
IF EXISTS(SELECT 1 FROM [master].[sys].[databases] WHERE [name] = '_Temp8789AAA')   
BEGIN  
    DROP DATABASE [_Temp]   
END

-- Create temp database to get default data and log path
CREATE DATABASE [_Temp8789AAA];

DECLARE @DataDirectoryPath varchar(max), @LogDirectoryPath varchar(max);
SELECT @DataDirectoryPath =    
	(SELECT LEFT(physical_name,LEN(physical_name)-CHARINDEX('\',REVERSE(physical_name))+1) 
	FROM sys.master_files mf   
	INNER JOIN sys.[databases] d   
	ON mf.[database_id] = d.[database_id]   
	WHERE d.[name] = '_Temp8789AAA' AND type = 0)

SELECT @LogDirectoryPath =    
	(SELECT LEFT(physical_name,LEN(physical_name)-CHARINDEX('\',REVERSE(physical_name))+1)   
    FROM sys.master_files mf   
    INNER JOIN sys.[databases] d   
    ON mf.[database_id] = d.[database_id]   
    WHERE d.[name] = '_Temp8789AAA' AND type = 1)

DROP DATABASE [_Temp8789AAA]
PRINT '-- Using data directory: ' + @DataDirectoryPath + ' and log directory: ' + @LogDirectoryPath
		
-- Drop
set @Sql = '-- Drop existing db
if exists(select * from sysdatabases where name = ''' + @DatabaseName + ''')
begin
	alter database [' + @DatabaseName + '] set offline with rollback immediate
	alter database [' + @DatabaseName + '] set online
	drop database [' + @DatabaseName + ']
end
'
print @Sql
if @DryRun = 0
	exec(@Sql)
		
-- Restore
declare @BackupFilePath varchar(max), @DataFileLogicalName varchar(max), @LogFileLogicalName varchar(max),
	@DataFilePath varchar(max), @LogFilePath varchar(max)
		
set @BackupFilePath = @BackupDirectoryPath + @DatabaseName + '.bak'
set @DataFileLogicalName = @DatabaseName
set	@LogFileLogicalName = @DatabaseName + '_log'
set	@DataFilePath = @DataDirectoryPath + @DatabaseName + '.mdf'
set	@LogFilePath = @LogDirectoryPath + @DatabaseName + '_log.mdf'				

set @Sql = '-- Restore db
RESTORE DATABASE [' + @DatabaseName + ']
FROM DISK = N''' + @BackupFilePath + '''
WITH MOVE N''' + @DataFileLogicalName + ''' TO N''' + @DataFilePath + ''',
MOVE N''' + @LogFileLogicalName + ''' TO N''' + @LogFilePath + '''
'
print @Sql
if @DryRun = 0
	exec(@Sql)
