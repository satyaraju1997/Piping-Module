import { Component, OnInit, Input } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { BasicData, InspectionStrategy } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { MatTableDataSource } from '@angular/material/table';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { MatDialog } from '@angular/material/dialog';
import { EditBasicDialogComponent } from './edit-basic-dialog/edit-basic-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-basic-data',
  templateUrl: './basic-data.component.html',
  styleUrls: ['./basic-data.component.css']
})
export class BasicDataComponent implements OnInit {

  @Input() unitID;
  basicData: any;

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
    { data: [65, ,], label: 'Good', backgroundColor: '#4BC073' },
    { data: [, 59, 80], label: 'Acceptable', backgroundColor: '#D0833B' }

  ];

  basicDataSource: any;
  IsEditBasicData: any = false;
  displayedColumns: string[] = ['dmCode', 'description', 'priority', 'frequency', 'recommendedProgram', 'edit'];

  inspectionStrategyList: InspectionStrategy[] = [
    { "ID": "1", "equipmentNo": "P01.AL1001", "dmCode": "IC", "description": "Internal", "priority": "18", "frequency": "10", "recommendedProgram": "TM at all elbows" },
    { "ID": "2", "equipmentNo": "P01.AL1001", "dmCode": "EC", "description": "External", "priority": "10", "frequency": "14", "recommendedProgram": "100% visual" },
    { "ID": "1", "equipmentNo": "P01.AL1001", "dmCode": "IC", "description": "Internal", "priority": "18", "frequency": "10", "recommendedProgram": "TM at all elbows" },
    { "ID": "2", "equipmentNo": "P01.AL1001", "dmCode": "EC", "description": "External", "priority": "10", "frequency": "14", "recommendedProgram": "100% visual" },
    { "ID": "1", "equipmentNo": "P01.AL1001", "dmCode": "IC", "description": "Internal", "priority": "18", "frequency": "10", "recommendedProgram": "TM at all elbows" },
    { "ID": "2", "equipmentNo": "P01.AL1001", "dmCode": "EC", "description": "External", "priority": "10", "frequency": "14", "recommendedProgram": "100% visual" }
  ];

  // Piping Matrix
  MatrixData: any = {
    "A1": "1", "A2": "3", "A3": "5", "A4": "10", "A5": "12",
    "B1": "2", "B2": "6", "B3": "9", "B4": "15", "B5": "19",
    "C1": "4", "C2": "8", "C3": "14", "C4": "18", "C5": "22",
    "D1": "7", "D2": "13", "D3": "17", "D4": "21", "D5": "24",
    "E1": "11", "E2": "16", "E3": "20", "E4": "23", "E5": "25"
  };

  MatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'E1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'D1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'C1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'B1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'A1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'E2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'D2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'C2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'B2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'A2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'D3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'C3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'B3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FF4E4E', field: 'A3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'D4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'C4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'B4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'A4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'D5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'C5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'B5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'A5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
  ];

  constructor(
    private basicDataService: PipeMasterService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private updateDataService: PipeMasterService
  ) { }

  ngOnChanges() {
    this.getBasicData(this.unitID);
  }

  ngOnInit(): void {
    this.getBasicData(this.unitID);
  }

  getBasicData(unitID) {
    this.basicDataSource = new MatTableDataSource(this.inspectionStrategyList);
    this.basicDataService.getBasicData(this.unitID).subscribe(data => {
      this.basicData = data;
    });
  }

  onEditData() {
    const editData = this.dialog.open(EditBasicDialogComponent, {
      width: '850px',
      data: { basicData: this.basicData }
    });
    editData.afterClosed().subscribe(result => {
      if (result) {
        this.updateDataService.updateBasicData(result).subscribe((res: any) => {
          this.snackBar.open('Successfully updated', '', {
            duration: 5000,
          });
          this.getBasicData(this.unitID);
        }, (error) => {
          switch (error.status) {
            case 415:
              this.snackBar.open('Unable to update', '', {
                duration: 5000,
              });
              break;
          }
        }
        )
      } else {
        return;
      }
    })
  }

}
