import { TestBed } from '@angular/core/testing';

import { PipeMasterService } from './pipe-master.service';

describe('PipeMasterService', () => {
  let service: PipeMasterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PipeMasterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
