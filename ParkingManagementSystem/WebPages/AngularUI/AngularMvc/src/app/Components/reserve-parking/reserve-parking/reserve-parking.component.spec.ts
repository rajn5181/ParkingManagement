import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserveParkingComponent } from './reserve-parking.component';

describe('ReserveParkingComponent', () => {
  let component: ReserveParkingComponent;
  let fixture: ComponentFixture<ReserveParkingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReserveParkingComponent]
    });
    fixture = TestBed.createComponent(ReserveParkingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
