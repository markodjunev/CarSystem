import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Model } from '../models/Model';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {
  private modelPath = environment.apiUrl + 'models';
  constructor(private http: HttpClient) { 

  }

  get(id: number): Observable<Model[]> {
    return this.http.get<Model[]>(this.modelPath + '/get/' + id);
  }
}
