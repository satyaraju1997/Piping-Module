import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCorrosionStudyComponent } from './add-corrosion-study.component';

describe('AddCorrosionStudyComponent', () => {
  let component: AddCorrosionStudyComponent;
  let fixture: ComponentFixture<AddCorrosionStudyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCorrosionStudyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCorrosionStudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
