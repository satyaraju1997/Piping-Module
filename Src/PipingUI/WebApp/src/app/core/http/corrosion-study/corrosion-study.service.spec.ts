import { TestBed } from '@angular/core/testing';

import { CorrosionStudyService } from './corrosion-study.service';

describe('CorrosionStudyService', () => {
  let service: CorrosionStudyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CorrosionStudyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
