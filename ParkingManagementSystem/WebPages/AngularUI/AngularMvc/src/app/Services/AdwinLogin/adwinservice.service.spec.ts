import { TestBed } from '@angular/core/testing';

import { AdwinserviceService } from './adwinservice.service';

describe('AdwinserviceService', () => {
  let service: AdwinserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdwinserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
