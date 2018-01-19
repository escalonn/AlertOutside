import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { WeatherpreferencesComponent } from './weatherpreferences/weatherpreferences.component';
import { AuthGuard } from './auth.guard';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PreferencesComponent,
    WeatherpreferencesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    AuthGuard,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
