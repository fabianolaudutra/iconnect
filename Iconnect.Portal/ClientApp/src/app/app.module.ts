import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MonitoresComponent } from './monitores/monitores.component';
import { VideoMonitorsComponent } from './video-monitors/video-monitors.component';
import { MoradorComponent } from './morador/morador.component';
import { FormsModule } from '@angular/forms';
import { MoradorListComponent } from './morador-list/morador-list.component';
import { HorizontalButtonsComponent } from './horizontal-buttons/horizontal-buttons.component';

@NgModule({
  declarations: [
    AppComponent,
    MonitoresComponent,
    VideoMonitorsComponent,
    MoradorComponent,
    MoradorListComponent,
    HorizontalButtonsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTabsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
