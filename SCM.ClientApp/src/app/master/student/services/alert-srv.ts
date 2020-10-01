import { Injectable } from '@angular/core';
import PNotify from 'pnotify/dist/es/PNotify';
PNotify.defaults.styling = 'bootstrap3';
PNotify.defaults.icons = 'bootstrap3';
@Injectable({
    providedIn: 'root'
  })
  export class AlertService {
    alertSuccess = function (message: string) {
        PNotify.success({
          text: message,
          delay: 5000,
          buttons: {
            closer: true,
    
          }
        });
      }
      alertError = function (message: string) {
        PNotify.error({
          text: message,
          delay: 5000,
          buttons: {
            closer: true,
    
          }
        });
      }
  }