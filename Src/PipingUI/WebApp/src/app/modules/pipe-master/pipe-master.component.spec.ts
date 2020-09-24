import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PipeMasterComponent } from './pipe-master.component';

describe('PipeMasterComponent', () => {
  let component: PipeMasterComponent;
  let fixture: ComponentFixture<PipeMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PipeMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PipeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
