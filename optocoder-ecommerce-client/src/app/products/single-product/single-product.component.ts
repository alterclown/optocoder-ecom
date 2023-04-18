import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent  implements OnInit {
  id:any;
  product:any;
  products:any;
  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient) {
    //getting and storing dynamic ID
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    //Single Product WEB API
    this.http.get('https://dummyjson.com/products/'+this.id).subscribe(data => {
      //data storing for use in html component
      this.product = data;
          }, error => console.error(error));
    
  }
  ngOnInit(): void {
    //get request for all the products for realted product section.
    this.http.get('https://dummyjson.com/products/').subscribe(data => {
      //data storing for use in html component
      this.products = data;
          }, error => console.error(error));
    
  }
}
