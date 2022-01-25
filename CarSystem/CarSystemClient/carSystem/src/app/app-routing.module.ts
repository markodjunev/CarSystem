import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarsByMakeComponent } from './cars-by-make/cars-by-make.component';
import { CreateCarComponent } from './create-car/create-car.component';
import { EditCarComponent } from './edit-car/edit-car.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent},
  { path: 'carsByMake/:id', component: CarsByMakeComponent},
  { path: 'create', component: CreateCarComponent},
  { path: 'edit/:id', component: EditCarComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
