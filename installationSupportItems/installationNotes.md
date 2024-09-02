## Installation Steps : 
1. Configure the settings in the following file : 
    1. Configure server port settings in "ServerConfig.json"
    2. Configure db connection settings in 'backendServerApp.dll.config'
        1. set the RefreshInterval rate suitable for production
    3. Set the db name in 'create_checkSheet_table.sql'
    4. run the 'create_table.cmd' file to set the stored procedures
    5. run the script 'create_background_service.cmd' to set the background service
    6. Restart the server to make the QdasT service run automatically 
    7. check the http://localhost:port to validate the running of service