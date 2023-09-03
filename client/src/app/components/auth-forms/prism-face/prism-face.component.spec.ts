import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrismFaceComponent } from './prism-face.component';

describe('PrismFaceComponent', () => {
  let component: PrismFaceComponent;
  let fixture: ComponentFixture<PrismFaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PrismFaceComponent]
    });
    fixture = TestBed.createComponent(PrismFaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
