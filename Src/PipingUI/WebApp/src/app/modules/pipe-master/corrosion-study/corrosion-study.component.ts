import { Component, OnInit, ViewChild, ViewEncapsulation , ElementRef} from '@angular/core';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { PipeReport } from 'src/app/shared/models/PipeReport/pipereport.model';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { CorrosionStudyService } from 'src/app/core/http/corrosion-study/corrosion-study.service';
import { LeftMenuDataService } from 'src/app/shared/services/left-menu-data/left-menu-data.service';

@Component({
  selector: 'app-corrosion-study',
  templateUrl: './corrosion-study.component.html',
  styleUrls: ['./corrosion-study.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CorrosionStudyComponent implements OnInit {

  corrosionList = [];
  breadcrumb:string;
  PipingReportDisplayColumns: string[] = ['select','ReportNo', 'equipmentNo', 'FromTo','Rank', 'Condition', 'Status', 'Result'];  
  corrosionStudyDataSource: any;
  data: any;
  loopNo: any;

  // PipingReportList: PipeReport[] = [
  //   { "ID": "1", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-1", "Criticality": "Low", "Status": "A1-AL1-CS-N, A1-AL1-GS-N ", "DefectCode": "12345", "History": "View" },
  //   { "ID": "2", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-2", "Criticality": "Low", "Status": "A1-AL2-CS-N, A1-AL2-GS-N", "DefectCode": "12345", "History": "View" },
  //   { "ID": "3", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-3", "Criticality": "Meduium", "Status": "A1-AL3-CS-N, A1-AL3-GS-N", "DefectCode": "12345", "History": "View" },
  //   { "ID": "4", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-4", "Criticality": "High", "Status": "A1-AL4-CS-N, A1-AL4-GS-N", "DefectCode": "12345", "History": "View" },
  //   { "ID": "1", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-5", "Criticality": "Low", "Status": "A1-AL5-CS-N, A1-AL5-GS-N", "DefectCode": "12345", "History": "View" },
  //   { "ID": "2", "equipmentNo": "P01.AL1001", "ReportNo": "A1-AL-6", "Criticality": "Low", "Status": "A1-AL6-CS-N, A1-AL6-GS-N", "DefectCode": "12345", "History": "View" }
  // ];

  constructor(
    private router: Router,
    private corrosionStudyService: CorrosionStudyService,
    private sanitizer: DomSanitizer,
    private leftMenuData: LeftMenuDataService
  ) {
    this.breadcrumb ="Ammonia » Ammonia 01 » AL » P01.AL1001";
   }

  ngOnInit(): void {
    this.getCorrosionList();
    this.corrosionStudyDataSource = new MatTableDataSource(this.corrosionList);
  }

  getCorrosionList() {
    this.data = this.leftMenuData.getMenuData();
    const inputData = {
      corrosionStudyID: 0,
      loopNo: '',
      plantCode: this.data.code,
      parentPlantCode: '',
      fluidCode: ''
    }
    this.corrosionStudyService.getCorrosionStudyList(inputData).subscribe((res: any) => {
      console.log(res);
      this.corrosionList = res;
      this.corrosionStudyDataSource = new MatTableDataSource(this.corrosionList);
    })
  }

  onCheckRecord(loopNo) {
    this.loopNo = loopNo;
  }

    onAdd() {
      this.router.navigate(['/pipe-master/edit-corrosion-study']);
    }

  onEditCorrosionStudy() {
    let loopNo;
    for (let i = 0; i < this.corrosionList.length; i++) {
      if (this.loopNo && (this.loopNo === this.corrosionList[i].loopNo)) {
        loopNo = this.loopNo;
      }
    }
    this.router.navigate(['/pipe-master/edit-corrosion-study'], { queryParams: { loopNo: loopNo } });
  }

}
