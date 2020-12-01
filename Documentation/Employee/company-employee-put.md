---
layout: default
title: PUT
nav_order: 2
parent: Employee
grand_parent: Advanced
---

# PUT
This call makes a complete set based change of all employees in the system.

**URL** : `/v1.0/Company/{companyId}/Employee`

**Method** : `PUT`

**Auth required** : YES

**Role:** *HRIntegration*

**Note**

> If employee `[A, B, C]` exists in Howdy and employee `[B, C, D]` are sent via this call then:
>- **A** will be removed
>- **B** and **C** will be updated with the values provided
>- **D** will be added

**Data constraints**

| Field                | Type      | Requirements                                      | Description                                                     |
| -------------------- | --------- | ------------------------------------------------- | --------------------------------------------------------------- |
| `EmployeeID`\*       | `String`  | `Unique`, *Max length:* **50**                    | Your internal primary key                                       |
| `InvitationDate`\*\* | `String`  | *Format:* `yyyy-MM-ddTHH:mm:ssZ`                  | Date and time when to sent out invitation                       |
| `Firstname`\*        | `String`  | *Max length:* **150**                             | Firstname of the employee                                       |
| `Lastname`\*         | `String`  | *Max length:* **150**                             | Lastname of the employee                                        |
| `Phonenumber`        | `String`  | *Must match regex:* `^\+[0-9]{6,20}$`, `Unique`   | Cell phone E.g. +4523232323                                     |
| `Email`\*            | `String`  | Valid email, `Unique`                             | E-mail address                                                  |
| `Gender`             | `Integer` | `0` = **Male**, `1` = **Female**, `9` = **Unknown**| Gender                                                         |
| `EmploymentStatus`\* | `Integer` | `0` = **Active**,  `1` = **On leave**             | Employment Status                                               |
| `JobTitle`           | `String`  | *Max length:* **50**                              | Users Role in the company. E.g. "Sales Manager" or "CEO"        |
| `Department`         | `String`  | *Max length:* **50**                              | Reporting specific data                                         |
| `Role`               | `String`  | *Max length:* **50**                              | Reporting specific data                                         |
| `ImmediateManager`   | `String`  | *Max length:* **50**                              | Reporting specific data                                         |
| `Dimensions`         | `Object`  | Key-Value pair, Value *Max length:* **50**        | Other reporting specific data Eg. Location, Division            |


**\*** Required

**\*\*** InvitationDate
- Only for new employees. 
- If obmitted then then invitation will be sent immediately or at 8 o'clock if outside business hours

## Example
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
    "Dimensions": {
        "Location": "The Shire",
        "Division": "Hobbits"
    }
    ...
  },
  ...
]
```

## Success Response

**Code** : `200 OK`

**Content example**

``` json
{
  "ApiOperationId": "string",
  "Inserted": "integer",
  "Updated": "integer",
  "Removed": "integer",
  "WasQueued": "false"
}
```

**Code** : `202 Accepted`

**Content example**

```json
{
  "ApiOperationId": "string",
  "Inserted": 0,
  "Updated": 0,
  "Removed": 0,
  "WasQueued": "true"
}
```

## Error Response

**Code** : `400 Bad Data`

**Content example**

``` json
{
  "ApiOperationId": "string",
  "ValidationErrors": ["string"]
}
```

**Note**

The `ApiOperationId` can be used for further diagnostics so please log this if any errors are returned from the service

 
