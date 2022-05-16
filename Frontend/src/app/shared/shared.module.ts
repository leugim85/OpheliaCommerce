import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { AppRoutingModule } from '../app-routing.module';
import { ErrorMsgDirective } from './directives/error-msg.directive';
import { SharedRoutingModule } from './shared-routing.module';
import { ObjToArrayPipe } from './pipes/obj-to-array.pipe';

@NgModule({
  declarations: [
    SideMenuComponent,
    ErrorMsgDirective,
    ObjToArrayPipe
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
  ],
  exports: [
    SideMenuComponent,
    ErrorMsgDirective,
    ObjToArrayPipe
  ]
})
export class SharedModule { }
