// AppModule.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './config/app-routing.module'; // Import AppRoutingModule

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule], // Add AppRoutingModule to imports
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }