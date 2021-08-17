import { Component, OnInit } from '@angular/core';
import { Page } from './consul.model';

@Component({
  selector: 'app-consult',
  templateUrl: './consult.component.html',
  styleUrls: ['./consult.component.css']
})
export class ConsultComponent implements OnInit {

  urlParam:string = '';
  page: Page ={
    Link :'',
  }

  constructor() { }
  
  ngOnInit(): void { }

  
}
