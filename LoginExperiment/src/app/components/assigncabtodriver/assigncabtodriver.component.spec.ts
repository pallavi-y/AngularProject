import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigncabtodriverComponent } from './assigncabtodriver.component';

describe('AssigncabtodriverComponent', () => {
  let component: AssigncabtodriverComponent;
  let fixture: ComponentFixture<AssigncabtodriverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssigncabtodriverComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssigncabtodriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
