# WebScanner-api

WebScanner-api - API for [WebScanner project](https://github.com/KOOPProjects/WebScanner).

#  Version

v0.1.0

#  Goal

Main goal is to serve endpoints for getting responses to specific orders handled by WebScanner. As WebScanner only saves the responses to database, WebScanner-api retrieves responses from that database and serves endpoints at which external services can get responses for specific orders. 

#  Language

C# 7.0

#  Platform

.NET Core 2.1

#  Scope(still open)

* Repository structure in a manner of S. Allen's approach
* C# naming conventions
* Using c# design patterns
* RESTful api design patterns
* JSend JSON response convention
* Readme-driven development

#  Technologies

* PostgreSQL for retrieving responses saved by WebScanner
* RESTful api for serving endpoints for getting responses

#  Application interface

* Getting response for specific order:
 `GET [host]/api/orders?id=ARGUMENT`
ARGUMENT: int orderId

* Getting responses for array of specific orders:
 `GET [host]/api/orders?id=ARGUMENT,ARGUMENT,ARGUMENT,...`
ARGUMENT: int orderId

Example JSON responses:
```
{
    status : "success",
    data : {
        "responses" : [
            { "id" : 1, "orderId" : 13, "dateTime" : "2018-11-05T10:17:00+00:00", "responseContent" : "Some useful content for example" },
            { "id" : 2, "orderId" : 15, "dateTime" : "2018-10-25T16:17:00+00:00", "responseContent" : "More useful content" },
        ]
     }
 } 
```

```
{
    "status" : "error",
    "message" : "Unable to communicate with database"
 } 
```

 #  Solution Structure

 #  Project schedule
