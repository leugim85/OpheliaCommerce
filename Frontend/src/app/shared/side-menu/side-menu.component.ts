import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

import { MenuItem } from '../models/menuItem';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {

  sideMenuItems: MenuItem[]=[
    { description: "Lista De Productos", route: "../products/List", icon: "list_alt" },
    { description: "Agregar Nuevo Producto", route: "../products/add", icon: "add_circle_outline" },
    { description: "Agregar Nueva Compra", route: "../shoppings/agregar", icon:"shopping_cart" },
    { description: "Historico Por Cliente", route: "../clients/historicClient", icon:"history" }
  ]
  currentRoute!: Location;

  constructor( private location: Location) { 
    this.currentRoute =this.location;
  }

  ngOnInit(): void {
  }

}
