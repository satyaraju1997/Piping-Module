import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PofIcService } from 'src/app/core/http/pof-ic/pof-ic.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-pof-ic-calc',
  templateUrl: './pof-ic-calc.component.html',
  styleUrls: ['./pof-ic-calc.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class PofIcCalcComponent implements OnInit {

  pofIcForm: FormGroup;
  pofIcDataSource: any;
  equipmentNo: any;

  pofIcDisplayedColumns: string[] = [
    'Line No',
    'Corrosion Type',
    'Effective Thk (ETHK)',
    'Min Req Thk (MRT)',
    'Effective Corr Rate (EICR/EECR)',
    'Flow Stress (FS)',
    'Stength Ratio (SR)',
    'Effective Age (Internal/External)',
    'Art',
    'VH',
    'H',
    'M',
    'L',
    '1* corrosion rate (IE-1)',
    '2* corrosion rate (IE-2)',
    '3* corrosion rate (IE-3)',
    '1* corrosion rate (Posp-1)',
    '2* corrosion rate (Posp-2)',
    '3* corrosion rate (Posp-3)',
    'Beta-1',
    'Beta-2',
    'Beta-3',
    'DamageFactor',
    'POFExpo',
    'POF'
  ];

  constructor(
    private fb: FormBuilder,
    private pofIcService: PofIcService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.pofIcForm = this.fb.group({
      equipmentNo: [''],
      presentYear: ['']
    });
  }

  onSearch() {
    const equipment_no = this.pofIcForm['controls'].equipmentNo.value;
    const present_year = this.pofIcForm['controls'].presentYear.value;
    if(equipment_no && present_year) {
      this.pofIcService.getPOFICDetails(equipment_no, present_year).subscribe((res: any) => {
        this.pofIcDataSource = new MatTableDataSource(res);
        this.equipmentNo = equipment_no;
      });
    }
  }

}
