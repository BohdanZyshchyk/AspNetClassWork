import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product.model';
import { ApiResponse } from '../Models/api.response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient
  ) { }
  baseUrl = "/api/Product";
  getAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl)
  }

  addProduct(product: Product): Observable<ApiResponse> {
    const response = this.getPostResponse('add', product);
    return response;
  }

  deleteProduct(id: number): Observable<Product[]> {
    const response = this.http.post<Product[]>(`${this.baseUrl}/delete`, { id: id });
    return response;
  }

  editProduct(product: Product): Observable<ApiResponse> {
    const response = this.getPostResponse('edit', product);
    return response;
  }

  searchProduct(search: string): Observable<Product[]> {
    const params = new HttpParams().set('search', search);
    const response = this.http.get<Product[]>(`${this.baseUrl}/search`, {
      params: params
    });
    return response;
  }

  private getPostResponse(urlTail: string, data: any): Observable<ApiResponse> {
    const url = `${this.baseUrl}/${urlTail}`;
    const response = this.http.post<ApiResponse>(url, data);
    return response;
  }

}
