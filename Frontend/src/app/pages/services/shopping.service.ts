import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Shopping } from '../shopping/models/shopping';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingService {
  private baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  addShopping(shopping: Shopping) 
  {
    return this.httpClient.post<Shopping>(`${this.baseUrl}/Shoppings`, shopping)
      .pipe(
        catchError(err => {
          return throwError(() => err)
      })
    );
  }
}
