import { TestBed } from '@angular/core/testing';

import { ReservedServiceService } from './reserved-service.service';

describe('ReservedServiceService', () => {
  let service: ReservedServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReservedServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
