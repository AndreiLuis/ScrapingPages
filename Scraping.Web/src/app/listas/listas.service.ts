import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient} from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { SiteResult } from './listas.model';
import { Page } from '../consult/consul.model';

@Injectable({
    providedIn: 'root',
})
export class ListasService {

    baseUrl = "https://localhost:44323/Page";

    constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

    showMessage(msg: string, isError: boolean = false): void {
        this.snackBar.open(msg, 'X', {
            duration: 3000,
            horizontalPosition: "right",
            verticalPosition: "top",
            panelClass: isError ? ['msg-error'] : ['msg-success']
        });
    }

    async Result(page: Page): Promise<Observable<SiteResult>> {
        return  await this.http.post<SiteResult>(`${this.baseUrl}/Consult/`, page).pipe(
            map(obj => obj),
            catchError(e => this.errorHandler(e))
        );
    }

    errorHandler(e: any): Observable<any> {
        this.showMessage('Internal Error', true);
        return EMPTY;
    }
}