import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient} from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Page } from './consul.model';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ConsultService {
    Result$: Observable<any>;
    private resultSubject = new Subject<any>();
    baseUrl = "http://localhost:4200/";

    constructor(private snackBar: MatSnackBar, private http: HttpClient) {
        this.Result$ = this.resultSubject.asObservable();
     }

    showMessage(msg: string, isError: boolean = false): void {
        this.snackBar.open(msg, 'X', {
            duration: 3000,
            horizontalPosition: "right",
            verticalPosition: "top",
            panelClass: isError ? ['msg-error'] : ['msg-success']
        });
    }

    Result(page: Page) {
        this.resultSubject.next(page);
    }

    errorHandler(e: any): Observable<any> {
        this.showMessage('Internal Error', true);
        return EMPTY;
    }
}