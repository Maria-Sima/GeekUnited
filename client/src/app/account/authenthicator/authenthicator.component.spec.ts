import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthenthicatorComponent } from './authenthicator.component';

describe('AuthenthicatorComponent', () => {
  let component: AuthenthicatorComponent;
  let fixture: ComponentFixture<AuthenthicatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuthenthicatorComponent]
    });
    fixture = TestBed.createComponent(AuthenthicatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
