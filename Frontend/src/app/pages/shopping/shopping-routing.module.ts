import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddShoppingComponent } from './add-shopping/add-shopping.component';

const routes: Routes = [
  {
    path:"",
    children: [
      {path:"agregar", component: AddShoppingComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShoppingRoutingModule { }
