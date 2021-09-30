---
layout: default
title: Home
nav_order: 1
permalink: /
---

# Howdy API Documentation
{: .fs-9 }

These page contains samples and specifications on how to integrate Howdy with HR-systems in order to maintain employee data.
{: .fs-6 .fw-300 }

[Get started now](#getting-started){: .btn .btn-primary .fs-5 .mb-4 .mb-md-0 .mr-2 } [View it on GitHub](https://github.com/WorklifeBarometer/API){: .btn .fs-5 .mb-4 .mb-md-0 }

---

# Getting started
Once your company is created in our [Howdy Portal](https://dashboard.worklifebarometer.com/) you have three options for how to keep your employee data up to date and relevant, this helps you get more out of our product as well it helps us provide a better and more accurate service.

## Manually upload the data in the Howdy Portal
Manually invite or update your employee data using [Howdy Portal](https://dashboard.worklifebarometer.com/) 
- Navigate to **Employees** in side menu
- Select desired employee
- Click **Edit** that will pop up a dialog
- Make the necessary changes
- Click **Save Changes**

It's also possible to invite or update multiple employees at a time if you have the data in **CSV** format.
- Navigate to **Employees** in side menu
- Select **New** and Click **Bulk onboard employees**
- Open Excel, select the data you want to import and choose "Copy" (`Ctrl + C` or `Command + C`)
- Head back to the page and Paste (use: `Ctrl + V` or `Command + V`)

**Notice: The headings shall NOT be copied**

**Notice: Right Click => Paste does not work on the page**

When pasting your data please remember to include at least the following columns: `Firstname`,`Lastname`, `Employee ID`. For more options see [Data Constrains](./Documentation/Employee/company-employee-put.md).

**ATTENTION:** When a new employee is created in Howdy, the mandatory field `Employee ID` must be specified. The employee ID is a unique key that identifies the employee and can be a number that already exists for the employee, for example from an accounting, HR or payroll system. The key can be up to fifty characters long and once it is filled in and saved, it can no longer be corrected (the field becomes "**Read Only**"). The key can consist of numbers, letters and special characters.

## Integration API
The second option is to use our [Integration API](./Documentation/API.md). To use our API you are required to enable it beforehand:
- Click **Company** in side menu
- Navigate to **Integration** and **Turn On External Integration**
  - Turn on **Batch limit** and set the max difference to 25 (Recommended)

This will enable you to use our API, for more information please see [API Security](./Documentation/API.md#security).

### Sample

See our [C# Sample code](./Samples/ActiveDirectoryExample/ActiveDirectoryExample).

## Send us a file with the data
The last option is for you to simply upload a document to our data storage (see [Azure Storage](./Documentation/AzureBlobStorage.md)). We will monitor for file uploads. Oncea file is discovered, it will be parsed and used to refresh the data in Howdy.

