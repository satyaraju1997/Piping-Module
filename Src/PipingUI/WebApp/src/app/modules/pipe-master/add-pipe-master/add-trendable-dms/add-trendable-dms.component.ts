import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-add-trendable-dms',
  templateUrl: './add-trendable-dms.component.html',
  styleUrls: ['./add-trendable-dms.component.css']
})
export class AddTrendableDmsComponent implements OnInit {

  trendableDisplayedColumns: string[] = [
    'DM Code',
    'POF (Auto calculated)',
    'Adjusted POF',
    'Criticality Rank Auto based on POF & COF. (H/MH/M/L)',
    'Criticality Factor (H=1,MH=2,M=3,L=4) (CF)',
    'Found',
    'Last Insp Confidence',
    'Confidence Factor (VH=4,H=3,M=2,L=1) (ICF)',
    'Next Insp Reduction factor NIRF=(CF*ICF)',
    'Max Inspection interval (Management table) (MI)',
    'Next Rec Inspection frequency NIF = (MI/NIR) years',
    'Last Insp Year (LIY) or YIS',
    'Next Insp Year (NIY)=NIF+LIY',
    'DM name'
  ];
  trendableDataSource = '';

  constructor() { }

  ngOnInit(): void {
  }

}
