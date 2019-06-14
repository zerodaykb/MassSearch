import {Component, OnInit, Output} from '@angular/core';
import {AbstractControl, FormBuilder, Validators} from '@angular/forms';
import {SearchResponse} from '../../models/SearchResponse';
import {SearchService} from '../../services/search/search.service';
import {query} from '@angular/animations';
import {Observable} from 'rxjs';

function oneOrMoreRequired(c: AbstractControl): { [key: string]: boolean }|null {
  const shodan = c.get('shodan').value;
  const censys = c.get('censys').value;

  if (shodan === false && censys === false) {
    return { oneOrMoreRequiredError: true };
  }

  return null;
}


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [SearchService]
})
export class SearchComponent implements OnInit {

  public searchForm = this.formBuilder.group({
    query: ['', [ Validators.minLength(3) ]],
    scannersGroup: this.formBuilder.group({
      shodan:  [false],
      censys:  [false]
    }, {
      validator: oneOrMoreRequired
    }),
  });

  constructor(private formBuilder: FormBuilder, private searchService: SearchService) { }

  // @Output()
  searchResponse: SearchResponse;

  ngOnInit() {
  }

  searchAction() {
    const queryValue = this.searchForm.get('query').value;

    this.searchService.getSearchResponse(queryValue)
      .subscribe((response: SearchResponse) => this.searchResponse = response);
  }

}
