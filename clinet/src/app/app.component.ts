import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'clinet';
  data:IProduct[];


  constructor(private http: HttpClient) { }

  //#region LifeSycle

  ngOnInit(): void {
    this.http.get('https://localhost:7218/api/product').subscribe(
      (response: IPagination<IProduct>) => {
        console.log(response);
        this.data = response.data;
      },
       error => {console.log(error)});
  }
  //#endregion


}
