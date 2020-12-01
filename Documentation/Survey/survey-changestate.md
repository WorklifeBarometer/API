---
layout: default
title: POST Change survey state
parent: Survey
grand_parent: Advanced
---


# POST
Change state of survey ids included in request payload as an array of integers.
Please find all possible survey states [here](./survey-enum.md#SurveyState).

**URL** : `/v1.0/Survey/ChangeState/{surveySate}`

**Method** : `POST`

**Auth required** : YES

## Example

``` http
POST /v1.0/Survey/ChangeState/{surveySate} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
[100, 101, 102]
```

## Success Response

**Code:** `200 OK`

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```
