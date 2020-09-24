import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { LookupTable } from 'src/app/shared/models/lookup/lookup.model';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-lookup-tables',
  templateUrl: './lookup-tables.component.html',
  styleUrls: ['./lookup-tables.component.css']
})
export class LookupTablesComponent implements OnInit {

  LookupDataSource: any; 
  LookupDisplayColumns: string[] = ['lookupTableName'];
  LookupTablesList: LookupTable[] = [
    { "id": 1, "lookupTableName": "Structural Min Thk", "path": "lookup-structural-min-thk" },
    { "id": 2, "lookupTableName": "Material Codes", "path": "lookup-structural-min-thk" },
    { "id": 3, "lookupTableName": "Insulation Types", "path": "lookup-structural-min-thk" },
    { "id": 4, "lookupTableName": "Material Master", "path": "lookup-structural-min-thk" },
    { "id": 5, "lookupTableName": "Damage Mechanism", "path": "lookup-structural-min-thk" },
    { "id": 6, "lookupTableName": "EC Driver", "path": "lookup-structural-min-thk" },
    { "id": 7, "lookupTableName": "CUI Rate", "path": "lookup-structural-min-thk" }

  ];
  constructor() { }

  ngOnInit(): void {
    this.LookupDataSource = new MatTableDataSource(this.LookupTablesList);
  }

}


