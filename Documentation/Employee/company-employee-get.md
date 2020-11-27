# GET
This call returns all employees that were created through the API. Employees created through the portal interface will not be included.

**URL** : `/v1.0/Company/{companyId}/Employee`

**Method** : `GET`

**Auth required** : YES

## Success Response

**Code:** `200 OK`

```json
[
  {
    "Email": "test@example.com",
    "Birthday": null,
    "Gender": 1,
    "ExternalId": "12345678",
    "ContactNumber": null,
    "HomeAddress1": null,
    "HomeAddress2": null,
    "HomeZipCode": "1000",
    "HomeCity": null,
    "HomeCountry": null,
    "LanguageId": 1045,
    "JobTitle": null,
    "HRContact": null,
    "HealthOffer": null,
    "NotifyByEmail": true,
    "NotifyBySMS": false,
    "NotifyByPush": true,
    "Dimensions": {
      "ImmediateManager": "John Doe",
      "Department": "2551",
      "Role": "1",
      "division": "Test"
    },
    "Position": null,
    "ResponseCenterId": null,
    "ResponseCenterName": null,
    "EmploymentStatus": 0,
    "Locked": false,
    "OptOut": false,
    "SourcedFromExternalSystem": true,
    "FirstInvitationDate": "2018-11-15T11:00:16.3627689",
    "EmployedOn": null,
    "Id": 0254799,
    "Firstname": "David",
    "Lastname": "Rasmussen",
    "Fullname": "David Rasmussen",
    "CompanyId": 1000,
    "EmployeeID": "12345678"
  },
  ...
]
```

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```
