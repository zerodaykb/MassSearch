import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScanResponseComponent } from './scan-response.component';

describe('ScanResponseComponent', () => {
  let component: ScanResponseComponent;
  let fixture: ComponentFixture<ScanResponseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScanResponseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScanResponseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
