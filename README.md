##What is in the project

There are 2 folders as mentioned on the pdf UmbracoCms and UmbracoBridge

##UmbracoCms

- It's configured to use SQlite you need to place the db into the following folder /UmbracoCms/umbraco/Data/yourdb.db
- After that just need to execute dotnet build and then dotnet run in order to run umbraco
- Follow steps to setup your user. When finished don't forget to create and apiUser
- Take notes of the clientId and clientSecret created since this will be used on the other project.

#UmbracoBridge

- As in the other project you need to setup the following values into appsettings.json file with the following schema
  "ApiCredentials": {
    "baseUrl": "baseurl",//example "https://localhost:44336"
    "clientId": "your-client-id",
    "clientSecret": "your-client-secret"
  }
- After that just run dotnet build and the dotnet run to have the project running.
- To see the available endpoints just execute the following url: https://localhost:7239/openapi/v1.json //the port may change in your computer
