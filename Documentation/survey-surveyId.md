# Get survey by Id

>Please find definition of [QuestionConfiguration](./survey-interfaces.md#questionconfiguration) and [SurveySelectionRule](./survey-interfaces.md#surveyselectionrule).

**URL** : `/v1.0/survey/{surveyId}`

**Method** : `GET`

**Auth required** : YES

## Example

``` http
GET /v1.0/survey/{surveyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

``` json
{
	"end": "DateTime",
	"id": "integer",
	"name": "string",
	"questions": [
		{
		"order": "integer",
		"key": "string",
		"type": "integer",
		"configuration": "if type == 2 then QuestionConfiguration JSON string, else null"
		}
	],
	"start": "DateTime",
	"state": "integer",
	"surveyDefinitionId": "integer",
	"surveySelectionRule": "SurveySelectionRule JSON string"
}
```

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```