import {Component, Input, OnInit} from '@angular/core';
import {SearchResponseItem} from '../../models/SearchResponseItem';

@Component({
  selector: 'app-scan-item',
  templateUrl: './scan-item.component.html',
  styleUrls: ['./scan-item.component.css']
})
export class ScanItemComponent implements OnInit {

  constructor() { }

  private _searchResponseItem: SearchResponseItem;

  @Input()
  set searchResponseItem(item: SearchResponseItem) {
    this._searchResponseItem = item;
  }

  get searchResponseItem() {
    return this._searchResponseItem;
  }

  ngOnInit() {
  }

}
