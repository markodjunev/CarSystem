import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateCar } from '../models/CreateCar';
import { Make } from '../models/Make';
import { Model } from '../models/Model';
import { CarsService } from '../services/cars.service';
import { MakesService } from '../services/makes.service';
import { ModelsService } from '../services/models.service';

@Component({
  selector: 'app-create-car',
  templateUrl: './create-car.component.html',
  styleUrls: ['./create-car.component.css']
})
export class CreateCarComponent implements OnInit {
  createCarForm: FormGroup;
  typesOfColor: string[] = ['Black', 'White', 'Blue', 'Red'];
  makes: Array<Make>;
  models: Array<Model>;
  
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toastrService: ToastrService,
    private carsService: CarsService,
    private makesService: MakesService,
    private modelsService: ModelsService
  ) {
    this.createCarForm = this.fb.group({
      'ownerName': ['', [Validators.required]],
      'numberPlate': ['', [Validators.required]],
      'engineCapacity': ['', [Validators.required, Validators.min(1)]],
      'typeOfColor': ['', [Validators.required]],
      'horsepower': ['', [Validators.required, Validators.min(1)]],
      'makeId': ['', [Validators.required]],
      'modelId': ['', [Validators.required]],
    })
  }

  ngOnInit(): void {
    this.makesService.get().subscribe(data => {
      this.makes = data;
    });
  }

  create() {
    if (this.createCarForm.invalid) {
      return;
    }

    this.toastrService.info('Creating a new car...');

    const car: CreateCar = Object.assign({}, this.createCarForm.value);

    this.carsService.create(car).subscribe(data => {
    this.toastrService.clear();
    this.toastrService.success("You've created a new car successfully!");
    this.router.navigate(["/"]);
    });
  }

  updateModels(makeId: number){
    this.modelsService.get(makeId).subscribe(data => {
      this.models = data;
    });
  }

  get ownerName() {
    return this.createCarForm.get('ownerName');
  }

  get numberPlate() {
    return this.createCarForm.get('numberPlate');
  }

  get engineCapacity() {
    return this.createCarForm.get('engineCapacity');
  }

  get typeOfColor() {
    return this.createCarForm.get('typeOfColor');
  }

  get horsepower() {
    return this.createCarForm.get('horsepower');
  }

  get makeId() {
    return this.createCarForm.get('makeId');
  }

  get modelId() {
    return this.createCarForm.get('modelId');
  }
}
