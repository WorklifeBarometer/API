Azure Blob Storage
------------------

As an alternative to [calling our API directly](/WorklifeBarometer/API/blob/master/Documentation/Index.md), it is also possible to upload a file to our Azure Blob Storage.

In this case Worklife Barometer will read, parse, and clean the data if necessary, and then call our own API.

We suggest sending the data as CSV with UTF-8 encoding, but we support all standard formats, such as JSON, XML, XLSX etc.

To upload a file to us for processing, use the following command after installing the [AZ Copy utility](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10):

    ./azcopy cp 20200608.csv "https://<account-will-be-handed-out-on-request>.blob.core.windows.net/container/20200608.csv?<shared-access-signature-will-be-handed-out-on-request>

In order to verify that the file has been delivered correctly, the following command can be run:

    ./azcopy ls "https://<account-will-be-handed-out-on-request>.blob.core.windows.net/container?<shared-access-signature-will-be-handed-out-on-request>

We suggest sending data daily, but it is up to you.
