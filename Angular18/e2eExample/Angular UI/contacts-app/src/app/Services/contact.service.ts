import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventManagerPlugin } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { Contact } from '../Models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  url : string = "http://localhost:3000/contacts";
  constructor(private httpClient : HttpClient) 
  { 

  }
  public getAllContacts() : Observable<Contact[]>{
    return this.httpClient.get<Contact[]>(this.url);
  } 
  
  public getContact(id : string) : Observable<Contact>{
    const temp : string = `${this.url}/${id}` 
    return this.httpClient.get<Contact>(temp)
  }
}
