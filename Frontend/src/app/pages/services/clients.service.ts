import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ClientDetail } from '../clients/models/clientDetails';
import { Client } from '../shopping/models/Clients';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  private baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getClients() 
  {
    return this.httpClient.get<Client[]>(`${this.baseUrl}/clients`);
  }

  getClientDetail(id : number) {
    return this.httpClient.get<ClientDetail>(`${this.baseUrl}/clients/${id}`);
  }
}
