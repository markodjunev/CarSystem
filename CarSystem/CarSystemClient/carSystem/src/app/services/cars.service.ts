import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CarByMake } from '../models/CarByMake';
import { CreateCar } from '../models/CreateCar';
import { EditCar } from '../models/EditCar';
import { UpdateCar } from '../models/UpdateCar';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  private carPath = environment.apiUrl + 'cars';
  constructor(private http: HttpClient) { 

  }

  getCarsByMake(id: number): Observable<CarByMake[]> {
    return this.http.get<CarByMake[]>(this.carPath + '/carsbymake/' + id)
  }

  delete(id: number){
    return this.http.delete(this.carPath + '/delete/' + id);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(this.carPath + '/create', data, {
      reportProgress: true,
      observe: 'events'
    });
  }

  getUpdateModel(id: number) : Observable<UpdateCar> {
    return this.http.get<UpdateCar>(this.carPath + '/updatemodel/' + id);
  }

  edit(id: number, data: EditCar) : Observable<EditCar>{
    return this.http.put<EditCar>(this.carPath + '/edit/' + id, data);
  }
}
