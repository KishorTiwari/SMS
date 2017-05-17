import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `<trader></trader>`,
})
export class AppComponent  {
    name = 'Angular';
    age: number = 5; 
}
