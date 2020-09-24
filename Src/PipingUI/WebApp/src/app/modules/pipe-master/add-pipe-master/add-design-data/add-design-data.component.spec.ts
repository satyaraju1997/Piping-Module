import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDesignDataComponent } from './add-design-data.component';

describe('AddDesignDataComponent', () => {
  let component: AddDesignDataComponent;
  let fixture: ComponentFixture<AddDesignDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddDesignDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDesignDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
