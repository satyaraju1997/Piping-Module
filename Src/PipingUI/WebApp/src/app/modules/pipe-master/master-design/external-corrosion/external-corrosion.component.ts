import { Component, OnInit, Input } from '@angular/core';
import { InternalCorrosion, TMLSummary } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { MatTableDataSource } from '@angular/material/table';
import { EditEcDialogComponent } from './edit-ec-dialog/edit-ec-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-external-corrosion',
  templateUrl: './external-corrosion.component.html',
  styleUrls: ['./external-corrosion.component.css']
})
export class ExternalCorrosionComponent implements OnInit {

  @Input() unitID;
  externalCorrosion: any;
  ICData: InternalCorrosion = {
    "ID": "1", "equipmentNo": "P01.AL1001", "InjectionPoints": "", "AllowableStress": "", "YieldStrengh": "", "Efficiency": "", "TensileStregth": "", "PrMinReqThk": "", "MinReqThk": "", "StructuralMinThk": "", "TheoriticalCR": "", "MeasuredLCR": "", "MeasuredSCR": "", "UseMeasuredLCR": "", "UseMeasuredSCR": "", "LastMeasuredThk": "", "LastMesauredYear": "", "EffectiveCR": "", "NoofConfidenceHigh": "", "NoofConfidenceMediumHigh": "", "NoofConfidenceMedium": "", "NoofConfidenceLow": "", "DamageFactor": "", "POF": "", "EffectiveAge": "", "EffectiveThk": ""
  };

  ECDataSource: any;
  IsEditECData: any = false;
  ECDisplayedColumns: string[] = ['TMLNo', 'NominalThk', 'Diameter', 'MinReqThk', 'LastMeasuredThk', 'LongTermCR', 'ShortTermCR', 'HalfLife', 'NextInspYear'];

  ECTMLSummaryList: TMLSummary[] = [
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
    private dialog: MatDialog,
    private pipeMasterService: PipeMasterService,
    private snackBar: MatSnackBar
  ) { }

  ngOnChanges() {
    this.getExternalCorrosionData(this.unitID);
  }

  ngOnInit(): void {
    this.ECDataSource = new MatTableDataSource(this.ECTMLSummaryList);
    this.getExternalCorrosionData(this.unitID);
  }

  getExternalCorrosionData(unitID) {
    this.pipeMasterService.getExternalCorrosionData(unitID).subscribe(res => {
      this.externalCorrosion = res;
    })
  }

  onEditData() {
    const editData = this.dialog.open(EditEcDialogComponent, {
      width: '850px',
      data: { ecData: this.externalCorrosion, id: this.unitID }
    });
    editData.afterClosed().subscribe(result => {
      if(result) {
        this.pipeMasterService.updateExternalCorrosionData(result).subscribe((res: any) => {
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
