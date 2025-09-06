import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../Models/contact';

@Pipe({
  name: 'contactFilter',
  standalone: false
})
//It changes the data to the required format at runtime.
export class ContactFilterPipe implements PipeTransform {

  //1st : Source
  //2nd: arg /conditions for transformation. 
  //Return type: What U expect after the transformation
  transform(contacts: Contact [], args: string): Contact [] {
    debugger;
    if(args ==  "")
      return contacts;
    else{
        return contacts.filter(c => c.name.toLowerCase().includes(args.toLowerCase()));
    }
  }
}
