import {Component, Input, OnInit} from '@angular/core';
import {Report} from '../../models/Report';
import {DomSanitizer} from '@angular/platform-browser';
import {MatIconRegistry} from '@angular/material';
import {ReportsService} from '../../services/reports/reports.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css'],
  providers: [ReportsService]
})
export class ReportComponent implements OnInit {
  constructor(iconRegistry: MatIconRegistry,
              sanitizer: DomSanitizer,
              private reportsService: ReportsService) {
    iconRegistry.addSvgIcon(
      'thumbs-up',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/examples/thumbup-icon.svg'));
  }

  private _report: Report;

  @Input()
  set report(report: Report) {
    this._report = report;
  }

  get report() {
    return this._report;
  }

  changeStatus() {
    const currentStatus = this.report.status;
    let newStatus = '';

    switch (currentStatus) {
      case 'nowy':
        newStatus = 'rozpoczety';
        break;
      case 'rozpoczety':
        newStatus = 'koniec';
        break;
      case 'koniec':
        newStatus = 'nowy';
        break;
      default:
        newStatus = 'nowy';
    }

    this.report.status = newStatus;

    this.updateReport();
  }

  updateReport() {
    this.reportsService.putReport(this.report)
      .subscribe(report => console.log(report));
  }

  ngOnInit() {}
}
