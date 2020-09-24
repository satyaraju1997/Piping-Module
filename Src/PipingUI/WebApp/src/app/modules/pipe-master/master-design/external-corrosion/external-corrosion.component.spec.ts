import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalCorrosionComponent } from './external-corrosion.component';

describe('ExternalCorrosionComponent', () => {
  let component: ExternalCorrosionComponent;
  let fixture: ComponentFixture<ExternalCorrosionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExternalCorrosionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalCorrosionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
