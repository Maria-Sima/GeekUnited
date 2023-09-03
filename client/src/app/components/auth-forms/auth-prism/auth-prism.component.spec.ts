import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthPrismComponent } from './auth-prism.component';

describe('AuthFormsComponent', () => {
  let component: AuthPrismComponent;
  let fixture: ComponentFixture<AuthPrismComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuthPrismComponent]
    });
    fixture = TestBed.createComponent(AuthPrismComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
