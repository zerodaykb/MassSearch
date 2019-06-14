import {Component, Input, OnInit} from '@angular/core';
import {SearchResponse} from '../../models/SearchResponse';
import {Report} from '../../models/Report';
import {SearchService} from '../../services/search/search.service';
import {ReportsService} from '../../services/reports/reports.service';
import {ReadPropExpr} from '@angular/compiler';

@Component({
  selector: 'app-scan-response',
  templateUrl: './scan-response.component.html',
  styleUrls: ['./scan-response.component.css'],
  providers: [ReportsService]
})
export class ScanResponseComponent implements OnInit {

  constructor(private reportsService: ReportsService) { }

  @Input()
  searchResponse: SearchResponse;

  report: Report;
  reports: Report[];

  ngOnInit() {
  }

  addReport() {
    this.report = {
      searchPhrase: this.searchResponse.query,
      quantity: this.searchResponse.quantity,
      reportItems: this.searchResponse.items,
      status: 'nowy',
      notes: '',
    };

    console.log(this.report);

    this.reportsService.postReport(this.report)
      .subscribe(report => console.log(report));
  }
}
