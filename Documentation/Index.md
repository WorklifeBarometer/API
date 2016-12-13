# Howdy API Documentation
> These pages contains samples and specifications on how to integrate Howdy with HR-systems in order to main employee data

## Intro

## Endpoints

- Test endpoint: wlb-uat-ne1-api.azurewebsites.net 
- Production endpoint: ne1-api.worklifebarometer.com

## Security
All calls to the API must be authenticated by a JWT (JSON Web Token).
The Token can be set in one of two ways:
- As a HTTP Header: Add is as `Authorization: Bearer <API_TOKEN_HERE>` to each request
- As a Query String parameter: Pass it as `?access_token=<API_TOKEN_HERE>` to each request

The token itself will be issued by a Portal Administrator

## GET /v1.0/Company/{companyId}/Employee
This call returns all Employees stored in Howdy.
### Request
```http
GET /v1.0/company/1057/employee HTTP/1.1
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

| Field            | Description        |
| ---------------- | ------------------ |
| EmployeeID       |                    |
| InvitationDate   |                    |
| Firstname        |                    |


### Request
```http
PUT /v1.0/company/1057/employee HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
[
  {
    "Phonenumber": "+00008462",
    "Email": "8462@dev.test",
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
 


