# Survey API Documentation

> This page contains specifications of Survey API. For information on endpoints, security and more general information, please visit the [main page](./Index.md).

## GET v1.0/Survey?companyId={companyId}

Get all surveys in company.

### Request

``` http
GET /v1.0/survey?companyId={companyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response

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

## GET v1.0/Survey/{surveyId}

Get survey by its id.

### Request

``` http
GET /v1.0/survey/{surveyId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response

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

Please find definition of [QuestionConfiguration](#questionconfiguration) and [SurveySelectionRule](#surveyselectionrule).

## GET v1.0/Survey/Templates

Get all survey templates available.

### Request

``` http
GET /v1.0/survey/templates HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response

``` json
[
    {
        "id": "integer",
        "name": "string"
    }
]
```

## GET v1.0/Survey/Template/{templateId}

Get template by id.

### Request

``` http
GET /v1.0/survey/template/{templateId} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

### Response

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

Please find definition of [QuestionConfiguration](#questionconfiguration).

## POST v1.0/Survey

Create new survey.

#### Data model

All fields are reguired.

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Name              | Name of the new survey. String. Max length: 50. Not null.|
| CompanyId         | Id of your company. Integer, not null.					           |
| Start             | Date and time when a new survey starts to be available. String, not null.yyyy-MM-ddTHH:mm:ssZ        |
| End               | Date and time when a new survey starts to be unavailable. String, not null.yyyy-MM-ddTHH:mm:ssZ        |
| State             | Integer, not null. Valid value of [SurveyState](#surveystate) enum.|
| SurveySelectionRule | JSON string of [SurveySelectionRule](#surveyselectionrule) interface.|
| Questions         | Questions of the new survey. Array of [SurveyQuestion](#surveyquestion) type objects. Each survey must contain Cover page and Thank you page.|

### Request

``` http
POST /v1.0/survey HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
{
  "Name": "Test Survey",
	"CompanyId": 0,
	"Start": "2020-05-01T02:00:00.000Z",
	"End": "2020-06-01T02:00:00.000Z",
	"State": 2,
	"SurveySelectionRule": "{"Frequency":"Quarterly","EnabledLanguages":"[{\"id\":1045,\"label\":\"English\",\"code\":\"en\"}]","Filters":{"Manager":"GUNNAR"}}",
	"Questions": [
		{
			"Type": 1,
			"Texts": {
				"1045": "Welcome to the survey about upcoming Christmas party."
			}
		},
		{
			"Type": 3,
			"Texts": {
				"1045": "What is your favorite alcohol?"
			}
		},
		{
			"Type": 99,
			"Texts": {
				"1045": "Thank you for your time."
			}
		}
	]
}
```

### Response

Integer, id of the new survey.

## POST v1.0/Survey/Update

Update existing survey.

#### Data model

All fields from [v1.0/Survey](#post-v1.0/Survey) plus following:

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Id                | Id of the survey. Integer, not null.						               |
| SurveyDefinitionId | Id of corresponding survey definition. Integer, not null. This field is not subject to change. Each survey has fixed survey definition.|

### Request

``` http
POST /v1.0/survey/update HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
{
	"Name": "Test Survey",
	"CompanyId": 0,
	"Start": "2020-05-01T02:00:00.000Z",
	"End": "2020-06-01T02:00:00.000Z",
	"State": 2,
	"SurveySelectionRule": '{"Frequency":"Quarterly","EnabledLanguages":"[{\"id\":1045,\"label\":\"English\",\"code\":\"en\"}]","Filters":{"ImmediateManager":"GUNNAR"}}',
	"Questions": [
		{
			"Type": 1,
			"Texts": {
				"1045": "Welcome to the survey about upcoming Christmas party."
			}
		},
		{
			"Type": 3,
			"Texts": {
				"1045": "What is your favorite alcohol?"
			}
		},
		{
			"Type": 99,
			"Texts": {
				"1045": "Thank you for your time."
			}
		}
	],
	"Id": 0,
	"SurveyDefinitionId": 0
}
```

### Response

200 OK empty response

## POST v1.0/Survey/ChangeState/{surveyState}

Change state of survey ids included in request payload as an array of integers.

Please find all possible survey states [here](#SurveyState).

### Request

``` http
POST /v1.0/Survey/ChangeState/{surveySate} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
 
[100, 101, 102]
```

### Response

200 OK empty response

## Interfaces

### QuestionConfiguration

``` json
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

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Frequency         | How often can survey be answered. Options: "Hourly", "Monthly", "Quarterly", "Continuous".|
| EnabledLanguages  | Array of language objects. Please find list of all enabled languages [here](./Index.md#get-v1.0/Company/{companyId}/Language/Enabled).|
| Filter		    | Object where key is company dimension key and value is desired dimension value. Only one key value pair is supported.|

Example:

``` json
{
	"Frequency": "Hourly",
	"EnabledLanguages": [
		{
			"id": "integer",
			"label": "string",
			"code": "string"
		}
	],
	"Filter": {
		"ImmediateManager": "Nielsen"
	}
}
```

### QuestionTexts

QuestionText is JSON object where key is language id and value is text.

Example:

``` json
{
	"1045": "Simple question text in English",
	"1041": "Enkel spørgsmålstekst på dansk"
}
```

### SurveyQuestion

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Type              | Type of the question. Integer, not null. Valid value of [QuestionType](#questiontype) enum.|
| Texts             | Object of type [QuestionTexts](#questiontexts). Not null.|
| AnswerOptions     | Array of [AnswerOption](#answeroption) type objects. Required when Type == 2.|
| Deleted           | Optional, true when question should be deleted.|

Example:

``` json
{
	"Type": 2,
	"Texts": {
		"1045": "How are you today ?"
	},
	"AnswerOptions": [
		{
			"Texts": {
				"1045": "Great, thanks."
			}
		},
		{
			"Texts": {
				"1045": "Good as always."
			}
		}
	]
}
```

### AnswerOption

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Texts             | Object of type [QuestionTexts](#questiontexts). Not null.					   |

## Enums

### SurveyState
| Value             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| 2                 | Active survey																   |
| 3                 | Inactive survey															   |

### QuestionType

| Value             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| 1                 | Cover page																   |
| 2                 | Question with answer options												   |
| 3                 | Question with text answer													   |
| 99                | Thank you page															   |

