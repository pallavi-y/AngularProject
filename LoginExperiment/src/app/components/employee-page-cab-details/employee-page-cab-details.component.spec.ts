import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeePageCabDetailsComponent } from './employee-page-cab-details.component';

describe('EmployeePageCabDetailsComponent', () => {
  let component: EmployeePageCabDetailsComponent;
  let fixture: ComponentFixture<EmployeePageCabDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeePageCabDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeePageCabDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
