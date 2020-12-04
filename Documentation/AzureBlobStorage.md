---
layout: default
title: Azure Blob Storage
nav_order: 1
parent: Advanced
---

# Azure Blob Storage

As an alternative to calling our [API](./API.md) directly, it is also possible to upload a file to our Azure Blob Storage.
In this case WorklifeBarometer will read, parse, and clean the data if necessary, and then call our own API.

We suggest sending the data as CSV with UTF-8 encoding, but we support all standard formats, such as JSON, XML, XLSX etc.

A shared access signature will be handed out on request. To test that the signature works and to familiarize yourself with Azure Blob Storage we suggest that you use the [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/) to access the container.

To upload a file to us for processing, use the following command after installing the [AZ Copy utility](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10):
``` bash
./azcopy cp 20200608.csv "https://<account-will-be-handed-out-on-request>.blob.core.windows.net/container/20200608.csv?<shared-access-signature-will-be-handed-out-on-request>
```

In order to verify that the file has been delivered correctly, the following command can be run:

``` bash
./azcopy ls "https://<account-will-be-handed-out-on-request>.blob.core.windows.net/container?<shared-access-signature-will-be-handed-out-on-request>
```

We suggest sending data every night, but it is up to you as a customer.
