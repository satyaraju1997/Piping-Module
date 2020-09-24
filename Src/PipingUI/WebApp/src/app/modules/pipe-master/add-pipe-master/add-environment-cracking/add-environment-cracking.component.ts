import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-environment-cracking',
  templateUrl: './add-environment-cracking.component.html',
  styleUrls: ['./add-environment-cracking.component.css']
})
export class AddEnvironmentCrackingComponent implements OnInit {

  trendableDisplayedColumns: string[] = [
    'DM Code',
    'Initial Sucep (corrosion study)',
    'Severity Score (From corr study)',
    'Adjusted Suspeta',
    'Severity Index',
    'Found',
    'VH',
    'H',
    'M',
    'L',
    'Last Insp Year VH',
    'Reduction Factor',
    'Effective Age',
    'Damage Factor',
    'POF',
    'DM name'
  ];
  trendableDataSource = '';
  
  constructor() { }

  ngOnInit(): void {
  }

}
