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

 `GET [host]/api/responses?orderId=ARGUMENT`
 
 or
 
 `GET [host]/api/responses?orderId=ARGUMENT&orderId=ARGUMENT2&orderId=...`
 
required ARGUMENT: int[] orderId

* Finding response by received date and content
`POST [host]/api/responses`

Example POST:
```
{
	"orderIds" : [1,2,3,6,7],
	"dateAfter" : "2016-12-06T12:25:00Z",
	"dateBefore" : "2018-12-06T12:25:00Z",
	"content" : ""
}
```
required ARGUMENT: int[] orderIds - search will be performed only in responses for specified order ids

optional ARGUMENT: DateTime dateAfter - for finding responses received after specified dateAfter argument

optional ARGUMENT: DateTime dateBefore - for finding responses received before specified dateBefore argument

optional ARGUMENT: string content - for finding responses containing specified content



Example JSON responses:
```
{
    "responses": [
        {
            "id": 6,
            "orderId": 6,
            "receivedDateTime": "2017-12-06T12:25:00Z",
            "content": "Sample content for order 6 response"
        },
        {
            "id": 7,
            "orderId": 7,
            "receivedDateTime": "2018-09-17T05:30:00Z",
            "content": "Sample content for order 7 response"
        }
    ],
    "status": "success"
}
```

```
{
  "message": "Unable to communicate with database",
  "status": "error"
}
```

```
{
  "message": "Wrong query parameters format",
  "status": "fail"
}
```

 #  Solution Structure

 #  Project schedule
