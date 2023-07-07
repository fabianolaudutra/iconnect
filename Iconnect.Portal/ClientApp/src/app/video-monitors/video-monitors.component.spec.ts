import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoMonitorsComponent } from './video-monitors.component';

describe('VideoMonitorsComponent', () => {
  let component: VideoMonitorsComponent;
  let fixture: ComponentFixture<VideoMonitorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoMonitorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VideoMonitorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
