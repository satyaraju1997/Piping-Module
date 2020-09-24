import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { ThemeModule } from '../../core/theme.module';
import { PipeMasterRoutingModule } from './pipe-master-routing.module';
import { ChartsModule } from 'ng2-charts';
import { BasicDataComponent } from './master-design/basic-data/basic-data.component';
import { SpecialDMsComponent } from './master-design/special-dms/special-dms.component';
import { CofComponent } from './master-design/cof/cof.component';
import { InternalCorrosionComponent } from './master-design/internal-corrosion/internal-corrosion.component';
import { ExternalCorrosionComponent } from './master-design/external-corrosion/external-corrosion.component';
import { DesignDataComponent } from './master-design/design-data/design-data.component';
import { EditDataDialogComponent } from './master-design/design-data/edit-data-dialog/edit-data-dialog.component';
import { EditIcDialogComponent } from './master-design/internal-corrosion/edit-ic-dialog/edit-ic-dialog.component';
import { AddPipeMasterComponent } from './add-pipe-master/add-pipe-master.component';
import { AddBasicDataComponent } from './add-pipe-master/add-basic-data/add-basic-data.component';
import { AddDesignDataComponent } from './add-pipe-master/add-design-data/add-design-data.component';
import { AddInternalCorrosionComponent } from './add-pipe-master/add-internal-corrosion/add-internal-corrosion.component';
import { AddExternalCorrosionComponent } from './add-pipe-master/add-external-corrosion/add-external-corrosion.component';
import { AddEnvironmentCrackingComponent } from './add-pipe-master/add-environment-cracking/add-environment-cracking.component';
import { StructuralMinThkComponent } from './structural-min-thk/structural-min-thk.component';
import { DialogStructuralMinThkComponent } from './structural-min-thk/dialog-structural-min-thk/dialog-structural-min-thk.component';
import { RiskAnalysisComponent } from './risk-analysis/risk-analysis.component';
import { InspectionProgramComponent } from './inspection-program/inspection-program.component';
import { AddTrendableDmsComponent } from './add-pipe-master/add-trendable-dms/add-trendable-dms.component';
import { AddNonTrendableDmsComponent } from './add-pipe-master/add-non-trendable-dms/add-non-trendable-dms.component';
import { EditEcDialogComponent } from './master-design/external-corrosion/edit-ec-dialog/edit-ec-dialog.component';
import { EditCofDialogComponent } from './master-design/cof/edit-cof-dialog/edit-cof-dialog.component';
import { EditBasicDialogComponent } from './master-design/basic-data/edit-basic-dialog/edit-basic-dialog.component';
import { CorrosionStudyComponent } from './corrosion-study/corrosion-study.component';
import { AddCofComponent } from './add-pipe-master/add-cof/add-cof.component';
import { SpinnerComponent } from 'src/app/shared/components/spinner/spinner.component';
import { EditStructuralMinDialogComponent } from './structural-min-thk/edit-structural-min-dialog/edit-structural-min-dialog.component';
import { LookupTablesComponent } from './lookup-tables/lookup-tables.component';
import { AddPipeReportComponent } from './pipe-report/add-pipe-report/add-pipe-report.component';
import { EditPipeReportComponent } from './pipe-report/edit-pipe-report/edit-pipe-report.component';
import { AddCorrosionStudyComponent } from './corrosion-study/add-corrosion-study/add-corrosion-study.component';
import { ObservationsDialogComponent } from './pipe-report/observations-dialog/observations-dialog.component';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { EditCorrosionStudyComponent } from './corrosion-study/edit-corrosion-study/edit-corrosion-study/edit-corrosion-study.component';
import { PipeImportComponent } from './pipe-import/pipe-import.component';

@NgModule({
  declarations: [
    PipeMasterRoutingModule.components,
    BasicDataComponent,
    SpecialDMsComponent,
    CofComponent,
    InternalCorrosionComponent,
    ExternalCorrosionComponent,
    DesignDataComponent,
    EditDataDialogComponent,
    EditIcDialogComponent,
    AddPipeMasterComponent,
    AddBasicDataComponent,
    AddDesignDataComponent,
    AddInternalCorrosionComponent,
    AddExternalCorrosionComponent,
    AddEnvironmentCrackingComponent,
    StructuralMinThkComponent,
    DialogStructuralMinThkComponent,
    RiskAnalysisComponent,
    InspectionProgramComponent,
    AddCofComponent,    
    AddTrendableDmsComponent,
    AddNonTrendableDmsComponent,
    EditEcDialogComponent,
    EditCofDialogComponent,
    EditBasicDialogComponent,
    CorrosionStudyComponent,
    SpinnerComponent,
    EditStructuralMinDialogComponent,
    LookupTablesComponent,
    AddPipeReportComponent,
    ObservationsDialogComponent,
    EditPipeReportComponent,
    AddCorrosionStudyComponent,
    EditCorrosionStudyComponent,
    PipeImportComponent
      ],
  imports: [
    ChartsModule,
    PipeMasterRoutingModule,
    CommonModule,
    ThemeModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  exports: [SpinnerComponent],
  entryComponents: [
    EditDataDialogComponent,
    EditIcDialogComponent,
    DialogStructuralMinThkComponent,
    ObservationsDialogComponent
  ],
  
  providers: [DatePipe, CurrencyPipe]
})
export class PipeMasterModule { }
