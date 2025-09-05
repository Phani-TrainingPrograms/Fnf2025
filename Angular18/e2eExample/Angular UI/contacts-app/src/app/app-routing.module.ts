import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from './Components/contact-list/contact-list.component';
import { NewContactComponent } from './Components/new-contact/new-contact.component';
import { ErrorPageComponent } from './Components/error-page/error-page.component';
import { ContactViewComponent } from './Components/contact-view/contact-view.component';
import { EditContactComponent } from './Components/edit-contact/edit-contact.component';

const routes: Routes = [
  {path:'', redirectTo:'contacts/viewall', pathMatch:"full"},
  {path:'contacts/viewall', component: ContactListComponent },
  {path:'contacts/add', component: NewContactComponent },
  {path:'contacts/view/:id', component: ContactViewComponent },
  {path:'contacts/edit/:id', component: EditContactComponent },
  {path:'**', component:ErrorPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
