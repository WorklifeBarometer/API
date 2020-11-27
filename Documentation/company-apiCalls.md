# GET Api Calls

**URL** : `/v1.0/company/{companyId}/apicalls`

**Method** : `GET`

**Auth required** : YES

**Note**

The lifetime of a queued request is a follows:
1. Created. `HttpStatusCode` and `HttpStatusReason` will be empty
2. Validated and queued. `HttpStatusCode` will be `202` and `HttpStatusReason` will be `Accepted`. If validation fails, the request will immediately change status to 4xx if it is deemed to be a problem with the data or 5xx if an unexpected problem has happened on the server.
3. Processing started. `HttpStatusCode` will remain `202` and `HttpStatusReason` will change to `Processing...`.  Usually processing will start within a couple of minutes, but if the server is busy it could take up to an hour.
4. Processing completed. `HttpStatusCode` will change to `200` if everything went okay. If not, the code and reason should provide some explanation.


## Example

```http
GET /v1.0/company/{companyId}/apicalls HTTP/1.1
Host: <API_ENDPOINT>
Authorization: Bearer <API_TOKEN_HERE>
Cache-Control: no-cache
```

## Success Response

**Code:** `200 OK`

```json
[
    {
        "ApiOperationId": "GUID",
        "UserId": "integer",
        "Username": "string",
        "CreatedOn": "DateTime",
        "Method": "string",
        "HttpStatusCode": "integer",
        "HttpStatusReason": "string"
    }    
]
```

## Error Response

**Code:** `401 Unauthorized`

```json
{
  "Message": "Authorization has been denied for this request."
}
```