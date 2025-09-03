import { Component } from '@angular/core';

@Component({
  selector: 'app-emp',
  standalone: false,
  templateUrl: './emp.component.html',
  styleUrl: './emp.component.css'
})
export class EmpComponent {
    empName : string ="Phaniraj"
    empAddress : string ="Bangalore"
    empSalary : number = 45000;

    onClick(){
      alert("The User has clicked")
    }
}
