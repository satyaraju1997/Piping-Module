import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEcDialogComponent } from './edit-ec-dialog.component';

describe('EditEcDialogComponent', () => {
  let component: EditEcDialogComponent;
  let fixture: ComponentFixture<EditEcDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditEcDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEcDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
