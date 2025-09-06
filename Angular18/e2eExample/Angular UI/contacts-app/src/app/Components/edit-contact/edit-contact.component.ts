import { Component, OnInit } from '@angular/core';
import { Contact } from '../../Models/contact';
import { ContactService } from '../../Services/contact.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-edit-contact',
  standalone: false,
  templateUrl: './edit-contact.component.html',
  styleUrl: './edit-contact.component.css'
})
export class EditContactComponent implements OnInit {
  id: any;
  foundContact : any = {} as Contact;
  
  constructor(private service : ContactService, private activatedRoute : ActivatedRoute, private nav: Router) {
    
  }
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((params : ParamMap)=>{
      this.id = params.get("id");//params is a dictionary of all the Query strings U pass. 
      this.service.getContact(this.id).subscribe((data)=>{
        this.foundContact = data as Contact;
        alert(JSON.stringify(this.foundContact));
      });
    })
  }

  onUpdate(){//Called when the User clicks Update. 
    this.service.updateContact(this.foundContact).subscribe((data)=>{
      this.nav.navigate(['/contacts/viewall']);//To go back to the list of contacts.
    });
  }

}
