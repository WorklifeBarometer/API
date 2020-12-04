---
layout: default
title: GET Survey by Company
parent: Survey
grand_parent: Advanced
---


# GET
Get all surveys in company.

**URL** : `/v1.0/Survey?companyId={companyId}`

**Method** : `GET`

**Auth required** : YES

## Example

``` http
GET /v1.0/survey?companyId={companyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

``` json
[
    {
        "companyId": "integer",
        "end": "DateTime",
        "id": "integer",
        "name": "string",
        "start": "DateTime",
        "state": "integer",
        "surveyDefinitionId": "integer"
    }    
]
```

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```