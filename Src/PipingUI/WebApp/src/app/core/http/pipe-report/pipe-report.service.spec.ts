import { TestBed } from '@angular/core/testing';

import { PipeReportService } from './pipe-report.service';

describe('PipeReportService', () => {
  let service: PipeReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PipeReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
