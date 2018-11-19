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

 `GET [host]/api/responses?id=ARGUMENT`
 
 or
 
 `GET [host]/api/responses?id=ARGUMENT&id=ARGUMENT2&id=...`
 
ARGUMENT: int[] orderId

* Finding response by received date and optional response content
`POST [host]/api/responses`

Example POST:
```
{
	"dateAfter" : "2015-01-05T09:30:00Z",
	"dateBefore" : "2018-01-05T09:30:00Z",
	"content" : "some content"
}
```
ARGUMENT: DateTime dateAfter - for finding responses received after specified dateAfter argument

ARGUMENT: DateTime dateBefore - for finding responses received before specified dateBefore argument

ARGUMENT: string content - for finding responses containing specified content



Example JSON responses:
```
{
  "data": {
    "responses": [
      {
        "id": 1,
        "orderId": 1,
        "receivedDateTime": "2015-07-05T09:30:00Z",
        "content": "Sample content for order 1 response"
      },
      {
        "id": 2,
        "orderId": 2,
        "receivedDateTime": "2015-08-05T12:20:00Z",
        "content": "Sample content for order 2 response"
      }
    ]
  },
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
