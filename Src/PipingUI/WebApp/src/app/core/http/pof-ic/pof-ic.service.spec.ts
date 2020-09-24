import { TestBed } from '@angular/core/testing';

import { PofIcService } from './pof-ic.service';

describe('PofIcService', () => {
  let service: PofIcService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PofIcService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
