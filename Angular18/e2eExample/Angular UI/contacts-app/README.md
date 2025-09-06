# Readme
1. Create the Rest API for UR Application. It could be either json-server from Nodejs or a new Web API developed using .NET 8.0.  
2. Create the new Angular App
```
ng new appname
```
3. Create the required Components, interfaces and services. Create Services for DI feature of Angular.
```
ng g c Components/ComponentName --skip-tests
ng g i Models/ModelName
ng g s Services/ServiceName --skip-tests

```
4. Create the Model implementation in the ModelFile.
5. Implement the Service as per your business requirement. If you are connecting to a REST Endpoint, U shall inject HttpClient into the Service. For using HttpClient, U must include provideHttpClient Provider in the Module.ts in providers section. For REST Endpoints, UR Functions should return Observables for handling async programming.  
```
//////////module.ts/////////////////////
providers: [
    provideHttpClient()
  ]

///////////////////Service.ts////////////////////////////////////
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export class ContactService {

  url : string = "http://localhost:3000/contacts";//UR URL ENDPOINT
  constructor(private httpClient : HttpClient) //DI for HttpClient
  { 

  }  
  //Rest of UR Code for accessing the Endpoints. 
``` 
6. Implement your respective Component structures.
    - Implement the data logic in the ts. file
    - Implement the UI in the .html file. 
    . Add any specific styles for this component in the .css file.
    - Use DI for injecting the service into the Component

```
export class ContactListComponent implements OnInit {
  contactList : any = [];

  constructor(private service : ContactService) {
    
  }
  ngOnInit(): void {
    let observable = this.service.getAllContacts();
    observable.subscribe((data : Contact[]) =>{
      this.contactList = data;
    })
  }
  //Additional code if required...   
}

```
9. Add any additional 3rd party libraries like bootstrap into the application and add its refereces at appropriate locations in the angular.json file. 
```
npm install bootstap//In the CLI terminal.

////////In angular.json/////
 "assets": [
              {
                "glob": "**/*",
                "input": "public/images"
              }
            ],
    "styles": [
              "src/styles.css",
              "node_modules/@fortawesome/fontawesome-free/css/all.min.css",
              "node_modules/bootstrap/dist/css/bootstrap.min.css"
            ],
    "scripts": []
```
10. Test the Application by running the CLI Command
```
ng serve --open
```
