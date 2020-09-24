import { Injectable } from '@angular/core';
import { DatePipe, CurrencyPipe } from '@angular/common';
import pdfMake from 'pdfmake/build/pdfMake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { PipeReportService } from 'src/app/core/http/pipe-report/pipe-report.service';
import { PipeReport, Recommendation, Observation, TML, PdfReportAction, PdfReportType } from 'src/app/shared/models/pipe-report/pipe-report.model';
pdfMake.vfs = pdfFonts.pdfMake.vfs;
@Injectable({
  providedIn: 'root'
})
export class PdfReportService {
  documentDefinition: any;
  companyName : any;
  companyLogo :any;
  pipeReportData: any = null;
  companyData: any = null;
  reportHeader: any;
  inspectionObservationList = [];
  inspectionConfidenceList = [];
  inspectionRecommendationList = [];
  inspectionDocumentList = [];
  inspectionProgramList = [];
  tmlList = [];
  constructor(private _reportService: PipeReportService, public datePipe: DatePipe, public currencyPipe: CurrencyPipe) {

    //, public datePipe: DatePipe, public currencyPipe: CurrencyPipe) {
  }



  formatDate(date) {
    return this.datePipe.transform(date, 'dd/MM/yyyy');
  }
  formatCurreny(value) {
    //  return this.currencyPipe.transform(value, 'INR', 'symbol-narrow', '1.2-2');
  }

  generatePdfReport(reportNumber: string, reportType: PdfReportType, reportAction: PdfReportAction) {
    this._reportService.getCompany(1).subscribe(res => {
      if(res)
      {
      this.companyData = res;
      this.companyName = this.companyData.name;
      this.companyLogo = this.companyData.logoContent;
      }

    });
    
    this._reportService.getDataByReportNo(reportNumber).subscribe(result => {
      if (result) {
        this.pipeReportData = result;
        this.reportHeader = this.pipeReportData.pipeReport;
        this.inspectionObservationList = this.pipeReportData.inspectionObservationList;
        this.inspectionConfidenceList = this.pipeReportData.inspectionConfidenceList;
        this.inspectionRecommendationList = this.pipeReportData.inspectionRecommendationList;
        this.inspectionProgramList = this.pipeReportData.inspectionProgramList;
        //   this.inspectionDocumentList = result.inspectionDocumentList;
        this.tmlList = this.pipeReportData.tmlList;
        this.generatePipeReport();

        switch (reportAction) {
          case PdfReportAction.Open: {
            pdfMake.createPdf(this.documentDefinition).open();
            break;
          }
          case PdfReportAction.Download: {
            pdfMake.createPdf(this.documentDefinition).download();
            break;
          }
          case PdfReportAction.Print: {
            pdfMake.createPdf(this.documentDefinition).print();
            break;
          }
          default: {
            pdfMake.createPdf(this.documentDefinition).open();
            break;
          }
        }
      }
    }, error => {

    });
  }
  programTable(): any {
    var table = [];
    var header = new Array('PROGRAM');
    table.push(header);
    this.inspectionProgramList.forEach(element => {
      var row = new Array();
      row.push(element.program);
      table.push(row);
    });
    return table;
  }

  observationTable(): any {
    var table = [];
    var header = new Array('OBSERVATION');
    table.push(header);
    if (this.inspectionObservationList && this.inspectionObservationList.length) {
      this.inspectionObservationList.forEach(element => {
        var row = new Array();
        row.push(element.observation);
        table.push(row);
      });
    }
    return table;
  }

  tmlTable(): any {
    var table = [];
    var header = new Array('TML NO', 'TYPE', 'COMPONENT', 'NOM DIA', 'NOM THK', 'YIS', 'MSD THK');
    table.push(header);
    if (this.tmlList && this.tmlList.length) {
      this.tmlList.forEach(element => {
        var row = new Array();
        row.push(element.tmlNo);
        row.push(element.corrosionType);
        row.push(element.componentType);
        row.push(element.nominalDiameter);
        row.push(element.nominalThick);
        row.push(element.yearInService);
        row.push(element.measuredThick);
        table.push(row);
      });
    }
    return table;
  }

  confidenceTable(): any {
    var table = [];
    var header = new Array('DM', 'PROGRAM', 'PRIORITY', 'FREQUENCY', 'CONFIDENCE');
    table.push(header);
    if (this.inspectionConfidenceList && this.inspectionConfidenceList.length) {
      this.inspectionConfidenceList.forEach(element => {
        var row = new Array();
        row.push(element.damageMechanism);
        row.push(element.inspectionProgram);
        row.push(element.priority);
        row.push(element.frequency);
        row.push(element.confidenceLevel);
        table.push(row);
      });
    }
    return table;
  }

  recommendationTable(): any {
    var table = [];
    var header = new Array('SL NO', 'RECOMMENDATION', 'ACTION', 'RESPONSIBLE', 'TARGET', 'WO');
    table.push(header);
    if (this.inspectionRecommendationList && this.inspectionRecommendationList.length) {
      this.inspectionRecommendationList.forEach(element => {
        var row = new Array();
        row.push(element.serialNo);
        row.push(element.recommendedAction);
        row.push(element.actionCategory);
        row.push(element.responsible);
        row.push(element.targetDate);
        row.push(element.woNumber);
        table.push(row);
      });
    }
    return table;
  }





  generatePipeReport() {
    this.documentDefinition = {
      info: {
        title: 'PIPING INSPECTION REPORT',
        author: 'SENECA GLOBAL',
        subject: 'Piping Inspection Report',
        keywords: 'Piping Inspection Report'
      },
      content: [
        // {
        //   text: 'Company',
        //   style: 'pageHeading',
        //   margin: [0, 0, 0, 5]
        // },
        // {
        //   text: 'Piping Inspection Report',
        //   style: 'pageHeading',
        //   margin: [0, 0, 0, 5]
        // },
        {
          columns: [
          [{
                    image: "data:image/png;base64," + this.companyLogo,
                    width: 50,
                    height: 50,  
                  //  text: this.companyLogo ,        
                  //  style: 'pageHeading',
                    alignment: 'left'
                    
          }],
          [{
                    text: this.companyName,
                    style: 'pageHeading',
                    color: '#003D7E',
                    margin: [0, 0, 0, 5]
                  },
                  {
                    text: 'PIPING INSPECTION REPORT',
                    style: 'pageHeading',
                    margin: [0, 0, 0, 5]
          }],
          [{ qr: this.reportHeader.equipmentNo, fit: '60', margin: [0, 0, 0, 10], alignment: 'right' }]
          ]
        },
        {
          canvas: [{ type: 'line', x1: 0, y1: 0, x2: 515, y2: 0, lineWidth: 2 }],
          margin: [0, 0, 0, 10]
        },
        {
          columns: [
            [
              {
                columns: [{
                  width: '40%',
                  text: 'Report No:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.reportNo,
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'Date:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.formatDate(this.reportHeader.createdDate),
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'Unit No: ',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.equipmentNo,
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'From To:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.fromTo,
                  style: 'headerData'
                }]
              }
            ],
            [
              {
                columns: [{
                  width: '40%',
                  text: 'Plant:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.plantCode,
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'Fluid:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.fluid,
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'Material: ',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.material,
                  style: 'headerData'
                }]
              },
              {
                columns: [{
                  width: '40%',
                  text: 'Cluster No:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.clusterNo,
                  style: 'headerData'
                }]
              }
            ],
            [  
              {
                columns: [{
                  width: '60%',
                  text: 'Overall Risk:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.overallCondition,
                  style: 'headerData'
                }]
              } , 
              
              {
                columns: [{
                  width: '60%',
                  text: 'Overall Status:',
                  bold: true,
                  style: 'headerData'
                },
                {
                  width: '60%',
                  text: this.reportHeader.overallStatus,
                  style: 'headerData'
                }]
              } ,           
              {
                columns: [
                  {
                    width: '60%',
                    text: 'Revised Status:',
                    bold: true,
                    style: 'headerData'
                  },
                  {
                    width: '40%',
                    text: this.reportHeader.revisedStatus,
                    style: 'headerData'
                  }]
              }
            ],
          ],
          margin: [0, 0, 0, 10]
        },

        {

          table: {
            headerRows: 1,
            widths: ['100%'],
            body: this.programTable()
          },
          margin: [0, 0, 0, 10]
        },
        {
          table: {
            headerRows: 1,
            widths: ['10%', '18%', '20%', '13%', '13%', '13%', '13%'],
            body: this.tmlTable()
          },
          margin: [0, 0, 0, 10]
        },
        {
          table: {
            headerRows: 1,
            widths: ['100%'],
            body: this.observationTable()
          },
          margin: [0, 0, 0, 10]
        },

        {
          table: {
            headerRows: 1,
            widths: ['10%', '40%', '15%', '15%', '20%'],
            body: this.confidenceTable()
          },
          margin: [0, 0, 0, 10]
        },
        {
          table: {
            headerRows: 1,
            widths: ['10%', '30%', '15%', '20%', '12%', '13%'],
            body: this.recommendationTable()
          }
        }

      ],
      styles: {
        pageHeading: {
          bold: true,
          fontSize: 15,
          alignment: 'center',
          margin: [0, 0, 0, 0]
        },
        header: {
          fontSize: 18,
          bold: true,
          margin: [0, 0, 0, 0],
          decoration: 'underline'
        },
        name: {
          fontSize: 12,
          bold: true
        },
        jobTitle: {
          fontSize: 14,
          bold: true,
          italics: true
        },
        headerTitle: {
          fontSize: 12,
          bold: true,
          margin: [0, 1]
        },
        headerData: {
          fontSize: 12,
          margin: [0, 2]
        },
      }
    };
  }
}