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

import { NouisliderModule } from 'ng2-nouislider';
import { RegionsComponent } from './regions/regions.component';
import { FormsModule } from '@angular/forms';

import { AgmCoreModule } from '@agm/core';
import { RegistersuccessComponent } from './registersuccess/registersuccess.component';
import { LogoutComponent } from './logout/logout.component';
import { RegisterfailComponent } from './registerfail/registerfail.component';
import { LoginfailComponent } from './loginfail/loginfail.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PreferencesComponent,
    WeatherpreferencesComponent,
    RegionsComponent,
    RegistersuccessComponent,
    LogoutComponent,
    RegisterfailComponent,
    LoginfailComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NouisliderModule,
    AppRoutingModule,
    FormsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDqINRPfJaUcmFkhziYrl3KgMY3NYCG4uQ'
    }),
  ],
  providers: [
    AuthGuard,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
