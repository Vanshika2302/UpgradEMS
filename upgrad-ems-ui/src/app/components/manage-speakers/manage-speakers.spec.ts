import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageSpeakers } from './manage-speakers';

describe('ManageSpeakers', () => {
  let component: ManageSpeakers;
  let fixture: ComponentFixture<ManageSpeakers>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageSpeakers],
    }).compileComponents();

    fixture = TestBed.createComponent(ManageSpeakers);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
