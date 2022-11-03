import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcabComponent } from './addcab.component';

describe('AddcabComponent', () => {
  let component: AddcabComponent;
  let fixture: ComponentFixture<AddcabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddcabComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddcabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
