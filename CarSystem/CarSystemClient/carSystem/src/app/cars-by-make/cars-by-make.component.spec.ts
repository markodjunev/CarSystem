import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsByMakeComponent } from './cars-by-make.component';

describe('CarsByMakeComponent', () => {
  let component: CarsByMakeComponent;
  let fixture: ComponentFixture<CarsByMakeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarsByMakeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarsByMakeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
