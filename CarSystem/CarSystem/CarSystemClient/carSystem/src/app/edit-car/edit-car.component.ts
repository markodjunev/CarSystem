import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EditCar } from '../models/EditCar';
import { Make } from '../models/Make';
import { Model } from '../models/Model';
import { UpdateCar } from '../models/UpdateCar';
import { CarsService } from '../services/cars.service';
import { MakesService } from '../services/makes.service';
import { ModelsService } from '../services/models.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {
  createCarForm: FormGroup;
  typesOfColor: string[] = ['Black', 'White', 'Blue', 'Red'];
  makes: Array<Make>;
  models: Array<Model>;
  car: UpdateCar;
  id: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
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
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.makesService.get().subscribe(data => {
      this.makes = data;
    });

    this.carsService.getUpdateModel(this.id).subscribe(data => {
      console.log(data);
      this.car = data;
      this.updateModels(this.car.makeId);
      this.createCarForm = this.fb.group({
        'ownerName': [this.car.ownerName, [Validators.required]],
        'numberPlate': [this.car.numberPlate, [Validators.required]],
        'engineCapacity': [this.car.engineCapacity, [Validators.required, Validators.min(1)]],
        'typeOfColor': [this.car.typeOfColor, [Validators.required]],
        'horsepower': [this.car.horsepower, [Validators.required, Validators.min(1)]],
        'makeId': [this.car.makeId, [Validators.required]],
        'modelId': [this.car.modelId, [Validators.required]],
      });
    });
  }

  edit() {
    if (this.createCarForm.invalid) {
      return;
    }

    this.toastrService.info('Edit Car...');

    const editedCar: EditCar = Object.assign({}, this.createCarForm.value);

    this.carsService.edit(this.id, editedCar).subscribe(data => {
      this.toastrService.clear();
      this.toastrService.success("You've edited the car successfully!");
      this.router.navigate(["/"]);
    })
  }

  updateModels(makeId: number) {
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
