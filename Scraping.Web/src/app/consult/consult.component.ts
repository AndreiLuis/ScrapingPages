import { Component, OnInit } from '@angular/core';
import {ConsultService} from './consulta.service'
import { Page } from './consul.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-consult',
  templateUrl: './consult.component.html',
  styleUrls: ['./consult.component.css']
})
export class ConsultComponent implements OnInit {

  page:Page ={
    Link: "",
  }
  link:string = '';
  constructor(private consultService: ConsultService, private router: Router) { }
  
  ngOnInit(): void { }

  async SendToList(link:string): Promise<void>{
    this.page.Link = link;
    await this.router.navigate(["/list"]);
    await this.consultService.Result(this.page);
  }
  
}
