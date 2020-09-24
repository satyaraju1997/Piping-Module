import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-add-basic-data',
  templateUrl: './add-basic-data.component.html',
  styleUrls: ['./add-basic-data.component.css']
})
export class AddBasicDataComponent implements OnInit {

  @Input() unitID;
  constructor() { }

  ngOnInit(): void {
  }

}
