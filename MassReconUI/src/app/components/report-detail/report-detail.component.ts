import { Component, OnInit } from '@angular/core';
import {ReportsService} from '../../services/reports/reports.service';
import {ActivatedRoute} from '@angular/router';
import {Report} from '../../models/Report';

@Component({
  selector: 'app-report-detail',
  templateUrl: './report-detail.component.html',
  styleUrls: ['./report-detail.component.css'],
  providers: [ReportsService]
})
export class ReportDetailComponent implements OnInit {

  constructor(
    private reportsService: ReportsService,
    private route: ActivatedRoute
  ) { }

  report: Report;

  ngOnInit(): void {
    this.getReport();
  }

  getReport(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    if (!id) {
      return;
    }

    this.reportsService.getReport(id)
      .subscribe(report => this.report = report);
  }


}
