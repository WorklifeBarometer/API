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

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Frequency         | How often can survey be answered. Options: "Hourly", "Monthly", "Quarterly", "Continuous".|
| EnabledLanguages  | Array of language objects. Please find list of all enabled languages [here](./company-language-enabled.md).|
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

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Type              | Type of the question. Integer, not null. Valid value of [QuestionType](#questiontype) enum.|
| Key 				| Key of the question. String, max length 20. When creating new question, this field is not included. System assigns a key to a question which is then included in [GET v1.0/Survey/{surveyId}](./survey.md). This key can then be used to update the question by including it in [POST v1.0/Survey/Update](./surve-update.md) request payload (see example payload). |
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

## AnswerOption
When creating a new survey or adding a new question, `LabelKey` and `Value` are omitted. The system automatically assigns a value to these columns to maintain consistency. They can be then used to update existing answer options. When updating an answer option, both `LabelKey` and `Value` should never be changed since doing so could cause inconsistent data and wrong mapping of answers and options. The only thing that should be subject to change are `Texts` and only in the case of an error in the text. When changing a meaning of an answer option, it is also good to consider treating them as immutable. Deleting one with old value and creating a new with the new value. That way the best experience of analyzing answers is ensured.

| Field             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| Texts             | Object of type [QuestionTexts](#questiontexts). Not null.					   |
| Deleted           | Optional, true when option should be deleted.|
| LabelKey          | String, omitted when creating a new option, required to update an existing answer option |
| Value           	| Integer, omitted when creating a new option, required to update an existing answer option. |


# Enums

## SurveyState
| Value             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| 2                 | Active survey																   |
| 3                 | Inactive survey															   |

## QuestionType

| Value             | Description                                                                  |
| ----------------- | ---------------------------------------------------------------------------- |
| 1                 | Cover page																   |
| 2                 | Question with answer options												   |
| 3                 | Question with text answer													   |
| 99                | Thank you page															   |

