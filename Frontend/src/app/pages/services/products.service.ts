import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../products/models/product';
import { NewProduct } from '../products/models/newProduct';
import { catchError, of, throwError } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UpdateProduct } from '../products/models/updateProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private baseUrl: string = environment.baseUrl; 
  constructor(private httpClient: HttpClient) { }

  getProducts() {
    return this.httpClient.get<Product[]>(`${this.baseUrl}/Products`);
  }

  addNewProduct(product : NewProduct) {
    return this.httpClient.post<NewProduct>(`${this.baseUrl}/Products`, product)
    .pipe(
      catchError(err => {
          return throwError(() => err)
      })
    );
  }

  deleteProduct(id: number) {
    return this.httpClient.delete<void>(`${this.baseUrl}/Products?id=${id}`)
  }

  updateProduct(product: UpdateProduct) {
    return this.httpClient.put<void>(`${this.baseUrl}/Products`, product)
      .pipe(
        catchError(err => {
            return throwError(() => err)
        })
      );
  }

  getProductById(id: number) {
    return this.httpClient.get<NewProduct>(`${this.baseUrl}/Products/${id}`);
  }
}

