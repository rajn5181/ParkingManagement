import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingAvailableComponent } from './parking-available.component';

describe('ParkingAvailableComponent', () => {
  let component: ParkingAvailableComponent;
  let fixture: ComponentFixture<ParkingAvailableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ParkingAvailableComponent]
    });
    fixture = TestBed.createComponent(ParkingAvailableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
