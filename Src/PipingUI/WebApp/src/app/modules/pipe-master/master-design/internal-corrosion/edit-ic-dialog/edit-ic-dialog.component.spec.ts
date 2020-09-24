import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditIcDialogComponent } from './edit-ic-dialog.component';

describe('EditIcDialogComponent', () => {
  let component: EditIcDialogComponent;
  let fixture: ComponentFixture<EditIcDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditIcDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditIcDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
