import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SecondComponent } from './Components/second/second.component';
import { EmpComponent } from './Components/emp/emp.component';
import { CalcComponent } from './Components/calc/calc.component';
import { FormsModule } from '@angular/forms';
import { EmpDetailComponent } from './Components/emp-detail/emp-detail.component';
import { MasterComponent } from './Components/master/master.component';

@NgModule({
  declarations: [
    AppComponent,
    SecondComponent,
    EmpComponent,
    CalcComponent,
    EmpDetailComponent,
    MasterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [MasterComponent]
})
export class AppModule { }
