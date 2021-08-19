import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Chart } from 'chart.js';
import { Imagem, Page } from '../consult/consul.model';
import { ConsultService } from '../consult/consulta.service';
import { ListasService } from './listas.service'

@Component({
  selector: 'app-listas',
  templateUrl: './listas.component.html',
  styleUrls: ['./listas.component.css']
})
export class ListasComponent implements OnInit {

  //show:any = undefined;
  imagens:Imagem[] = [{
    Url: '',
  }];

  words = [];

  page: Page = {
    Link: '',
  }
  constructor(private listaService: ListasService, private consultService: ConsultService) {
    this.consultService.Result$.subscribe((page) => {
      this.page = page;
      this.ConsultPage(this.page);
    })
  }

  ngOnInit(): void {
      this.words = undefined;
      this.imagens = undefined;
  }

  validList(): boolean {
    if ((this.words == undefined || this.words == [])
      && (this.imagens == undefined || this.words == []))
      return false
    else
      return true
  }

  drawChart() {

    var xValues = this.words.map(function (p: any) {
      return p.quantity;
    });
    var yValues = this.words.map(function (p: any) {
      return p.value;
    });
    // this.canvas = document.getElementById('myChart');
    // this.ctx = this.canvas.getContext('2d');
    const chart = new Chart('myChart', {
      type: "pie",
      data: {
        labels: yValues,
        datasets: [{
          data: xValues,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)',
            'rgba(255, 102, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(170, 102, 255, 0.2)',
            'rgba(20, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)',
            'rgba(255, 102, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(170, 102, 255, 0.2)',
            'rgba(20, 159, 64, 0.2)'
          ],
          borderWidth: 0
        }]
      },
      options: {}
    }
    );

  }

  ConsultPage(page: Page) {
    var img;
    this.listaService.Result(page).then(result =>(
      result.subscribe(a => {
        
      // this.pieChartData = result.Words.map(function(x){
      //   return x.Quantity;
      // });
      img = a.images;
      this.words = a.words;
      //this.drawChart();
      })
    ));
    this.imagens = img;
    //this.show = this.validList();
  }

}
