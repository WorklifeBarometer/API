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


## Get template by id

>Please find definition of [QuestionConfiguration](./Model/survey-interface.md#questionconfiguration).

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