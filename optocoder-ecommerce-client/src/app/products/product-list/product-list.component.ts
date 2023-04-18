import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  products : any;
  constructor(private http: HttpClient){
    //get request
    this.http.get('https://dummyjson.com/products').subscribe((data:any) => {
       //data storing for use in html component
      this.products = data.products;
          }, (error:any) => console.error(error));
} 
}
