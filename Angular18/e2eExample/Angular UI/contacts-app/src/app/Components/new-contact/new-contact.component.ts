import { Component } from '@angular/core';
import { Contact } from '../../Models/contact';
import { ContactService } from '../../Services/contact.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-contact',
  standalone: false,
  templateUrl: './new-contact.component.html',
  styleUrl: './new-contact.component.css'
})
export class NewContactComponent {
  newContact : any = {};

constructor(private service : ContactService, private nav : Router) {
  
}
  onSubmit(){
    this.service.addContact(this.newContact).subscribe((data)=>{
      alert("The Record is added successfully")
      this.nav.navigate(['/']);
    }) 
  }
}
