## Password API
---

A simple api for validating password string

### Table of contents
* [General info](#general-info)
* [Endpoints](#endpoints)
* [Response](#response)

### General info
Restful API for password validation, meant to be configurable via IoC (using
dependency injection engine of your choice). The service is meant to check a text
string for compliance to any number of password validation rules.
The rules currently known are:
- Must consist of a mixture of lowercase letters and numerical digits only, with at least one of each.
- Must be between 5 and 12 characters in length.
- Must not contain any sequence of characters immediately followed by the same sequence.

### Endpoints
---
```
GET /validate?password=string
```

### Response
---
#### Success (Status Code 200)

#### Error Types (Status Code 409)
| Sequence 	| Type                           	| Description                                                        	|
|----------	|--------------------------------	|--------------------------------------------------------------------	|
| 1        	| ContainsNoLetter               	| Password should contain at least 1 letter                          	|
| 2        	| ContainsNoDigit                	| Password should contain at least 1 digit                           	|
| 3        	| LowercaseLetterOnly            	| Password should not contain any uppercase letter                   	|
| 4        	| LengthMinimumFiveMaximumTwelve 	| Password Length should be between 5 and 12                         	|
| 5        	| ContainsUnnecessaryCharacter   	| Password should not contain any non-digit and non-letter character 	|
| 6        	| TBD                            	| Password should not contain any sequence of characters             	|

### Technologies
---
Project is created with NetCoreApp 3.1 

Packages

        - AspeNetCore.Mvc.Versioning
        - XUnit
        - FluentAssertions


### To do

- [x] Add Error Response Model
- [x] Add Logging
- [ ] Add "Sequence of characters" validation rule
- [ ] Add "Sequence of characters" validation rule test
