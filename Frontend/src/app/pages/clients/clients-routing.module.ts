import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoricClientComponent } from './historic-client/historic-client.component';

const routes: Routes = [
  {
    path: "",
    children:[
      {path: "historicClient", component: HistoricClientComponent}
    ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientsRoutingModule { }
