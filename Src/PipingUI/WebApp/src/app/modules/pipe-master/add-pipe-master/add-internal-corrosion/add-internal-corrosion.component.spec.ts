import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInternalCorrosionComponent } from './add-internal-corrosion.component';

describe('AddInternalCorrosionComponent', () => {
  let component: AddInternalCorrosionComponent;
  let fixture: ComponentFixture<AddInternalCorrosionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddInternalCorrosionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddInternalCorrosionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
