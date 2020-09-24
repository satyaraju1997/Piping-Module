import { TestBed } from '@angular/core/testing';

import { LeftMenuDataService } from './left-menu-data.service';

describe('LeftMenuDataService', () => {
  let service: LeftMenuDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LeftMenuDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
