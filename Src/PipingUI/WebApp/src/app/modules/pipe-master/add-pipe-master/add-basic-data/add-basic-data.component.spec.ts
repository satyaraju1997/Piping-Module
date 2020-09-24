import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBasicDataComponent } from './add-basic-data.component';

describe('AddBasicDataComponent', () => {
  let component: AddBasicDataComponent;
  let fixture: ComponentFixture<AddBasicDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBasicDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBasicDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
