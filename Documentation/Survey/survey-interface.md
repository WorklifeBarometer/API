---
layout: default
title: Interface
nav_order: 1
parent: Survey
grand_parent: Advanced
---

# Interfaces

## QuestionConfiguration

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

## SurveySelectionRule

| Field            | Type                        | Requirements                                                | Description                                                                          |
| :--------------- | :-------------------------- | :---------------------------------------------------------- | :----------------------------------------------------------------------------------- |
| Frequency        | `String`                    | **Options:** `Hourly`, `Monthly`, `Quarterly`, `Continuous` | How often can survey be answered.                                                    |
| EnabledLanguages | `Array of language objects` |                                                             | Please find list of all enabled languages [here](../Company/company-language-enabled.md). |
| Filter           | `Object`                    | Company dimension key ("ImmediateManager", "Department")    | Value is desired dimension value. Only one key value pair is supported.              |

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

## QuestionTexts

QuestionText is JSON object where key is language id and value is text.

Example:

``` json
{
	"1045": "Simple question text in English",
	"1041": "Enkel spørgsmålstekst på dansk"
}
```

## SurveyQuestion

| Field               | Type                           | Requirements                                                      | Description                                                                     |
| :------------------ | :----------------------------- | :---------------------------------------------------------------- | :------------------------------------------------------------------------------ |
| Type\*              | `Integer`                      | Valid value of [QuestionType](./survey-enum.md#questiontype) enum | Type of the question                                                            |
| Key\*\*             | `String`, *Max length:* **20** |                                                                   | Key of the question. **When creating new question this field is not included**  |
| Texts\*             | `JSON object`                  | Object of type [QuestionTexts](#questiontexts)                    | The qestion/qeestions you would want to ask                                     |
| AnswerOptions\*\*\* | `JSON object`                  | Array of [AnswerOption](#answeroption) type objects               | The answers aviable                                                             |
| Deleted             | `Boolean`                      |                                                                   | True when question should be deleted                                            |

**\*** Required

**\*\*** Required when *updating* but not *creating*

**\*\*\*** Required when `Type` is `2`

**Note**
System assigns a `Key` to a question which is then included in [GET v1.0/Survey/{surveyId}](./survey-get-by-Id.md). This key can then be used to update the question by including it in [POST v1.0/Survey/Update](./surve-post.md) request payload (see example payload)

### Example:

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

## AnswerOption
When creating a new survey or adding a new question, `LabelKey` and `Value` are omitted. The system automatically assigns a value to these columns to maintain consistency. 

They can be then used to update existing answer options. When updating an answer option, both `LabelKey` and `Value` should never be changed since doing so could cause inconsistent data and wrong mapping of answers and options. The only thing that should be subject to change are `Texts` and only in the case of an error in the text. 

When changing a meaning of an answer option, it is also good to consider treating them as immutable. Deleting one with old value and creating a new with the new value. That way the best experience of analyzing answers is ensured.


| Field        | Type                                           | Description                         |
| ------------ | ---------------------------------------------- | ----------------------------------- |
| Texts\*      | Object of type [QuestionTexts](#questiontexts) | Question                            |
| Deleted      | `Boolean`                                      | true when option should be deleted. |
| LabelKey\*\* | `String`                                       |                                     |
| Value\*\*    | `Integer`                                      |                                     |

**\*** Required

**\*\*** omitted when *creating* a new option, required to *update* an existing answer option