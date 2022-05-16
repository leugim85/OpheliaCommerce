import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {
          NgxMatDatetimePickerModule,
          NgxMatNativeDateModule,
          NgxMatTimepickerModule
       } from '@angular-material-components/datetime-picker';
import { ShoppingRoutingModule } from './shopping-routing.module';
import { AddShoppingComponent } from './add-shopping/add-shopping.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    AddShoppingComponent
  ],
  imports: [
    CommonModule,
    ShoppingRoutingModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    NgxMatTimepickerModule,
    SharedModule
  ]
})
export class ShoppingModule { }
