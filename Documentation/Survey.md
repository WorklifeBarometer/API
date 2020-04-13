# Survey API Documentation
> This page contains specifications of Survey API. For information on endpoints, security and more general information, please visit the [main page](./Index.md).

## GET v1.0/Survey?companyId={companyId}

### Request
```http
GET /v1.0/Survey?companyId={companyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response
```json
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

## GET v1.0/Survey/{surveyId}

### Request
```http
GET /v1.0/Survey/{surveyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response
```json
[
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
]
```
Please find definition of [QuestionConfiguration](#questionconfiguration) and [SurveySelectionRule](#surveyselectionrule).

## GET v1.0/Survey/Templates

### Request
```http
GET /v1.0/Survey/Templates HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response
```json
[
    {
        "id": "integer",
        "name": "string"
    }
]
```

## GET v1.0/Survey/Template/{templateId}

### Request
```http
GET /v1.0/Survey/Template/{templateId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response
```json
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
Please find definition of [QuestionConfiguration](#questionconfiguration).


## Interfaces

### QuestionConfiguration
```json
{
	"AnswerOptions": [
		{
			"LabelKey": "string",
			"Value": "integer"
		}
	]
}
```

### SurveySelectionRule
```json
{
	"Frequency": "Hourly" | "Monthly" | "Quarterly" | "Continuous",
	"EnabledLanguages": [
		{
			"id": "integer",
			"label": "string",
			"code": "string"
		}
	]
}
```
Please find list of all enabled languages [here](./Index.md#get-v1.0/Company/{companyId}/Language/Enabled).

### QuestionTexts
QuestionText is JSON object where key is language id and value is text.

Example:
```json
{
	"1045": "Simple question text in English",
	"1041": "Enkel spørgsmålstekst på dansk"
}
```
