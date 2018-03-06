# Howdy API Documentation
> These pages contains samples and specifications on how to integrate Howdy with HR-systems in order to maintain employee data

## Endpoints

- Production endpoint: https://api-ne1.worklifebarometer.com/

## Security
All calls to the API must be authenticated by presenting a valid JWT ([JSON Web Token](https://jwt.io/)).

To obtain the token do the following:
- Access "My worklife barometer" on https://my.worklifebarometer.com/
- Navigate to Company > Integrations and "Turn on external integration"
- "Turn on automatic integration" and set the max difference to 25
- Navigate to Users and look for a user with the name "&lt;CompanyName&gt; API User" (if you don't see it, please contact support at support@worklifebarometer.com)
 - The API user should have the role HRIntegration. Click the three dots and then "Generate new App Token".
 - This should open a dialog box with a newly generated token

The Token can be sent in one of two ways:
- As a HTTP Header: Add it as `Authorization: Bearer <API_TOKEN_HERE>` to each request (as shown below)
- As a Query String parameter: Pass it as `?access_token=<API_TOKEN_HERE>` to each request

## GET /v1.0/Company/{companyId}/Employee
This call returns all employees stored in Howdy, that were created through the API. Employees created through the portal interface will not be included.

### Request
```http
GET /v1.0/company/{companyId}/employee HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## PUT /v1.0/Company/{companyId}/Employee
This call makes a complete set based change of all employees in the system.

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
| Phonenumber       | Cell phone. Unique. String. Must match regex: `^\+[0-9]{6,20}$` E.g. +4523232323                |
| Email*            | E-mail address. Unique.                   |
| Gender            | Gender. Integer. Values: 0 = Male, 1 = Female, 9 = Not known                   |
| EmploymentStatus* | Employment Status. Integer. 0 = Active, 1 = "on leave" e.g. maternity leave etc.  |
| JobTitle         | String. Max length: 50. Must match regex: `^[\p{L} \\\/\-\'\.\,0-9]+$`. E.g. "Sales Manager" or "CEO"     |
| Department       | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Role             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| ImmediateManager | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim1             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim2             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim3             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim4             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim5             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim6             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim7             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim8             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim9             | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |
| Dim10            | Reporting specific data. String. Max length: 50. Must match regex: `^[\p{L} \%\#\$\(\)\&\/\,\.\\0-9\-]+$` |


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
    "Birthday": null,
    "Gender": 9,
    ...
  },
  ...
]
```

### Response

*200 OK*
```json
{
  "ApiOperationId": "string"
}
```

*400 Bad Data*
```json
{
  "ApiOperationId": "string",
 "ValidationErrors": ["string"]
}
``` 
The `ApiOperationId` can be used for further diagnostics so please log this if any errors are returned from the service
 


