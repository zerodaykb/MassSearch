import {Component, Input, OnInit} from '@angular/core';
import {SearchResponse} from '../../models/SearchResponse';
import {Report} from '../../models/Report';
import {SearchService} from '../../services/search/search.service';
import {ReportsService} from '../../services/reports/reports.service';
import {ReadPropExpr} from '@angular/compiler';
import {FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-scan-response',
  templateUrl: './scan-response.component.html',
  styleUrls: ['./scan-response.component.css'],
  providers: [ReportsService]
})
export class ScanResponseComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private reportsService: ReportsService) { }

  @Input()
  searchResponse: SearchResponse;

  public insertReportForm = this.formBuilder.group({
    reportTitle: ['', [ Validators.required, Validators.minLength(3) ]],
    reportNotes: ['']
  });

  report: Report;

  ngOnInit() {
  }

  addReport() {
    this.report = {
      searchPhrase: this.searchResponse.query,
      quantity: this.searchResponse.quantity,
      reportItems: this.searchResponse.items,
      status: 'nowy',
      notes: this.insertReportForm.get('reportNotes').value,
      title: this.insertReportForm.get('reportTitle').value,
    };

    console.log(this.report);

    this.reportsService.postReport(this.report)
      .subscribe(report => console.log(report));
  }
}
