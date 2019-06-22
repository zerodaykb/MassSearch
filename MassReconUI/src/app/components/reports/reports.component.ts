import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports/reports.service';
import { Report } from '../../models/Report';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css'],
  providers: [ReportsService]
})
export class ReportsComponent implements OnInit {

  constructor(private reportsService: ReportsService) { }

  reports: Report[];

  ngOnInit() {
    this.getReports();
  }

  getReports() {
    this.reportsService.getReports()
      .subscribe(reports => this.reports = reports);
  }

}
