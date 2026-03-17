---
layout: default
title: PUT Manager Import
nav_order: 1
parent: User
grand_parent: Advanced
---

# PUT
This call synchronizes department manager roles for a company.

**URL** : `/v1.0/User/{companyId}/ManagerImport`

**Method** : `PUT`

**Auth required** : YES

**Role:** *HRIntegration*

**Notes**

> The import is treated as the new source of truth for manager roles in the company:
>- Roles present in the request are created or kept enabled
>- Existing manager roles not present in the request are disabled
>- Users with no remaining active roles after the import are locked
>- Locked users included in the request are unlocked

> The request is queued and returns `202 Accepted` when:
>- There is already a pending employee import for the same API user
>- `ManagerRoles` contains **200 or more** entries

> Missing departments are created automatically when `DimensionName` matches one of the company's configured department, division, or project dimensions.

## Request body

The request body is a JSON object with the following properties:

| Field | Type | Requirements | Description |
| ----- | ---- | ------------ | ----------- |
| `ManagerRoles`* | `Array<Object>` | Required | Collection of manager assignments to import |
| `DepartmentHierarchy` | `Object` | Optional | Dictionary of `divisionName: parentDivisionName`. Only used for companies where hierarchy import is enabled |

### ManagerRoles fields

| Field | Type | Requirements | Description |
| ----- | ---- | ------------ | ----------- |
| `DimensionName`* | `String` | Must match a configured department, division, or project dimension | Determines which department type the manager role belongs to |
| `DepartmentName`* | `String` | Required | Department, division, or project name to assign the manager to |
| `FirstName`* | `String` | Required | Manager first name |
| `LastName`* | `String` | Required | Manager last name |
| `Email`* | `String` | Valid email | Used to find or create the portal user |
| `PrimaryContact` | `Boolean` | Optional | Marks the manager as primary contact for the department |
| `DepartmentId` | `Integer` | Optional | Ignored by the import |
| `Guid` | `Guid` | Optional | Ignored by the import |
| `UserId` | `Integer` | Optional | Ignored by the import |
| `RoleType` | `String` | Optional | Ignored by the import. Imported roles are created as department manager roles |

**\*** Required

## Example

```http
PUT /v1.0/User/{companyId}/ManagerImport HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache

{
  "ManagerRoles": [
    {
      "DimensionName": "Division",
      "DepartmentName": "People Operations",
      "FirstName": "Frodo",
      "LastName": "Baggins",
      "Email": "frodo.baggins@example.com",
      "PrimaryContact": true
    },
    {
      "DimensionName": "Department",
      "DepartmentName": "Support",
      "FirstName": "Samwise",
      "LastName": "Gamgee",
      "Email": "samwise.gamgee@example.com",
      "PrimaryContact": false
    }
  ],
  "DepartmentHierarchy": {
    "People Operations": "Corporate Services",
    "Corporate Services": null
  }
}
```

## Success Response

**Code** : `200 OK`

**Content example**

```json
"Successfully created 2, disabled 1 roles and locked 0 users."
```

**Code** : `202 Accepted`

**Content example**

```json
{
  "ApiOperationId": "string",
  "Inserted": 0,
  "Updated": 0,
  "Removed": 0,
  "WasQueued": true
}
```

## Error Response

**Code** : `400 Bad Request`

**Content example**

```json
"Company integration is not allowed"
```

**Code** : `500 Internal Server Error`

Returned if an unexpected error occurs during import.

## Diagnostics

When the request is queued, use [`GET /v1.0/Company/{companyId}/ApiCalls`](../Company/company-apiCalls.md) together with `ApiOperationId` to follow the processing status.
