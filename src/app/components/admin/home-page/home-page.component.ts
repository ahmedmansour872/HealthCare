import { AdminsService } from './../../../services/admin/admins.service';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild, OnChanges } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-pie-chart',
  templateUrl: '../home-page/home-page.component.html',
  styleUrls: ['../home-page/home-page.component.css']
})
export class HomePageComponent implements  OnInit, AfterViewInit {

  pieChart: any;
  totalNumber:any;
  temp:boolean=false;
  arr:any;
  arr2:number[]=[];
  x1:any;

  @ViewChild("pieCanvas") pieCanvas:ElementRef|any


  constructor(private admin:AdminsService) {

  }


  ngOnInit(): void {

    this.admin.getTotalNumberOfPatient().subscribe(res=>this.totalNumber=res);

     this.admin.getNumberOfPatientInClinic().subscribe(res=>
      {
        this.arr=res
        this.arr.forEach((element:any) => {

          this.arr2.push(element.count);

        });

        setTimeout(() => {

          this.pieChartBrowser();

        }, 100);

      });



  }

   ngAfterViewInit(): void {



    setTimeout(() => {

      this.pieChartBrowser();

    }, 100);


  }



  pieChartBrowser(): void {
    this.pieChart = new Chart(this.pieCanvas.nativeElement, {
      type: 'pie',
      data: {
        labels: ['عيادة الاسنان', 'عيادة المسالك البولية', 'عيادة الباطنة', 'عيادة الجراحة العامة ', 'عيادة العظام', 'عيادة العلاج الطبيعي' ,'عيادة الرمد','عيادة القلب','عيادة انف واذن وحنجرة',' عيادة مخ و اعصاب'],
        datasets: [{
          backgroundColor: [
            '#2ecc71',
            '#3498db',
            '#95a5a6',
            '#9b59b6',
            '#f1c40f',
            '#e74c3c',
            '#215e9b',
            '#c941b8',
            '#78babda8',
            '#ddd'
          ],
          data: [this.arr2[5], this.arr2[7], this.arr2[4],this.arr2[3],this.arr2[8],this.arr2[9],this.arr2[1],this.arr2[0],this.arr2[2],this.arr2[6]]
        }]
      }
    });
  }

  appearDocs(){
    this.temp=true;

  }


}
