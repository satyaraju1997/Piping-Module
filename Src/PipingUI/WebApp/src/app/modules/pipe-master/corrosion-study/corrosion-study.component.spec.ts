import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CorrosionStudyComponent } from './corrosion-study.component';

describe('CorrosionStudyComponent', () => {
  let component: CorrosionStudyComponent;
  let fixture: ComponentFixture<CorrosionStudyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CorrosionStudyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CorrosionStudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
