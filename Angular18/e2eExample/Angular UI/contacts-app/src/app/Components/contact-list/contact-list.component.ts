import { Component, OnInit } from '@angular/core';
import { Contact } from '../../Models/contact';
import { ContactService } from '../../Services/contact.service';

@Component({
  selector: 'app-contact-list',
  standalone: false,
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
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
}
