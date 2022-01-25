import { Component, OnInit } from '@angular/core';
import { Make } from '../models/Make';
import { MakesService } from '../services/makes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  makes: Array<Make>

  constructor(
    private makesService: MakesService) { }

  ngOnInit(): void {
    this.fetchMakes();
  }

  fetchMakes(){
    this.makesService.get().subscribe(data =>{
      this.makes = data;
      console.log(data);
    })
  }
}
