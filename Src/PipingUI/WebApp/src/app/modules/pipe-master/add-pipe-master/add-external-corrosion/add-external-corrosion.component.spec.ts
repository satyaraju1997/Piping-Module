import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddExternalCorrosionComponent } from './add-external-corrosion.component';

describe('AddExternalCorrosionComponent', () => {
  let component: AddExternalCorrosionComponent;
  let fixture: ComponentFixture<AddExternalCorrosionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddExternalCorrosionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddExternalCorrosionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
