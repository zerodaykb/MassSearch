import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs';
import {SearchResponse} from '../../models/SearchResponse';
import {AbstractControl} from '@angular/forms';

const search = 'https://localhost:5001/api/search?query=';

@Injectable()
export class SearchService {
  constructor(private httpClient: HttpClient) { }

  getSearchResponse(query: string): Observable<SearchResponse>  {
    return this.httpClient.get<SearchResponse>(search + query);
  }
}
