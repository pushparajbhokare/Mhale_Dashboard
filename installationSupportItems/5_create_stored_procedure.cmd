@echo off
:: make sure the table name is entered in the create_checkSheet_table.sql
Sqlcmd -S 127.0.0.1,1433 -U user -P password -i .\DatabaseSript.sql
::
set /p "input=Please take Screenshot of the prompt if error present above and then press enter to close the script" 
:: ref >> :: https://learn.microsoft.com/en-us/sql/ssms/scripting/sqlcmd-connect-to-the-database-engine?view=sql-server-ver16