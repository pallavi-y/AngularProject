import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriverCarInfoComponent } from './driver-car-info.component';

describe('DriverCarInfoComponent', () => {
  let component: DriverCarInfoComponent;
  let fixture: ComponentFixture<DriverCarInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DriverCarInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DriverCarInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
