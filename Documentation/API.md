---
layout: default
title: API
nav_order: 2
parent: Advanced
---

# Howdy API Documentation
{: .fs-9 }

---

# Security
See [Security](../Index.md#security) for obtaining an `Authorization` token required for **every** http call


# API

| URL Name  | Methods allowed   |
|:--|--:|
|[/v1.0/Company/{companyId}/Employee](./Employee/company-employee-get.md)|GET, PUT|
|[/v1.0/Company/{companyId}/ApiCalls](./Company/company-apiCalls.md)| GET|
|[/v1.0/Company/{companyId}/Language/Enabled](./Company/company-language-enabled.md)| GET|
|[/v1.0/Survey?companyId={companyId}](./Survey/survey-get.md)|GET|
|[/v1.0/Survey/{surveyId}](./Survey/survey-get-by-Id.md)|GET|
|[/v1.0/Survey/ChangeState/{surveyState}](./Survey/Change%20State/survey-changestate.md)| POST|

# Survey Models
See [Survey Models](./Survey/Model/survey-interface.md)