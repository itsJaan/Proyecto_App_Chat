import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MembersChannelComponent } from './members-channel.component';

describe('MembersChannelComponent', () => {
  let component: MembersChannelComponent;
  let fixture: ComponentFixture<MembersChannelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MembersChannelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MembersChannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
