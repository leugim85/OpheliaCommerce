import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { ProductsListComponent } from './products-list/products-list.component';

const routes: Routes = [
  {
    path:'',
    children:[
      { path: 'list', component: ProductsListComponent },
      { path: 'add', component: AddProductComponent },
      { path: 'update/:id', component: AddProductComponent },
      { path: '**', redirectTo: 'list' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
