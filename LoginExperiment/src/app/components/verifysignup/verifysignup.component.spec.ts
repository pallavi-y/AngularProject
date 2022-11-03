import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifysignupComponent } from './verifysignup.component';

describe('VerifysignupComponent', () => {
  let component: VerifysignupComponent;
  let fixture: ComponentFixture<VerifysignupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerifysignupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerifysignupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
