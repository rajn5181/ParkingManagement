import { TestBed } from '@angular/core/testing';

import { AdminParkinslotService } from './admin-parkinslot.service';

describe('AdminParkinslotService', () => {
  let service: AdminParkinslotService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminParkinslotService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
