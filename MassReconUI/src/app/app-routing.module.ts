import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { ReportsComponent } from './components/reports/reports.component';
import {ReportDetailComponent} from './components/report-detail/report-detail.component';

const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'reports/:id', component: ReportDetailComponent },
  { path: '**', component: SearchComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
