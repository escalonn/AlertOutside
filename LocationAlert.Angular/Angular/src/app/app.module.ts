import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { WeatherpreferencesComponent } from './weatherpreferences/weatherpreferences.component';
import { AuthGuard } from './auth.guard';

import { NouisliderModule } from 'ng2-nouislider';






@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PreferencesComponent,
    WeatherpreferencesComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NouisliderModule
  ],
  providers: [
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
