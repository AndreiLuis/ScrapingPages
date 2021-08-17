import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Page } from '../consult/consul.model';
import { SiteResult } from './listas.model';
import { ListasService } from './listas.service'

@Component({
  selector: 'app-listas',
  templateUrl: './listas.component.html',
  styleUrls: ['./listas.component.css']
})
export class ListasComponent implements OnInit {


  images:object[] = [
    {
      Url: ''
    }
  ];

  words:object[] = [
    {
      Value: '',
      Quantity: 0
    }
  ];

  page: Page ={
    Link :'',
  }
  constructor(private listaService: ListasService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    var pageUrl = this.route.snapshot.paramMap.get('page');
    this.page = JSON.parse(pageUrl);
    this.ConsultPage(this.page);
  }

  drawChart() {
    var google:any;
    var data = google.visualization.arrayToDataTable(this.words);

    var options = {
      title: ''
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);
  }

  ConsultPage(page:Page) {
    this.listaService.Result(page).subscribe(result => {
      // this.pieChartData = result.Words.map(function(x){
      //   return x.Quantity;
      // });
      this.words = result.Words;
      this.images = result.Images;
    });
  }

}
