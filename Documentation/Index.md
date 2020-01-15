# Howdy API Documentation
> These pages contains samples and specifications on how to integrate Howdy with HR-systems in order to maintain employee data

## Endpoints

- Test endpoint: https://wlb-uat-ne1-api.azurewebsites.net/
- Production endpoint: https://api-ne1.worklifebarometer.com/

## Security
All calls to the API must be authenticated by presenting a valid JWT ([JSON Web Token](https://jwt.io/)).

To obtain the token do the following:
- Access the Howdy Dashboard on one of the following urls:
    - Production: https://dashboard.worklifebarometer.com/
    - Test: https://auth.worklifebarometer.com > Choose the test environment
- Navigate to Company > Integrations and "Turn on external integration"
- "Turn on automatic integration" and set the max difference to 25
- Navigate to Users and look for a user with the name "&lt;CompanyName&gt; API User" (if you don't see it, please contact support at support@worklifebarometer.com)
 - The API user should have the role HRIntegration. Click the three dots and then "Generate new App Token".
 - This should open a dialog box with a newly generated token and your company id

The Token can be sent in one of two ways:
- As a HTTP Header: Add it as `Authorization: Bearer <API_TOKEN_HERE>` to each request (as shown below)
- As a Query String parameter: Pass it as `?access_token=<API_TOKEN_HERE>` to each request

## GET /v1.0/Company/{companyId}/Employee
This call returns all employees stored in Howdy, that were created through the API. Employees created directly in the dashboard interface will not be included.

### Request
```http
GET /v1.0/company/{companyId}/employee HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## PUT /v1.0/Company/{companyId}/Employee
This call makes a complete set based change of all employees in the system. Large requests may be put on a queue, as processing can take a while. To monitor such queued requests use the api calls action (see below).

>If employee A, B and C exists in Howdy and employee B, C and D are sent via this call then:
>- A will be removed
>- B and C will be updated with the values provided
>- D will be added

#### Data model

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| EmployeeID*       | Your internal primary key. Unique. String. Max length: 50                    |
| InvitationDate    | Date and time when an invitation should be sent out. Only for new employees. If obmitted then then invitation will be sent immediately or at 8 o'clock if outside business hours. String. yyyy-MM-ddTHH:mm:ssZ        |
| Firstname*        | Firstname of the employee. String. Max length: 150. Must match Regex: ``^[\p{L} \-\'\´\`\.0-9]+$`` |
| Lastname*         | Lastname of the employee. String. Max length: 150. Must match Regex: ``^[\p{L} \-\'\´\`\.0-9]+$`` |
| Birthday          | Optional birthday of the employee, specified as YYYY-MM-DD
| Phonenumber       | Cell phone. Unique. String. Must match regex: `^\+[0-9]{6,20}$` E.g. +4523232323                |
| Email*            | E-mail address. Unique. In order to maintain the anonymity of employees, this cannot be changed through the API after it is first created. Only the employee and howdy support can change it.                 |
| Gender            | Gender. Integer. Values: 0 = Male, 1 = Female, 9 = Not known                   |
| EmploymentStatus* | Employment Status. Integer. 0 = Active, 1 = "on leave" e.g. maternity leave etc.  |
| JobTitle          | String. Max length: 50. Must match regex: `^[\p{L} \\\/\-\'\.\,0-9]+$`. E.g. "Sales Manager" or "CEO"     |
| HRContact         | String. Max length: 50. Must match regex: `^[\p{L} \\\/\-\'\.\,0-9]+$`. E.g. "Sales Manager" or "CEO"     |
| HealthOffer       | String. Max length: 50. Must match regex: `^[\p{L} \\\/\-\'\.\,0-9]+$`. E.g. "Sales Manager" or "CEO"     |
| Department        | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Role              | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| ImmediateManager  | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dimensions        | Sub-structure with customer-specific data |
| {Dimension1}      | Reporting specific data. Eg. Location, Division, etc. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| {Dimension2}      | Reporting specific data. Eg. Location, Division, etc. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| ...               | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |


### Request
The request consists of an array of Employees based on the model described above.
```http
PUT /v1.0/company/{companyId}/employee HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
[
  {
    "EmployeeID": "eb8a4f10-1c24-409f-b680-92ae71253339",
    "Firstname": "Bilbo",
    "Lastname": "Baggins"
    "Email": "8462@dev.test",
    "EmploymentStatus": 0,
    "Phonenumber": "+00008462",
    "Gender": 9,
    "Dimensions": {
        "Location": "The Shire",
        "Division": "Hobbits"
    }
  },
  ...
]
```

### Response

*200 OK*
```json
{
  "ApiOperationId": "string",
  "Inserted": "integer",
  "Updated": "integer",
  "Removed": "integer",
  "WasQueued": "false"
}
```

*202 Accepted*
```json
{
  "ApiOperationId": "string",
  "Inserted": 0,
  "Updated": 0,
  "Removed": 0,
  "WasQueued": "true"
}
```

*400 Bad Data*
```json
{
  "ApiOperationId": "string",
 "ValidationErrors": ["string"]
}
```

## GET v1.0/Company/{companyId}/ApiCalls

### Request
```http
GET /v1.0/company/{companyId}/apicalls HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response
```json
[
    {
        "ApiOperationId": "GUID",
        "UserId": "integer",
        "Username": "string",
        "CreatedOn": "DateTime",
        "Method": "string",
        "HttpStatusCode": "integer",
        "HttpStatusReason": "string"
    },
    ...
]
```

The lifetime of a queued request is a follows:
1. Created. `HttpStatusCode` and `HttpStatusReason` will be empty
2. Validated and queued. `HttpStatusCode` will be `202` and `HttpStatusReason` will be `Accepted`. If validation fails, the request will immediately change status to 4xx if it is deemed to be a problem with the data or 5xx if an unexpected problem has happened on the server.
3. Processing started. `HttpStatusCode` will remain `202` and `HttpStatusReason` will change to `Processing...`.  Usually processing will start within a couple of minutes, but if the server is busy it could take up to an hour.
4. Processing completed. `HttpStatusCode` will change to `200` if everything went okay. If not, the code and reason should provide some explanation.
