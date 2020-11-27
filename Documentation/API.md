---
layout: default
title: API
nav_order: 4
---

# Howdy API Documentation
{: .fs-9 }

---

# Security
See [Security](../Index.md#security) for obtaning an `Authorization` token required for **Every** http call

# API

| URL Name  | Methods allowed   |
|:--|--:|
|[/v1.0/Company/{companyId}/Employee](./Documentation/company-employee.md)|GET, PUT|
|[/v1.0/Company/{companyId}/ApiCalls](./Documentation/company-apiCalls.md)| GET|
|[/v1.0/Company/{companyId}/Language/Enabled](./Documentation/companyi-language-enabled.md)| GET|
|[/v1.0/Survey?companyId={companyId}](./Documentation/survey.md)|GET|
|[/v1.0/Survey/{surveyId}](./Documentation/survey-surveyId.md)|GET|
|[/v1.0/Survey/ChangeState/{surveyState}](./Documentation/survey-changestate.md)| POST|

# Survey Models
See [Survey Models](./Documentation/survey-interface.md)