import { Component, OnInit, ElementRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CorrosionStudyService } from 'src/app/core/http/corrosion-study/corrosion-study.service';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { LeftMenuDataService } from 'src/app/shared/services/left-menu-data/left-menu-data.service';
import { MatTabGroup } from '@angular/material/tabs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-corrosion-study',
  templateUrl: './add-corrosion-study.component.html',
  styleUrls: ['./add-corrosion-study.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddCorrosionStudyComponent implements OnInit {

  formData: FormData;
  @ViewChild('fileUpload', { static: false }) fileUpload: ElementRef;
  @ViewChild(MatTabGroup) tabGroup: MatTabGroup;
  displayFileName: any = [];
  fileName: string = 'SheetJS.xlsx';
  files: File[] = [];
  isValid: boolean;
  corrosionLoopData: FormGroup;
  cof: FormGroup;
  iow: FormGroup;
  cluster: FormGroup;
  clusterTab = [];
  dmGuideList = [];
  cofDataSource: any;
  iowDataSource: any;
  data: any;
  clusterData: any = null;
  editCorrosion;
  corrosionData: any;
  clusterNames = [];

  clusters = [];
  cofData = [];
  iowData = [];
  clusterList = [];
  clusterDisplayColumns: string[] = [
    'source',
    'fluid',
    'subFluid',
    'dmCode',
    'dmType',
    'dmRate',
    'dMDescription',
    'guideDocument',
    'add'
  ];

  clusterDatasource: any;

  toxicCalculationDisplayColumns: string[] = [
    'RefresentativeFluid',
    'FluidPhaseStored',
    'DetectionRating',
    'IsolationRating',
    'MitigationFactor',
    'ToxicReferenceFluid',
    'ToxicFluidFraction',
    'add'
  ];

  iowDisplayColumns: string[] = [
    'iowNo',
    'parameter',
    'unit',
    'max',
    'min',
    'tagNo',
    'relatedequipmentNos',
    'add'
  ]
  newClusters: any;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private corrosionStudyService: CorrosionStudyService,
    private sanitizer: DomSanitizer,
    private leftMenuData: LeftMenuDataService,
    private snackBar: MatSnackBar,
  ) {
    this.formData = new FormData();
  }

  ngOnInit(): void {
    this.data = this.leftMenuData.getMenuData();
    const inputData = {
      corrosionStudyID: 0,
      loopNo: 'A1-AB-1',
      plantCode: this.data.code,
      parentPlantCode: '',
      fluidCode: ''
    }
    this.corrosionStudyService.getPipeCluster(inputData).subscribe((res: any) => {
      this.clusterData = res;
      this.corrosionData = this.clusterData.corrosionStudyDTO;
      this.cofData = this.clusterData.cofMasterDTOList;
      this.iowData = this.clusterData.iowdtoList;
      this.clusters = this.clusterData.pipeClusterPOFDTOList;
      this.newClusters = this.clusterData.pipeClusterPOFDTOList;
      if (this.clusterData) {
        this.initializeForm();
        this.cofDataSource = new MatTableDataSource(this.cofData);
        this.iowDataSource = new MatTableDataSource(this.iowData);
        this.clusterDatasource = new MatTableDataSource(this.clusters[0].dmGuideList);
      }
    })
  }

  initializeForm() {
    this.corrosionLoopData = this.fb.group({
      id: [this.corrosionData.id],
      plantCode: [this.corrosionData.plantCode],
      fluidCode: [this.corrosionData.fluidCode],
      subFluidCode: [this.corrosionData.subFluidCode],
      loopNo: [this.corrosionData.loopNo],
      minTemp: [this.corrosionData.minTemperature],
      maxTemp: [this.corrosionData.maxTemperature],
      maxPressure: [this.corrosionData.maxPressure],
      minPressure: [this.corrosionData.minPressure],
      processDesc: [this.corrosionData.processDescription]
    }),

      this.cof = this.fb.group({
        id: [0],
        refresentativeFluid: [],
        fluidPhase: ['Liquid'],
        detectionRating: ['A'],
        isolationRating: ['A'],
        mitigationFactor: [],
        toxicRefFluid: [],
        toxicFluidFraction: []
      }),

      this.iow = this.fb.group({
        id: [0],
        iowNo: [],
        parameter: [],
        unit: [],
        max: [],
        min: [],
        tagNo: [],
        relUnitNos: []
      }),

      this.cluster = this.fb.group({
        fluid: [],
        dmGuideID: [0],
        dmCode: [],
        dmDescription: [],
        dmType: [],
        dmRate: [],
        dmGuideDocument: [],
        source: [],
      })
  }

  onAddCOF() {
    this.cof.getRawValue();
    const data = this.cofDataSource.data;
    data.push(this.cof.getRawValue());
    this.cofDataSource._updateChangeSubscription();
    this.cof.reset();
  }

  onDeleteCOF(i) {
    const index = this.cofDataSource.data[i.id];
    this.cofDataSource.data.splice(index, 1);
    this.cofDataSource._updateChangeSubscription();
  }

  onAddIOW() {
    this.iow.getRawValue();
    const data = this.iowDataSource.data;
    data.push(this.iow.getRawValue());
    this.iowDataSource._updateChangeSubscription();
    this.iow.reset();
  }

  onDeleteIOW(i) {
    const index = this.iowDataSource.data[i.id];
    this.iowDataSource.data.splice(index, 1);
    this.iowDataSource._updateChangeSubscription();
  }

  selectedTab(data) {
    let data1 = this.newClusters.filter(cluster => cluster.clusterNo === data.tab.textLabel)
    this.clusterDatasource.data = data1[0].dmGuideList;
    this.clusterDatasource._updateChangeSubscription();
  }

  onAddCluster(clusterNo) {
    let newCluster = this.cluster.getRawValue();
    let data = this.newClusters.filter(cluster => cluster.clusterNo === clusterNo);
    data[0].dmGuideList.push(newCluster);
    this.clusterDatasource.data = data[0].dmGuideList;
    this.clusterDatasource._updateChangeSubscription();
  }

  onDelete(i) {
    const index = this.clusterDatasource.data[i.id];
    this.clusterDatasource.data.splice(index, 1);
    this.clusterDatasource._updateChangeSubscription();
  }

  onFileChange(event: any) {
    let files = event.dataTransfer ? event.dataTransfer.files : event.target.files;
    for (let i = 0; i < files.length; i++) {
      let file = files[i];

      if (this.validate(file)) {
        var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
        file.objectURL = this.sanitizer.bypassSecurityTrustUrl((window.URL.createObjectURL(files[i])));
        this.files.push(files[i]);
        this.displayFileName.push({ id: 0, name: file.name, extension: ext, icon: 'assets/' + ext + '_icon.svg' });
      }
    }
  }

  validate(file: File) {
    var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
    if (ext.toLowerCase() != 'csv' && ext.toLowerCase() != 'xls' && ext.toLowerCase() != 'xlsx'
      && ext.toLowerCase() != 'pdf'
      && ext.toLowerCase() != 'doc' && ext.toLowerCase() != 'docx'
      && ext.toLowerCase() != 'jpg' && ext.toLowerCase() != 'jpeg'
      && ext.toLowerCase() != 'png' && ext.toLowerCase() != 'bmp') {
      this.isValid = true;
      return false;
    }
    else {
      this.isValid = false;
      return true;
    }
  }

  onClick(event) {
    if (this.fileUpload)
      this.fileUpload.nativeElement.click()
  }

  fileRemove(name) {
    let file = this.displayFileName.find(d => d.name === name);
    let index = this.displayFileName.findIndex(d => d.name === name);
    if (file.id === 0) {
      this.displayFileName.splice(index, 1);
    }
    else {
      this.displayFileName.splice(index, 1);
    }
  }

  onBack() {
    this.router.navigate(['/pipe-master/corrosion-study']);
  }

  onSubmit() {
    let corrosionData = {
      'loopNo': this.clusterData.loopNo,
      'corrosionStudyDTO': this.corrosionLoopData.getRawValue(),
      'cofMasterDTOList': this.cofDataSource.data,
      'iowdtoList': this.iowDataSource.data,
      'pipeClusterPOFDTOList': this.newClusters
    }
    this.formData.append('CorrosionStudyInfo', JSON.stringify(corrosionData));
    this.corrosionStudyService.addCorrosionStudy(this.formData).subscribe((res) => {
      this.snackBar.open('Successfully added ' + res.loopNo, '', {
        duration: 5000,
      });
    })
  }
}
