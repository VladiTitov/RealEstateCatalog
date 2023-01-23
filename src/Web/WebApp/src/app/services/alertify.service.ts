import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }
onSuccess(message: string){
  alertify.success(message);
}

onError(message: string) {
  alertify.error(message);
}

onWarning(message: string){
  alertify.warning(message);
}
}
