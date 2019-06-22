import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {SearchResponse} from '../../models/SearchResponse';
import {Report} from '../../models/Report';
import {catchError} from 'rxjs/operators';
import {ReportItem} from '../../models/ReportItem';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable()
export class ReportsService {
  reportsUrl = 'https://localhost:5001/api/reports';
  reportItemsUrl = 'https://localhost:5001/api/reportItems';

  constructor(private httpClient: HttpClient) { }

  postReport(report: Report): Observable<Report> {
    return this.httpClient.post<Report>(this.reportsUrl, report, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  putReport(report: Report): Observable<Report> {
    return this.httpClient.put<Report>(this.reportsUrl, report, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  getReports(): Observable<Report[]> {
    return this.httpClient.get<Report[]>(this.reportsUrl, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  getReport(id: number): Observable<Report> {
    return this.httpClient.get<Report>(this.reportsUrl + `/${id}`, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  putReportItem(report: ReportItem): Observable<ReportItem> {
    return this.httpClient.put<ReportItem>(this.reportItemsUrl, report, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }



  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };
}
