import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarDetails } from '../models/CarDetails';
import { CarsService } from '../services/cars.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {
  id: number;
  car: CarDetails

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
    
    this.fetchCar();
  }

  fetchCar(){
    this.carsService.getCarDetails(this.id).subscribe(
    data => {
      this.car = data; 
    },
    error => {
      console.log(error);
      this.router.navigate(["/"]);
    });
  }

  delete(carId: number){
    this.carsService.delete(carId).subscribe(data =>{
      this.router.navigate(["/"]);
    });
  }
}
