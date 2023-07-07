import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoradorComponent } from './morador.component';

describe('MoradorComponent', () => {
  let component: MoradorComponent;
  let fixture: ComponentFixture<MoradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoradorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
