import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-master',
  standalone: false,
  templateUrl: './master.component.html'
})
export class MasterComponent implements OnInit {
  ngOnInit(): void {
    this.empList.push({empId : 123, empName: "Phaniraj", empAddress : "bangalore", empSalary : 35000, empImg :"Phani.png"});
    this.empList.push({empId : 124, empName: "Suresh", empAddress : "bangalore", empSalary : 35000, empImg :"pic2.png"});
    this.empList.push({empId : 125, empName: "Rajesh", empAddress : "bangalore", empSalary : 30000, empImg :"pic3.png"});
    this.empList.push({empId : 126, empName: "Pooja", empAddress : "bangalore", empSalary : 45000, empImg :"pic4.png"});
    this.empList.push({empId : 127, empName: "Simran", empAddress : "bangalore", empSalary : 24000, empImg :"pic5.png"});
  }
  empList : Employee[] = [];//create an Emp Array and initialize to blank...
  foundEmp : Employee | null  = null;


    //event handler for the edit button...
    onEdit(rec : Employee){
      this.foundEmp = rec;
    }

    onSaved(rec : Employee){
      debugger;
      var index = this.empList.findIndex(r =>r.empId == rec.empId);
      if(index < 0){
        alert("No record found to update");
        return;
      }
      this.empList.splice(index, 1, rec);
      alert("Employee updated to the Master");
    }
}
