import { Component } from '@angular/core';

@Component({
  selector: 'apple',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title : string = 'My First Angular-app';
}
