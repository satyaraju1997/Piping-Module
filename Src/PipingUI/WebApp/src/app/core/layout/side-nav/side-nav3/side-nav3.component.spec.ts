import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNav3Component } from './side-nav3.component';

describe('SideNav3Component', () => {
  let component: SideNav3Component;
  let fixture: ComponentFixture<SideNav3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNav3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNav3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
