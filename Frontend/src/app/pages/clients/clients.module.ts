import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientsRoutingModule } from './clients-routing.module';
import { HistoricClientComponent } from './historic-client/historic-client.component';
import { CardDetailsComponent } from './card-details/card-details.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    HistoricClientComponent,
    CardDetailsComponent
  ],
  imports: [
    CommonModule,
    ClientsRoutingModule,
    FormsModule,
    SharedModule
  ]
})
export class ClientsModule { }
