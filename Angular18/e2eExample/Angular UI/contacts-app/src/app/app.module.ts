import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactViewComponent } from './Components/contact-view/contact-view.component';
import { NewContactComponent } from './Components/new-contact/new-contact.component';
import { EditContactComponent } from './Components/edit-contact/edit-contact.component';
import { ContactListComponent } from './Components/contact-list/contact-list.component';
import { ErrorPageComponent } from './Components/error-page/error-page.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { provideHttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ContactViewComponent,
    NewContactComponent,
    EditContactComponent,
    ContactListComponent,
    ErrorPageComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
