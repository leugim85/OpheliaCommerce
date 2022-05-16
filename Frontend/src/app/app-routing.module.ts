import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SideMenuComponent } from './shared/side-menu/side-menu.component';

const routes: Routes = [
  {
    path: 'products',
    loadChildren: () => import('./pages/products/products.module').then(m => m.ProductsModule)
  },
  {
    path: 'shoppings',
    loadChildren: () => import('./pages/shopping/shopping.module').then(m => m.ShoppingModule)
  },
  {
    path: 'clients',
    loadChildren: () => import('./pages/clients/clients.module').then(m => m.ClientsModule)
  },
  {
    path: "home",
    component: SideMenuComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
