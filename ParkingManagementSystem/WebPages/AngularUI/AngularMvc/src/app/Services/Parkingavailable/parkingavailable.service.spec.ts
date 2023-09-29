import { TestBed } from '@angular/core/testing';

import { ParkingavailableService } from './parkingavailable.service';

describe('ParkingavailableService', () => {
  let service: ParkingavailableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParkingavailableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
