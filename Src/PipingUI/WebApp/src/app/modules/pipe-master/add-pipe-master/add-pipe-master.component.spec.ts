import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPipeMasterComponent } from './add-pipe-master.component';

describe('AddPipeMasterComponent', () => {
  let component: AddPipeMasterComponent;
  let fixture: ComponentFixture<AddPipeMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPipeMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPipeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
