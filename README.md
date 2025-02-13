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
- Example of the available endpoints the port may change in your computer

GET https://localhost:7239/Healthcheck -> to test Get HealthCheck
POST https://localhost:7239/DocumentType -> to create a document example body, the field collection if of type
  collection {
    "id" : "string"
  } in case you want to add something.
{ 
    "alias": "This is an alias 3", 
    "name": "This is the Name", 
    "description": "This is the description", 
    "icon": "icon-notepad", 
    "allowedAsRoot": true, 
    "variesByCulture": false, 
    "variesBySegment": false, 
    "collection": null, 
    "isElement": true 
} 
DELETE https://localhost:7239/DocumentType/{guid}
