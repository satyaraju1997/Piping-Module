import { Component, OnInit } from '@angular/core';
import { COF } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { MatDialog } from '@angular/material/dialog';
import { EditCofDialogComponent } from './edit-cof-dialog/edit-cof-dialog.component';

@Component({
  selector: 'app-cof',
  templateUrl: './cof.component.html',
  styleUrls: ['./cof.component.css']
})
export class CofComponent implements OnInit {

  IsEditCOFData: any = false;
  EditCOFData() {
    this.IsEditCOFData = true;
  }

  COFTabSections: any[] = [
    { title: 'COF Data', cols: 1, rows: 1, border: '10px solid #DBDBDB', class: 'grid' }   
  ];

  COFData:COF ={
    "ID":"1","equipmentNo":"P01.AL1001","PipeClusterNo":"","CorrosionLoopNo":"","ApplicableFluid":"","NormalBoilingPoint":"","MolecularWeight":"","Fluid":"","FluidPhaseStored":"","FluidPhaseAtReleasedCondition":"","MassOfInventoryFluid":"","DetectionSystemRating":"","IsolationSystemRating":"","ComponentType":"","LengthOfComponent":"","MassOfFluidInComponent":"","InnerDiameterOfComponent":"","OperatingTemperature":"","OperatingPressure":""
  };

  COFDataFields: any[] = [
    { label: 'Applicable Fluid as per Table 4.1', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'ApplicableFluid' },
    { label: 'Applicable Fluid as per Table 4.1', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'ApplicableFluid' },
    { label: 'Fluid', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'Fluid' },
    { label: 'Fluid', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'Fluid' },
    { label: 'Mass of Inventory Fluid Minv', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'MassOfInventoryFluid' },
    { label: 'Mass of Inventory Fluid Minv', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'MassOfInventoryFluid' },
    { label: 'Length of Component, l mm', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'LengthOfComponent' },
    { label: 'Length of Component, l mm', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'LengthOfComponent' },
    
    { label: 'Normal Boiling Point  0C', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'NormalBoilingPoint' },
    { label: 'Normal Boiling Point  0C', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'NormalBoilingPoint' },
    { label: 'Operating Temperature Ts K', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'OperatingTemperature' },
    { label: 'Operating Temperature Ts K', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'OperatingTemperature' },
    { label: 'Detection System Rating (Default C)', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'DetectionSystemRating' },
    { label: 'Detection System Rating (Default C)', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'DetectionSystemRating' },
    { label: 'Mass of Fluid in component Mcomp (L*D*Density)', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'MassOfFluidInComponent' },
    { label: 'Mass of Fluid in component Mcomp (L*D*Density)', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'MassOfFluidInComponent' },
    
    { label: 'Molecular Weight', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'MolecularWeight' },
    { label: 'Molecular Weight', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'MolecularWeight' },
    { label: 'Operating Pressure Ps KPa', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'OperatingPressure' },
    { label: 'Operating Pressure Ps KPa', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'OperatingPressure' },
    { label: 'Fluid Phase at released condition', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'FluidPhaseAtReleasedCondition' },
    { label: 'Fluid Phase at released condition', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'FluidPhaseAtReleasedCondition' },
    { label: 'Inner diameter of Component, d mm (OD-2*Thk)', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'InnerDiameterOfComponent' },
    { label: 'Inner diameter of Component, d mm (OD-2*Thk)', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'InnerDiameterOfComponent' },

    { label: 'Fluid Phase stored', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'FluidPhaseStored' },
    { label: 'Fluid Phase stored', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'FluidPhaseStored' },
    { label: 'Component Type', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'ComponentType' },
    { label: 'Component Type', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'ComponentType' },
    { label: 'Isolation system rating (Default C)', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Isolation system rating (Default C)', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Toxic Reference fluid', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Toxic Reference fluid', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },

    { label: 'COF Flammable', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'FluidPhaseStored' },
    { label: 'COF Flammable', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'FluidPhaseStored' },
    { label: 'COF Toxic', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: 'ComponentType' },
    { label: 'COF Toxic', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'ComponentType' },
    { label: 'COF Non Flam/Toxic', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'COF Non Flam/Toxic', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Toxic Fluid %', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Toxic Fluid %', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' },

    { label: '', isLabel: true, cols: 1, rows: 1, class: 'grid-Data', field: 'FluidPhaseStored' },
    { label: '', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: 'FluidPhaseStored' },
    { label: 'Production Loss', isLabel: true, cols: 1, rows: 1, class: 'grid-data', field: '' },
    { label: 'Production Loss', isLabel: false, cols: 1, rows: 1, class: 'grid-data', field: '' }
   
  ];
  
  constructor(
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
  }

  onEditData() {
    const editData = this.dialog.open(EditCofDialogComponent, {
      width: '900px'
    });
    editData.afterClosed().subscribe(result => {
      const form_data = JSON.stringify(result);
    })
  }
}
