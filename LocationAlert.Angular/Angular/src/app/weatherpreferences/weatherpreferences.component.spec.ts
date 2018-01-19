import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherpreferencesComponent } from './weatherpreferences.component';

describe('WeatherpreferencesComponent', () => {
  let component: WeatherpreferencesComponent;
  let fixture: ComponentFixture<WeatherpreferencesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeatherpreferencesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeatherpreferencesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
