import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterfailComponent } from './registerfail.component';

describe('RegisterfailComponent', () => {
  let component: RegisterfailComponent;
  let fixture: ComponentFixture<RegisterfailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterfailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterfailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
