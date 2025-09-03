import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SecondComponent } from './Components/second/second.component';
import { EmpComponent } from './Components/emp/emp.component';
import { CalcComponent } from './Components/calc/calc.component';

@NgModule({
  declarations: [
    AppComponent,
    SecondComponent,
    EmpComponent,
    CalcComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent, SecondComponent]
})
export class AppModule { }
