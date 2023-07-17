import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PesquisaPrincipalComponent } from './pesquisa-principal.component';

describe('PesquisaPrincipalComponent', () => {
  let component: PesquisaPrincipalComponent;
  let fixture: ComponentFixture<PesquisaPrincipalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PesquisaPrincipalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PesquisaPrincipalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
