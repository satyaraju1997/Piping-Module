import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEnvironmentCrackingComponent } from './add-environment-cracking.component';

describe('AddEnvironmentCrackingComponent', () => {
  let component: AddEnvironmentCrackingComponent;
  let fixture: ComponentFixture<AddEnvironmentCrackingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEnvironmentCrackingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEnvironmentCrackingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
