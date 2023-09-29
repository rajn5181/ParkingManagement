import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdwinloginComponent } from './adwinlogin.component';

describe('AdwinloginComponent', () => {
  let component: AdwinloginComponent;
  let fixture: ComponentFixture<AdwinloginComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdwinloginComponent]
    });
    fixture = TestBed.createComponent(AdwinloginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
