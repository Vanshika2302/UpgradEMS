import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageSessions } from './manage-sessions';

describe('ManageSessions', () => {
  let component: ManageSessions;
  let fixture: ComponentFixture<ManageSessions>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageSessions],
    }).compileComponents();

    fixture = TestBed.createComponent(ManageSessions);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
