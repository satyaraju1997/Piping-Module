import { TestBed } from '@angular/core/testing';

import { LeftMenuService } from './left-menu.service';

describe('LeftMenuService', () => {
  let service: LeftMenuService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LeftMenuService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
