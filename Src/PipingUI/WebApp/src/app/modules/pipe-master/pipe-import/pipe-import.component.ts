import { Component, OnInit,ViewEncapsulation, ViewChild,  ElementRef } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import {  LoaderHelperService } from 'src/app/shared/services/loader-helper.service';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as XLSX from 'xlsx';
type AOA = any[][];

@Component({
  selector: 'app-pipe-import',
  templateUrl: './pipe-import.component.html',
  styleUrls: ['./pipe-import.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class PipeImportComponent implements OnInit {
  @ViewChild('fileUpload', { static: false }) fileUpload: ElementRef;

  displayFileName: any = [];
  data: AOA = [[], []];
  wopts: XLSX.WritingOptions = { bookType: 'xlsx', type: 'array' };
  fileName: string = 'SheetJS.xlsx';
  files: File[] = [];
  dataUpload:File;
  isValid:boolean;
  isWaitSpinner: boolean = false;
  rows:string;
  jsonData = null;
  formData: FormData;

  constructor(
    private sanitizer: DomSanitizer, 
    private loaderHelperService: LoaderHelperService, 
    private pipeMasterService: PipeMasterService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  onFileChange(event: any) {
    this.loaderHelperService.showLoader();
    this.isWaitSpinner = true;
    let files = event.dataTransfer ? event.dataTransfer.files : event.target.files;
    for (let i = 0; i < files.length; i++) {
      let file = files[i];
      if (this.validate(file)) {
        this.dataUpload = files[i];
        var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
        file.objectURL = this.sanitizer.bypassSecurityTrustUrl((window.URL.createObjectURL(files[i])));
        this.files.push(files[i]);
        this.displayFileName.push({ id: 0, name: file.name,extension:ext , icon:'assets/' + ext + '_icon.svg', size: Math.round(file.size / 1024) + " KB" });
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
      this.jsonData = (XLSX.utils.sheet_to_json(ws, { header: 1 }));
      this.rows = (this.data.length - 1) + " lines";
    //  debugger
    //   console.log(JSON.stringify(this.jsonData));

    };
    reader.readAsBinaryString(target.files[0]);
    this.isWaitSpinner = false;
    this.loaderHelperService.hideLoader();
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


  onImport() {
    // this.loaderHelperService.showLoader();
     const formData: FormData = new FormData();
    
     formData.append('formFile', this.dataUpload);     

    this.pipeMasterService.uploadPipeMaster(formData).subscribe(res => {   
      console.log(res);
      this.snackBar.open('Successfully imported' , 'PIPE MASTER', {
        duration: 5000,
      });
    });

    
  }

}
