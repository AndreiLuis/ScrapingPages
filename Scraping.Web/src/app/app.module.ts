import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';

import { ListasComponent } from './listas/listas.component';
import { ListasService } from './listas/listas.service';
import { ConsultComponent } from './consult/consult.component';

@NgModule({
  declarations: [
    AppComponent,
    ListasComponent,
    ConsultComponent
  ],
  imports: [
    FormsModule,
    MatSnackBarModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', pathMatch: 'full', redirectTo: 'consult' },
      { path: 'consult', component: ConsultComponent, data: {animation: 'ConsultPage'} },
      { path: 'list', component: ListasComponent, data: {animation: 'ListasPage'} },
    ])
],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR'
    },
    ListasService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
