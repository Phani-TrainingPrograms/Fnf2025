import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-emp-detail',
  standalone: false,
  templateUrl: './emp-detail.component.html',
  styleUrl: './emp-detail.component.css'
})
export class EmpDetailComponent implements OnInit {
  ngOnInit(): void {
    this.updatedEmp = {empId : this.selectedEmp.empId, empName : this.selectedEmp.empName, empAddress : this.selectedEmp.empAddress, empSalary : this.selectedEmp.empSalary, empImg : this.selectedEmp.empImg }
  }
  @Input() selectedEmp : Employee = {} as Employee;
  updatedEmp : Employee = {}  as Employee
  @Output() update = new EventEmitter<Employee>() 
  //Event that is triggered when the user clicks the update button, in this case, if the User clicks the update, we shall return the Current Emp object.
  
  onUpdate(){
    this.update.emit(this.updatedEmp);
    alert("Employee updated successfully")
  }
}
