import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Product } from 'src/app/Models/product.model';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  searchInput: string;
  constructor(private prodService:ProductService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.prodService.getAllProducts().subscribe(
      data =>{
        console.log(data);
        this.listOfData = data
        this.spinner.hide();
      }
    )
  }
  search() {
    console.log(this.searchInput);
    this.prodService.searchProduct(this.searchInput).subscribe(data => {
      console.log(data);
      this.products = data;
      console.log(this.products);
    });
  }

  delete(id: number) {
    console.log(id);
    this.prodService.deleteProduct(id).subscribe(data => {
      this.products = data;
    });
  }
  listOfColumn = [
    {
      title: 'Image',
    },
    {
      title: 'Title',
    },
    {
      title: 'Price',
    },
    {
      title: 'Description',
    }
  ];
  listOfData: Product[] = [];

}
