import {Component, Input, OnInit} from '@angular/core';
import {SearchResponseItem} from '../../models/SearchResponseItem';
import {ReportItem} from '../../models/ReportItem';
import {ReportsService} from '../../services/reports/reports.service';

@Component({
  selector: 'app-report-item',
  templateUrl: './report-item.component.html',
  styleUrls: ['./report-item.component.css'],
  providers: [ReportsService]
})
export class ReportItemComponent implements OnInit {

  constructor(private reportsService: ReportsService) { }

  private _reportItem: ReportItem;

  @Input()
  set reportItem(item: ReportItem) {
    this._reportItem = item;
  }

  get reportItem() {
    return this._reportItem;
  }

  ngOnInit() {
  }

  updateReportItem() {
    this.reportsService.putReportItem(this._reportItem)
      .subscribe(report => console.log(report));
  }

}
