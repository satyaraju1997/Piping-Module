import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-external-corrosion',
  templateUrl: './add-external-corrosion.component.html',
  styleUrls: ['./add-external-corrosion.component.css']
})
export class AddExternalCorrosionComponent implements OnInit {

  @Input() unitID;
  constructor() { }

  ngOnInit(): void {
  }

}
