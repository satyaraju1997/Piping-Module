import { TestBed } from '@angular/core/testing';

import { PipingService } from './piping.service';

describe('PipingService', () => {
  let service: PipingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PipingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
