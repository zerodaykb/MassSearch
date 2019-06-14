import {ReportItem} from './ReportItem';

export interface Report {
  searchPhrase: string;
  notes: string;
  status: string;
  quantity: number;
  reportItems: [];
}
