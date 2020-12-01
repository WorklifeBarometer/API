---
layout: default
title: API
nav_order: 2
parent: Advanced
---

# Howdy API Documentation
{: .fs-9 }

---

## Endpoints

**Test:**  [https://wlb-uat-ne1-api.azurewebsites.net/](https://wlb-uat-ne1-api.azurewebsites.net/)

**Production:**  [https://api-ne1.worklifebarometer.com/](https://api-ne1.worklifebarometer.com/)

## Security
All calls to the API **must be authenticated** by presenting a valid JWT ([JSON Web Token](https://jwt.io/)).

To obtain the token do the following:
- Access **Howdy Portal** on the following url: [https://auth.worklifebarometer.com/](https://auth.worklifebarometer.com/)
  - In case you already have access to the Test Environment choose the desired Environment
- Navigate to *Company* > *Integration* and **Turn On External Integration**
  - Turn on **Batch limit** and set the max difference to 25 (Recommended)
- Navigate to *Access control* and look for a user with the name `<YourCompanyName> API User` (if you don't see it, please contact support at [support@worklifebarometer.com](mailto:support@worklifebarometer.com))
  - The API user should have the role HRIntegration. 
  - Click the icon to the right and `Generate new api token`
  - This opens a dialog with your newly generated **token** and your `CompanyId`
  - Keep the token secure

The Token can be sent in one of two ways:
- **HTTP Header**: Add it as header `Authorization: Bearer <API_TOKEN_HERE>` to each request
- **Query String parameter**: Pass it as parameter `?access_token=<API_TOKEN_HERE>` to url for each request


## API

| URL Name  | Methods allowed   |
|:--|--:|
|[/v1.0/Company/{companyId}/Employee](./Employee/company-employee-get.md)|GET, PUT|
|[/v1.0/Company/{companyId}/ApiCalls](./Company/company-apiCalls.md)| GET|
|[/v1.0/Company/{companyId}/Language/Enabled](./Company/company-language-enabled.md)| GET|
|[/v1.0/Survey?companyId={companyId}](./Survey/survey-get.md)|GET|
|[/v1.0/Survey/{surveyId}](./Survey/survey-get-by-Id.md)|GET|
|[/v1.0/Survey/ChangeState/{surveyState}](./Survey/Change%20State/survey-changestate.md)| POST|

## Survey Models
See [Survey Models](./Survey/Model/survey-interface.md)