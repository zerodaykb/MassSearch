import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { SearchComponent } from './components/search/search.component';
import {HttpClientModule} from '@angular/common/http';
import { ScanResponseComponent } from './components/scan-response/scan-response.component';
import { ScanItemComponent } from './components/scan-item/scan-item.component';
import { ReportsComponent } from './components/reports/reports.component';

@NgModule({
  declarations: [ AppComponent, SearchComponent, ScanResponseComponent, ScanItemComponent, ReportsComponent ],
  imports: [ BrowserModule, AppRoutingModule, FormsModule, ReactiveFormsModule, HttpClientModule ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
