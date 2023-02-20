import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gallery2Component } from './gallery2.component';

describe('Gallery2Component', () => {
  let component: Gallery2Component;
  let fixture: ComponentFixture<Gallery2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Gallery2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Gallery2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
