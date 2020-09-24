import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalCorrosionComponent } from './internal-corrosion.component';

describe('InternalCorrosionComponent', () => {
  let component: InternalCorrosionComponent;
  let fixture: ComponentFixture<InternalCorrosionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalCorrosionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalCorrosionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
