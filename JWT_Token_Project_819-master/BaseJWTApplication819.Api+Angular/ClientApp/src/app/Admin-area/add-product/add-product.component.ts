import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/Models/product.model';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  product: Product;
  constructor(private productService: ProductService, private router: Router) { }
  ngOnInit() {
  }

  submitAdd() {
    this.productService.addProduct(this.product).subscribe(data => {
      this.router.navigate(['/admin']);
    });
  }

}
