import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarByMake } from '../models/CarByMake';
import { CarsService } from '../services/cars.service';

@Component({
  selector: 'app-cars-by-make',
  templateUrl: './cars-by-make.component.html',
  styleUrls: ['./cars-by-make.component.css']
})
export class CarsByMakeComponent implements OnInit {
  id: number;
  cars: Array<CarByMake>

  constructor(
    private carsService: CarsService,
    private route: ActivatedRoute,
    private router: Router
    ) {
      
     }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    
    this.fetchCars();
  }

  fetchCars(){
    this.carsService.getCarsByMake(this.id).subscribe(data => {
      this.cars = data;
      console.log(this.cars);
    })
  }
}
