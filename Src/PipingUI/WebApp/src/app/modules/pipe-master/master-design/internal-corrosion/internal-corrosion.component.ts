import { Component, OnInit, Input } from '@angular/core';
import { InternalCorrosion, TMLSummary } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { MatTableDataSource } from '@angular/material/table';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { MatDialog } from '@angular/material/dialog';
import { EditIcDialogComponent } from './edit-ic-dialog/edit-ic-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-internal-corrosion',
  templateUrl: './internal-corrosion.component.html',
  styleUrls: ['./internal-corrosion.component.css']
})
export class InternalCorrosionComponent implements OnInit {

  @Input() unitID;
  internalCorrosionData: any;
  ICDataSource: any;
  IsEditICData: any = false;
  ICData: InternalCorrosion = {
    "ID": "1", "equipmentNo": "P01.AL1001", "InjectionPoints": "", "AllowableStress": "", "YieldStrengh": "", "Efficiency": "", "TensileStregth": "", "PrMinReqThk": "", "MinReqThk": "", "StructuralMinThk": "", "TheoriticalCR": "", "MeasuredLCR": "", "MeasuredSCR": "", "UseMeasuredLCR": "", "UseMeasuredSCR": "", "LastMeasuredThk": "", "LastMesauredYear": "", "EffectiveCR": "", "NoofConfidenceHigh": "", "NoofConfidenceMediumHigh": "", "NoofConfidenceMedium": "", "NoofConfidenceLow": "", "DamageFactor": "", "POF": "", "EffectiveAge": "", "EffectiveThk": ""
  };

  ICDataFields: any[] = [
    { label: 'Injection Points', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'injectioN_POINTS_INTERMITENT' },
    { label: 'Injection Points', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'injectioN_POINTS_INTERMITENT' },
    { label: 'Theoritical CR', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Theoritical CR', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Inspection Confidence', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Inspection Confidence', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },

    { label: 'Allowable Stress', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: '' },
    { label: 'Allowable Stress', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Measured LCR', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Measured LCR', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Very High', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'verY_HIGH' },
    { label: 'Very High', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'verY_HIGH' },

    { label: 'Yield Strength', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: '' },
    { label: 'Yield Strength', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Measured SCR', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Measured SCR', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'High', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'high' },
    { label: 'High', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'high' },

    { label: 'Tensile Strength', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'TensileStrength' },
    { label: 'Tensile Strength', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'TensileStrength' },
    { label: 'Last Measured Thk', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'lasT_MEASURED_THK_FOR_DIA_LMT' },
    { label: 'Last Measured Thk', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'lasT_MEASURED_THK_FOR_DIA_LMT' },
    { label: 'Medium', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'medium' },
    { label: 'Medium', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'medium' },

    { label: 'Efficiency', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: '' },
    { label: 'Efficiency', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Last Measured Year', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'lasT_MEASURED_YEAR_FOR_DIA_LMY' },
    { label: 'Last Measured Year', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'lasT_MEASURED_YEAR_FOR_DIA_LMY' },
    { label: 'Low', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'low' },
    { label: 'Low', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'low' },

    { label: 'Pr Min Req Thk', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: '' },
    { label: 'Pr Min Req Thk', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Effective CR', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Effective CR', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Damage Factor', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'damagE_FACTOR' },
    { label: 'Damage Factor', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'damagE_FACTOR' },

    { label: 'Structural Min Thk', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: '' },
    { label: 'Structural Min Thk', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: '', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: '', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'POF', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'pof' },
    { label: 'POF', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'pof' }
  ];

  ICDisplayedColumns: string[] = ['TMLNo', 'NominalThk', 'Diameter', 'MinReqThk', 'LastMeasuredThk', 'LongTermCR', 'ShortTermCR', 'HalfLife', 'NextInspYear'];

  ICTMLSummaryList: TMLSummary[] = [
    {
      "ID": "1", "equipmentNo": "P01.AL1001", "TMLNo": "01", "DMCode": "IC", "NominalThk": "5.6", "Diameter": "6", "MinReqThk": "3", "LastMeasuredThk": "4.5",
      "LongTermCR": "0.15", "ShortTermCR": "0.1", "HalfLife": "5", "NextInspYear": "2025", "LastInspYear": "2020"
    },
    {
      "ID": "2", "equipmentNo": "P01.AL1001", "TMLNo": "02", "DMCode": "IC", "NominalThk": "5.6", "Diameter": "6", "MinReqThk": "3", "LastMeasuredThk": "4.5",
      "LongTermCR": "0.15", "ShortTermCR": "0.1", "HalfLife": "5", "NextInspYear": "2025", "LastInspYear": "2020"
    },
    {
      "ID": "3", "equipmentNo": "P01.AL1001", "TMLNo": "03", "DMCode": "IC", "NominalThk": "5.6", "Diameter": "6", "MinReqThk": "3", "LastMeasuredThk": "4.5",
      "LongTermCR": "0.15", "ShortTermCR": "0.1", "HalfLife": "5", "NextInspYear": "2025", "LastInspYear": "2020"
    },
    {
      "ID": "4", "equipmentNo": "P01.AL1001", "TMLNo": "04", "DMCode": "IC", "NominalThk": "5.6", "Diameter": "6", "MinReqThk": "3", "LastMeasuredThk": "4.5",
      "LongTermCR": "0.15", "ShortTermCR": "0.1", "HalfLife": "5", "NextInspYear": "2025", "LastInspYear": "2020"
    },
  ];

  constructor(
    private pipeMasterService: PipeMasterService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
    ) { }

  ngOnChanges() {
    this.getInternalCorrosionData(this.unitID);
  }

  ngOnInit(): void {
    this.ICDataSource = new MatTableDataSource(this.ICTMLSummaryList);
    this.getInternalCorrosionData(this.unitID);
  }

  getInternalCorrosionData(unitID) {
    this.pipeMasterService.getInternalCorrosionData(unitID).subscribe(data => {
      this.internalCorrosionData = data;
    });
  }

  EditICData() {
    this.IsEditICData = true;
  }

  onEditData() {
    const editData = this.dialog.open(EditIcDialogComponent, {
      width: '850px',
      data: { icData: this.internalCorrosionData, id: this.unitID }
    });
    editData.afterClosed().subscribe(result => {
      if (result) {
        this.pipeMasterService.updateInternalCorrosionData(result).subscribe((res: any) => {
          this.snackBar.open('Successfully updated', '', {
            duration: 5000,
          });
          this.ngOnInit();
        }, (error) => {
          switch (error.status) {
            case 415:
              this.snackBar.open('Unable to update', '', {
                duration: 5000,
              });
              break;
          }
        })
      } else {
        return;
      }
    })
  }

}
