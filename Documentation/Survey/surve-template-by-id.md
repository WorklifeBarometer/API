---
layout: default
title: GET Survey Template By Id
parent: Survey
grand_parent: Advanced
---


# GET
Please find definition of [QuestionConfiguration](./survey-interface.md#questionconfiguration).

**URL** : `v1.0/Survey/Template/{templateId}`

**Method** : `GET`

**Auth required** : YES

## Example

``` http
GET /v1.0/survey/template/{templateId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

``` json
[
    {
        "name": "string",
        "questions": [
          {
            "order": "integer",
            "key": "string",
            "type": "integer",
            "configuration": "QuestionConfiguration JSON string or null"
          }
        ],
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