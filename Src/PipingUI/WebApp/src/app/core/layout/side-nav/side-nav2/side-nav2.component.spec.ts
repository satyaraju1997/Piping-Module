import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNav2Component } from './side-nav2.component';

describe('SideNav2Component', () => {
  let component: SideNav2Component;
  let fixture: ComponentFixture<SideNav2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNav2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNav2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
