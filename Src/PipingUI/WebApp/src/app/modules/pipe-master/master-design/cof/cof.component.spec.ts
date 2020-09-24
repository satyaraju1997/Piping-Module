import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CofComponent } from './cof.component';

describe('CofComponent', () => {
  let component: CofComponent;
  let fixture: ComponentFixture<CofComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CofComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CofComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
