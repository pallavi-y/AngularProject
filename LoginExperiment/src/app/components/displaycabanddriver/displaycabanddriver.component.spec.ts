import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaycabanddriverComponent } from './displaycabanddriver.component';

describe('DisplaycabanddriverComponent', () => {
  let component: DisplaycabanddriverComponent;
  let fixture: ComponentFixture<DisplaycabanddriverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaycabanddriverComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplaycabanddriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
