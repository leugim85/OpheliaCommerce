import { Pipe, PipeTransform } from '@angular/core';
import { ClientDetail, Shopping } from '../../pages/clients/models/clientDetails';

@Pipe({
  name: 'objToArray'
})
export class ObjToArrayPipe implements PipeTransform {

  transform(object: any = []): any {
    
    return Object.values(object);
  }

}
