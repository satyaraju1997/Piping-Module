import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCofComponent } from './add-cof.component';

describe('AddCofComponent', () => {
  let component: AddCofComponent;
  let fixture: ComponentFixture<AddCofComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCofComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCofComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
