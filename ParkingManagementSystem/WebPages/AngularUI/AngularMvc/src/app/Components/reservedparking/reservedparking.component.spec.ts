import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservedparkingComponent } from './reservedparking.component';

describe('ReservedparkingComponent', () => {
  let component: ReservedparkingComponent;
  let fixture: ComponentFixture<ReservedparkingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReservedparkingComponent]
    });
    fixture = TestBed.createComponent(ReservedparkingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
