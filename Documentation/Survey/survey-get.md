---
layout: default
title: GET
nav_order: 6
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

# Create a new survey

**URL** : `/v1.0/survey`

**Method** : `POST`

**Auth required** : YES

**Note**
> see [Survey Models](./Model/survey-interface.md)

**Data constraints**

All fields are reguired.

| Field               | Type      | Requirements                                            | Description                                                    |
| ------------------- | --------- | ------------------------------------------------------- | -------------------------------------------------------------- |
| Name\*              | `String`  | Max length: 50                                          | Name of the new survey                                         |
| CompanyId\*         | `Integer` |                                                         | Id of your company                                             |
| Start\*             | `String`  | format: *yyyy-MM-ddTHH:mm:ssZ*                          | Date and time when a new survey starts to be available         |
| End\*               | `String`  | format: *yyyy-MM-ddTHH:mm:ssZ*                          | Date and time when a new survey starts to be unavailable       |
| State\*             | `Integer` |                                                         | Valid value of [SurveyState](./Model/survey-enum.md#surveystate) enum.               |
| SurveySelectionRule | `String`  | [SurveySelectionRule](./Model/survey-interface.md#surveyselectionrule) interface   | JSON of [SurveySelectionRule](./Model/survey-interface.md#surveyselectionrule) interface. |
| Questions\*\*       | `JSON`    | Array of [SurveyQuestion](./Model/survey-interface.md#surveyquestion) type objects | Questions of the new survey.                                   |

**\*** Requried

**\*\***

Each survey must contain Cover page and Thank you page

## Example

``` http
POST /v1.0/survey HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Content-Type: application/json
Cache-Control: no-cache
```

``` json
{
  "Name": "Test Survey",
	"CompanyId": 0,
	"Start": "2020-05-01T02:00:00.000Z",
	"End": "2020-06-01T02:00:00.000Z",
	"State": 2,
	"SurveySelectionRule": "{\"Frequency\":\"Quarterly\",\"EnabledLanguages\":\"[{\"id\":1045,\"label\":\"English\",\"code\":\"en\"}]\",\"Filters\":{\"Manager\":\"GUNNAR\"}}",
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
## Success Response

**Code:** `200 OK`

**Response:** `Integer`

id of the new survey

``` json
1426
```

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```