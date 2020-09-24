import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-pipe-master',
  templateUrl: './add-pipe-master.component.html',
  styleUrls: ['./add-pipe-master.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddPipeMasterComponent implements OnInit {

  unitID: any;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.unitID = params.ID;
    });
  }

  onClickBack() {
    this.router.navigate(['/pipe-master/master-design'], { queryParams: {ID: this.unitID}});
  }

}
