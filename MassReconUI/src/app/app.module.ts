import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchComponent } from './components/search/search.component';
import { HttpClientModule } from '@angular/common/http';
import { ScanResponseComponent } from './components/scan-response/scan-response.component';
import { ScanItemComponent } from './components/scan-item/scan-item.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportItemComponent } from './components/report-item/report-item.component';
import { ReportComponent } from './components/report/report.component';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReportDetailComponent } from './components/report-detail/report-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    ScanResponseComponent,
    ScanItemComponent,
    ReportsComponent,
    ReportItemComponent,
    ReportComponent,
    ReportDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
