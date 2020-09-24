import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PipeImportComponent } from './pipe-import.component';

describe('PipeImportComponent', () => {
  let component: PipeImportComponent;
  let fixture: ComponentFixture<PipeImportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PipeImportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PipeImportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
