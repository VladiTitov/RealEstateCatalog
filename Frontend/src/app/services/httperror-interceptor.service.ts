import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, concatMap, Observable, of, retry, retryWhen, throwError } from "rxjs";
import { ErrorCode } from "../enums/enums";
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
        retryWhen(error => this.retryRequest(error, 10)),
        catchError((error: HttpErrorResponse) => this.exceptionHandler(error))
      );
  }

  retryRequest(error: Observable<HttpErrorResponse>, retryCount: number) : Observable<HttpErrorResponse> {
    return error.pipe(
      concatMap((checkErr: HttpErrorResponse, count: number) => {
        if (count <= retryCount) {
          switch (checkErr.status) {
            case ErrorCode.serverDown:
              return of(checkErr);
          }
        }
        return throwError(checkErr);
      })
    )
  }

  exceptionHandler(error: HttpErrorResponse) {
    const errorMessage = this.setError(error);
    console.log(error);
    this.alertify.onError(errorMessage);
    return throwError(errorMessage);
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
