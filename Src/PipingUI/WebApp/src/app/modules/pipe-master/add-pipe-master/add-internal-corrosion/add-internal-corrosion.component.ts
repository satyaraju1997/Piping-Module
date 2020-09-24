import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-internal-corrosion',
  templateUrl: './add-internal-corrosion.component.html',
  styleUrls: ['./add-internal-corrosion.component.css']
})
export class AddInternalCorrosionComponent implements OnInit {

  @Input() unitID;
  constructor() { }

  ngOnInit(): void {
  }

}
