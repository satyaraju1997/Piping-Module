import { Component, OnInit, ViewEncapsulation,  ViewChild, ElementRef} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { BasicDataComponent } from 'src/app/modules/pipe-master/master-design/basic-data/basic-data.component';
import { DomSanitizer } from '@angular/platform-browser';
import * as XLSX from 'xlsx';
type AOA = any[][];
@Component({
  selector: 'app-master-design',
  templateUrl: './master-design.component.html',
  styleUrls: ['./master-design.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MasterDesignComponent implements OnInit {
  @ViewChild(BasicDataComponent) private basicDataComponent: BasicDataComponent;
  @ViewChild('fileUpload', { static: false }) fileUpload: ElementRef;
  IsAdd:any = false;
  IsUpload:any = false;
  IsView:any = true;
  IsEdit:any = false;
  unitID: any;
  breadcrumb:string;
  displayFileName: any = [];
  data: AOA = [[], []];
  wopts: XLSX.WritingOptions = { bookType: 'xlsx', type: 'array' };
  fileName: string = 'SheetJS.xlsx';
  files: File[] = [];
  isValid:boolean;
  isWaitSpinner: boolean = false;

  constructor(
    private route: ActivatedRoute, 
    private pipeMasterService: PipeMasterService, 
    private sanitizer: DomSanitizer,
    private router: Router  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.unitID = params.ID;
      this.getCurrentItem();
    });
  }

  getCurrentItem() {    
    this.pipeMasterService.getCurrentItem(this.unitID).subscribe(data => {
      //this.unitID = data.id;
      this.breadcrumb = data.breadCrumb;    
     // this.basicDataComponent.getBasicData(this.unitID);        
    });
  }

 
  getNextItem() {     
    this.pipeMasterService.getNextItem(this.unitID).subscribe(data => {    
      this.unitID = data.id;
      this.breadcrumb = data.breadCrumb;
      this.basicDataComponent.getBasicData(this.unitID); 
    });
  }

  getPreviousItem() {    
    this.pipeMasterService.getPreviousItem(this.unitID).subscribe(data => {
      this.unitID = data.id;
      this.breadcrumb = data.breadCrumb;
      this.basicDataComponent.getBasicData(this.unitID); 
    });
  }

  AddMaster() {
    this.router.navigate(['/pipe-master/add-pipe-master/'], { queryParams: {ID: this.unitID}});
  }

  ViewMaster()
  {
    this.IsView = true;
    this.IsAdd = false;
    this.IsUpload = false;    
    this.IsEdit = false;
  }

  UploadPipe()
  {
    this.IsAdd = false;
    this.IsUpload = true;
    this.IsView = false;
    this.IsEdit = false;
  }

 EditPipe()
  {
    this.IsAdd = false;
    this.IsUpload = false;
    this.IsView = false;
    this.IsEdit = true;
  }



  onFileChange(event: any) {
    debugger
    this.isWaitSpinner = true;
    let files = event.dataTransfer ? event.dataTransfer.files : event.target.files;
    for (let i = 0; i < files.length; i++) {
      let file = files[i];
      if (this.validate(file)) {
        file.objectURL = this.sanitizer.bypassSecurityTrustUrl((window.URL.createObjectURL(files[i])));
        this.files.push(files[i]);
        this.displayFileName.push({ id: 0, name: file.name });
      }
    }
    /* wire up file reader */
    const target: DataTransfer = <DataTransfer>(event.target);
    if (target.files.length !== 1) throw new Error('Cannot use multiple files');
    const reader: FileReader = new FileReader();
    reader.onload = (e: any) => {
      /* read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* save data */
      this.data = <AOA>(XLSX.utils.sheet_to_json(ws, { header: 1 }));
      console.log(this.data);

    };
    reader.readAsBinaryString(target.files[0]);
    this.isWaitSpinner = false;
  }

  validate(file: File) {
    var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
    // for (const f of this.files) {
    // if (f.name === file.name && f.lastModified === file.lastModified && f.size === f.size) {
    //   return false
    // }

    if ( ext.toLowerCase() != 'csv' && ext.toLowerCase() != 'xls'
      && ext.toLowerCase() != 'xlsx') {
      this.isValid = true;
      return false;
    }
    else {
      this.isValid = false;
      return true;
    }
    // }

  }

  export(): void {
    /* generate worksheet */
    const ws: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(this.data);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, this.fileName);
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
}
