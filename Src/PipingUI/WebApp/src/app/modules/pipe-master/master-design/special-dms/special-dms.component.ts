import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { POFOTDM } from 'src/app/shared/models/pipemaster/pipemaster.model';

@Component({
  selector: 'app-special-dms',
  templateUrl: './special-dms.component.html',
  styleUrls: ['./special-dms.component.css']
})
export class SpecialDMsComponent implements OnInit {

  ODMDataSource: any;
  ODMDisplayedColumns: string[] = ['DMCode', 'Description', 'InitialSuceptability', 'SeverityIndex', 'VeryHigh', 'High', 'Medium', 'Low', 'Found', 'DamageReductionFactor', 'DamageFactor', 'POF'];
  POFODMList: POFOTDM[] = [
    {
      "ID": "1", "equipmentNo": "P01.AL1001", "DMCode": "IC", "Description": "Internal", "InitialSuceptability": "6", "SeverityIndex": "3", "VeryHigh": "0",
      "High": "0", "Medium": "0", "Low": "0", "Found": "1", "DamageReductionFactor": "1", "DamageFactor": "1", "POF": "1"
    },
    {
      "ID": "2", "equipmentNo": "P01.AL1001", "DMCode": "IC", "Description": "Internal", "InitialSuceptability": "6", "SeverityIndex": "3", "VeryHigh": "0",
      "High": "0", "Medium": "0", "Low": "0", "Found": "1", "DamageReductionFactor": "1", "DamageFactor": "1", "POF": "1"
    },
    {
      "ID": "3", "equipmentNo": "P01.AL1001", "DMCode": "IC", "Description": "Internal", "InitialSuceptability": "6", "SeverityIndex": "3", "VeryHigh": "0",
      "High": "0", "Medium": "0", "Low": "0", "Found": "1", "DamageReductionFactor": "1", "DamageFactor": "1", "POF": "1"
    },
    {
      "ID": "4", "equipmentNo": "P01.AL1001", "DMCode": "IC", "Description": "Internal", "InitialSuceptability": "6", "SeverityIndex": "3", "VeryHigh": "0",
      "High": "0", "Medium": "0", "Low": "0", "Found": "1", "DamageReductionFactor": "1", "DamageFactor": "1", "POF": "1"
    }
  ];

  barChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'bottom',
      labels: {
        fontFamily: 'sans-serif',
        fontSize: 10,
      }
    }
  };
  barChartLabels: Label[] = ['2018', '2019', '2020'];
  barChartType: ChartType = 'bar';
  barChartLegend = true;
  barChartPlugins = [];

  barChartData: ChartDataSets[] = [
    { data: [65, , ], label: 'Good', backgroundColor: '#4BC073' },
    { data: [, 59, 80], label: 'Acceptable', backgroundColor: '#D0833B' }

  ];
  constructor() { }

  ngOnInit(): void {
    this.ODMDataSource = new MatTableDataSource(this.POFODMList);
  }

}
