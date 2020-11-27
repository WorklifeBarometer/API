---
layout: default
title: GET
nav_order: 1
parent: Template
grand_parent: Survey
---


# GET 
Get all survey templates available

**URL** : `/v1.0/survey/templates`

**Method** : `GET`

**Auth required** : YES

## Example

``` http
GET /v1.0/survey/templates HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

``` json
[
    {
        "id": "integer",
        "name": "string"
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