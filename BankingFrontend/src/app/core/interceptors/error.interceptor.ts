import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private snackBar: MatSnackBar) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 400) {
          let message = error.error.details
            ? error.error.details.reduce(
                (res: string, curr: string) => res + curr + ' ',
                ''
              )
            : error.error.message;
          this.snackBar.open(message, 'Close', {
            duration: 3000,
            panelClass: ['error-snackbar'],
          });
        }
        return throwError(error);
      })
    );
  }
}
