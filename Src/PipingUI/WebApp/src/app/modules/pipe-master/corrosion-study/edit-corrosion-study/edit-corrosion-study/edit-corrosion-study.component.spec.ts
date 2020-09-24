import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCorrosionStudyComponent } from './edit-corrosion-study.component';

describe('EditCorrosionStudyComponent', () => {
  let component: EditCorrosionStudyComponent;
  let fixture: ComponentFixture<EditCorrosionStudyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCorrosionStudyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCorrosionStudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
