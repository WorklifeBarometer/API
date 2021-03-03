---
layout: default
title: GET Survey Answers
parent: Survey
grand_parent: Advanced
---


# GET
Get survey answers for a company or survey.

**URL** : `/v1.0/Survey/Answers?companyId={companyId}&surveyId={surveyId}&departmentId={departmentId}&period={period}`

**Method** : `GET`

**Auth required** : YES

**Note** : The only required attribute is `companyId`. All other attributes create a possibility to get more specific data.
Period is a string that specifies in which reporting period to look for answers. If survey is reported quarterly, then `period="YYYY-Q1"` up to `"YYYY-Q4"`,
otherwise `period="YYYY-M"`.

## Example

``` http
GET /v1.0/Survey/Answers?companyId={companyId}&surveyId={surveyId}&departmentId={departmentId}&period={period} HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

``` json
[
    {
        "SurveyId": 1000,
        "QuestionKey": "Q2",
        "Answer": "2",
        "Time": null,
        "Period": "2020-4",
        "Count": 50
    },
    {
        "SurveyId": 1000,
        "QuestionKey": "Q3",
        "Answer": "I am really proud to work for this company.",
        "Time": 2020-04-25T00:00:00,
        "Period": "2020-4",
        "Count": 1
    }
]
```
**Note:** : If an answer is a selected option, all "votes" of that option are grouped and only one answer with `Count` is provided (first answer above). If an answer is a text answer, `Count` is always 1 and date of an answer is provided.

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```
