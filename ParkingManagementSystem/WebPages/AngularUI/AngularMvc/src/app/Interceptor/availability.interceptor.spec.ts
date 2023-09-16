import { TestBed } from '@angular/core/testing';

import { AvailabilityInterceptor } from './availability.interceptor';

describe('AvailabilityInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AvailabilityInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AvailabilityInterceptor = TestBed.inject(AvailabilityInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
