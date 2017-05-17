import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TraderComponent } from './trader/trader.component';

@NgModule({
    imports: [BrowserModule, FormsModule],
    declarations: [AppComponent, TraderComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
