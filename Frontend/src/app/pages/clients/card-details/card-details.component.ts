import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

import { ClientsService } from '../../services/clients.service';
import { ClientDetail, Product, Shopping } from '../models/clientDetails';

@Component({
  selector: 'app-card-details',
  templateUrl: './card-details.component.html',
  styleUrls: ['./card-details.component.css']
})
export class CardDetailsComponent implements OnChanges {

  @Input() id!:number;
  client!: ClientDetail;
  shoppings!: Shopping[];
  products!: Product[];

  constructor(private clientsService: ClientsService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.loadDetails();
  }

  loadDetails() {
    if(isNaN(this.id) || this.id == 0) 
    {
      this.id = 0;
      return;
    }

    this.clientsService.getClientDetail(this.id).subscribe(client => {
       this.client = client;
       this.shoppings = this.client.shoppings;
       });
    };
}


