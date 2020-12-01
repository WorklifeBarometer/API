---
layout: default
title: POST New Survey
nav_order: 4
parent: Survey
grand_parent: Advanced
---

# POST
Update existing survey

**URL** : `/v1.0/survey`

**Method** : `POST`

**Auth required** : YES

**Note**
see [Survey Models](./survey-interface.md)

**Data constraints**

All fields are reguired.

| Field               | Type      | Requirements                                            | Description                                                    |
| ------------------- | --------- | ------------------------------------------------------- | -------------------------------------------------------------- |
| Id\*                | `Integer` |                                                         | Id of the survey                                               |
| SurveyDefinitionId\*| `Integer` |                                                         | Each survey has fixed survey definition (not subject to change)|
| Name\*              | `String`  | Max length: 50                                          | Name of the new survey                                         |
| CompanyId\*         | `Integer` |                                                         | Id of your company                                             |
| Start\*             | `String`  | format: *yyyy-MM-ddTHH:mm:ssZ*                          | Date and time when a new survey starts to be available         |
| End\*               | `String`  | format: *yyyy-MM-ddTHH:mm:ssZ*                          | Date and time when a new survey starts to be unavailable       |
| State\*             | `Integer` |                                                         | Valid value of [Survey State](./survey-enum.md#surveystate) enum	 |
| SurveySelectionRule | `String`  | [SurveySelectionRule](./survey-interface.md#surveyselectionrule) interface   | JSON of [SurveySelectionRule](./survey-interface.md#surveyselectionrule) interface. |
| Questions\*\*       | `JSON`    | Array of [SurveyQuestion](./survey-interface.md#surveyquestion) type objects | Questions of the new survey.                                   |

**\*** Requried

**\*\*** Each survey must contain Cover page and Thank you page

## Example
Please note that in the example payload below, three questions are being updated and one inserted.

``` http
POST /v1.0/survey/update HTTP/1.1
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
			"Key": "Q1",
			"Texts": {
				"1045": "Welcome to the survey about upcoming Christmas party."
			}
		},
		{
			"Type": 3,
			"Key": "Q2",
			"Texts": {
				"1045": "What is your favorite alcohol?"
			}
		},
		{
			"Type": 3,
			"Texts": {
				"1045": "What is your favorite Christmas dish?"
			}
		},
		{
			"Type": 99,
			"Key": "Q3",
			"Texts": {
				"1045": "Thank you for your time."
			}
		}
	],
	"Id": 0,
	"SurveyDefinitionId": 0
}
```

## Success Response

**Code:** `200 OK`

**Response:** Empty

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```