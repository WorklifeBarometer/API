---
layout: default
title: GET Enabled Language
nav_order: 2
parent: Company
---

# Enabled Language

**URL** : `/v1.0/Company/{companyId}/Language/Enabled`

**Method** : `GET`

**Auth required** : YES

## Example

```http
GET /v1.0/Company/{companyId}/Language/Enabled HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

```json
[
    {
        "id": "integer",
        "label": "string",
        "code": "string"
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