import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthpageComponent } from './authpage.component';

describe('AuthpageComponent', () => {
  let component: AuthpageComponent;
  let fixture: ComponentFixture<AuthpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuthpageComponent]
    });
    fixture = TestBed.createComponent(AuthpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
