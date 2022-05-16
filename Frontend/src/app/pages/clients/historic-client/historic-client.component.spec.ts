import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricClientComponent } from './historic-client.component';

describe('HistoricClientComponent', () => {
  let component: HistoricClientComponent;
  let fixture: ComponentFixture<HistoricClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricClientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
