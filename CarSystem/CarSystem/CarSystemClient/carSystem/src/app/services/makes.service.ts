import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Make } from '../models/Make';

@Injectable({
  providedIn: 'root'
})
export class MakesService {
  private makePath = environment.apiUrl + 'makes';
  constructor(private http: HttpClient) { 

  }

  get(): Observable<Make[]> {
    return this.http.get<Make[]>(this.makePath + '/get');
  }
}
