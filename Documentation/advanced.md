---
layout: default
title: Advanced
has_children: true
---

# Integration

**External Integration**

Allows the integration of Howdy with HR-systems in order to maintain employee data.
Creates a User with the Role **HRIntegration** (see the user in *Access control* in Howdy Portal)
Following the steps above results in Authentication token used in **ALL** Api calls

**Test Environment**

Test Environment (also called *UAT*) is used to test new features and resets once a day, meening any and all changes made to the system are overwriten by the data used in production.

**Batch limit**

Percent of allowed change per one request*

`|x-y|/x*100 < z OR x < 100`

**x** = Employees already in system

**y** = Employees beeing send from request

**z** = Batch limit

**\*** Exception to this is only if there is less than **100** employees in the system, then the request is processed immediately and no batch limit is applied


> E.g. Batch limit of **25** and *100 Employees in company* results in maximum of 25 addition or subtractions


**Automatically invite**

If **InvitationDate** is not set and this is enabled everytime a new user is added an invitation is send.