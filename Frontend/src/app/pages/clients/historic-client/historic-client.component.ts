import { Component, OnInit } from '@angular/core';
import { ClientsService } from '../../services/clients.service';
import { Client } from '../../shopping/models/Clients';
import { ClientDetail } from '../models/clientDetails';

@Component({
  selector: 'app-historic-client',
  templateUrl: './historic-client.component.html',
  styleUrls: ['./historic-client.component.css']
})
export class HistoricClientComponent implements OnInit {

  clients!: Client[];
  clientDetails!: ClientDetail;
  idString: string="";
  id: number = 0;

  constructor(private clientsService: ClientsService) { }

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients() {
    this.clientsService.getClients().subscribe(clients => this.clients = clients);
  }

  getDetails() {
    if (this.idString == "") {
      this.id = 0;
    }
     this.id = parseInt(this.idString);
  }
}
