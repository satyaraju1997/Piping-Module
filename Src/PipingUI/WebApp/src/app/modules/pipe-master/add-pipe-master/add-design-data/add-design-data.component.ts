import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-design-data',
  templateUrl: './add-design-data.component.html',
  styleUrls: ['./add-design-data.component.css']
})
export class AddDesignDataComponent implements OnInit {

  @Input() unitID;
  constructor() { }

  ngOnInit(): void {
  }

}
