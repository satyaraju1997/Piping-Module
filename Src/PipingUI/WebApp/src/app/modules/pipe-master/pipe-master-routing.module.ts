import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PipeMasterComponent } from './pipe-master.component';
import { MasterDesignComponent } from './master-design/master-design.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PipeReportComponent } from './pipe-report/pipe-report.component';
import { PofIcCalcComponent } from './pof-ic-calc/pof-ic-calc.component';
import { AddPipeMasterComponent } from './add-pipe-master/add-pipe-master.component';
import { StructuralMinThk } from '../../shared/models/lookup/lookup.model';
import { StructuralMinThkComponent } from './structural-min-thk/structural-min-thk.component';
import { RiskAnalysisComponent } from './risk-analysis/risk-analysis.component';
import { CorrosionStudyComponent } from './corrosion-study/corrosion-study.component';
import { InspectionProgramComponent } from './inspection-program/inspection-program.component';
import { LookupTablesComponent } from './lookup-tables/lookup-tables.component';
import { AddPipeReportComponent } from './pipe-report/add-pipe-report/add-pipe-report.component';
import { EditPipeReportComponent } from './pipe-report/edit-pipe-report/edit-pipe-report.component';
import { AddCorrosionStudyComponent } from './corrosion-study/add-corrosion-study/add-corrosion-study.component';
import { EditCorrosionStudyComponent } from './corrosion-study/edit-corrosion-study/edit-corrosion-study/edit-corrosion-study.component';
import { PipeImportComponent } from './pipe-import/pipe-import.component';

const routes: Routes = [
    {
        path: '',
        component: PipeMasterComponent,
        children: [
            {
                path: 'dashboard',
                component: DashboardComponent,
            },
            {
                path: 'master-design',
                component: MasterDesignComponent,
            },
            {
                path: 'pipe-report',
                component: PipeReportComponent,
            },
            {
                path: 'add-pipe-report',
                component: AddPipeReportComponent
            },
            {
                path: 'edit-pipe-report',
                component: EditPipeReportComponent
            },
            {
                path: 'pof-ic-calc',
                component: PofIcCalcComponent,
            },
            {
                path: 'add-pipe-master',
                component: AddPipeMasterComponent,
            },
            {
                path: 'lookup-tables',
                component:LookupTablesComponent,
            },
            {
                path: 'risk-analysis',
                component:RiskAnalysisComponent,
            },
            {
                path: 'inspection-program',
                component:InspectionProgramComponent,
            },
            {
                path: 'corrosion-study',
                component: CorrosionStudyComponent,
            },
            {
                path: 'add-corrosion-study',
                component: AddCorrosionStudyComponent,
            },
            {
                path: 'edit-corrosion-study',
                component: EditCorrosionStudyComponent,
            },
            {
                path: 'lookup-structural-min-thk',
                component: StructuralMinThkComponent,
            },
            {
                path: 'pipe-import',
                component: PipeImportComponent,
            }
            
        ]
    }
];


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class PipeMasterRoutingModule {
    static components = [
        PipeMasterComponent,
        DashboardComponent,
        PipeReportComponent,
        MasterDesignComponent,
        PofIcCalcComponent,
        AddPipeMasterComponent,
        PipeImportComponent,
        StructuralMinThkComponent,
    ]
}
