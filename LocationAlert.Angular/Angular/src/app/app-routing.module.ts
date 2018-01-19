import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { WeatherpreferencesComponent } from './weatherpreferences/weatherpreferences.component';
import { AuthGuard } from './auth.guard';
import { RegionsComponent } from './regions/regions.component';

const routes: Routes = [
  {
    path: 'login',
    component: HomeComponent
  },
  {
    path: 'preferences',
    component: PreferencesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'weatherpreferences',
    component: WeatherpreferencesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'regions',
    component: RegionsComponent,
    canActivate: [AuthGuard]
  },

  // otherwise redirect to preferences
  // { path: '**', redirectTo: '/preferences' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
