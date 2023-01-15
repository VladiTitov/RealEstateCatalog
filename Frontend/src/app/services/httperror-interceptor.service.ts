import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { AlertifyService } from "./alertify.service";

@Injectable({
  providedIn: 'root'
})

export class HttpErrorInterceptorService implements HttpInterceptor {

  constructor(private alertify: AlertifyService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    console.log("HTTP Request started.");
    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          const errorMessage = this.setError(error);
          console.log(error);
          this.alertify.onError(errorMessage);
          return throwError(errorMessage);
        })
      );
  }

  setError(error: HttpErrorResponse) : string {
    let errorMessage = "Unknown error occured";
    if (error.error instanceof ErrorEvent) {
      //Client side error
      errorMessage = error.error.message;
    } else {
      //Server side error
      if (error.status!==0) {
        errorMessage = error.error.errorMessage;
      }
    }
    return errorMessage;
  }
}