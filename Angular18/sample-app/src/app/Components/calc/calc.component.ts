import { Component } from '@angular/core';

@Component({
  selector: 'app-calc',
  standalone: false,
  templateUrl: './calc.component.html',
  styleUrl: './calc.component.css'
})
export class CalcComponent {
  fValue : number = 45.67
  sValue : number = 35.67
  option : string = "Add"
  result = 0.0;
  
  onProcess(){
    switch(this.option){
      case "Add" :     this.result = this.fValue + this.sValue; break; 
      case "Subtract" :     this.result = this.fValue - this.sValue; break; 
      case "Multiply" :     this.result = this.fValue * this.sValue; break; 
      case "Divide" :     this.result = this.fValue / this.sValue; break; 
    }    
  }
}
