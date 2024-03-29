import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
    this.createCarForm = new FormGroup({
      ownerName: new FormControl('', [Validators.required]),
      numberPlate: new FormControl('', [Validators.required]),
      engineCapacity: new FormControl('', [Validators.required, Validators.min(1)]),
      typeOfColor: new FormControl('', [Validators.required]),
      horsepower: new FormControl('', [Validators.required, Validators.min(1)]),
      makeId: new FormControl('', [Validators.required]),
      modelId: new FormControl('', [Validators.required]),
      images: new FormControl([], [Validators.required]),
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

    if (this.createCarForm.value['images'].length > 3) {
      this.toastrService.info('You can upload up to 3 images...');
      return;
    }

    this.toastrService.info('Creating a new car...');

    const car: CreateCar = Object.assign({}, this.createCarForm.value);
    console.log(this.createCarForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.createCarForm.value)) {
      if (key !== 'images') {
        const value = this.createCarForm.value[key];
        console.log('Key: ' + key + ' Value: ' + value);
        formData.append(key, value);
      }
      else {
        console.log(this.createCarForm.value['images']);

        for (let i = 0; i < this.createCarForm.value['images'].length; i++) {
          formData.append('images', this.createCarForm.value['images'][i]);
        }
      }
    }
    console.log(formData);


    this.carsService.create(formData).subscribe(data => {
      this.toastrService.clear();
      this.toastrService.success("You've created a new car successfully!");
      this.router.navigate(["/"]);
    });

  }

  updateModels(makeId: number) {
    this.modelsService.get(makeId).subscribe(data => {
      this.models = data;
    });
  }

  onFileChanged(event: any) {
    const files = event.target.files;
    console.log(files);
    this.createCarForm.patchValue({
      images: files,
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

  get images() {
    return this.createCarForm.get('images');
  }
}
