import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ɵangular_packages_platform_browser_platform_browser_j } from '@angular/platform-browser';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService, private router: Router) {}


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((httpError:HttpErrorResponse) => {

        if(httpError) {
          switch(httpError.status) {
            case 400:
              if (httpError.error.message) {
                this.toastr.error(httpError.error.message, httpError.error.statusCode)
              }
              break;
            case 404:
              this.router.navigateByUrl('/not-found', {state: {error: httpError.error}});
              break;
            case 500:
              this.router.navigateByUrl('/server-error', {state: {error: httpError.error}});
              break;
          }

          return throwError(httpError.error);
        }
        return throwError({message: 'Unknown error'});
      })
    );
  }
}
