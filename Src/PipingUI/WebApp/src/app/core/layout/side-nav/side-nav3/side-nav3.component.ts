import { Component, OnInit, HostBinding, Input, ViewChild, ViewEncapsulation, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { SideNavService } from '../../../services/side-nav-service/side-nav.service';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-side-nav3',
  templateUrl: './side-nav3.component.html',
  styleUrls: ['./side-nav3.component.css'],
  encapsulation: ViewEncapsulation.None,
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({transform: 'rotate(0deg)'})),
      state('expanded', style({transform: 'rotate(180deg)'})),
      transition('expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
      ),
    ])
  ]
})
export class SideNav3Component implements OnInit {

  expanded: boolean;
  @HostBinding('attr.aria-expanded') ariaExpanded = this.expanded;
  @Input() item: any;
  @Input() depth: number;
  toggleActive:boolean = false;

  constructor(public router: Router, private sidenavService: SideNavService) {
    if (this.depth === undefined) {
      this.depth = 0;
    }
  }

  ngOnInit(): void {
  }

  onItemSelected(item: any) {
    if (!item.subMenu || !item.subMenu.length) {
      localStorage.setItem('item',item.code)
      const id = item.id;
      this.router.navigate(['/pipe-master/master-design/'], { queryParams: {ID: id}})
      this.sidenavService.closeNav();

    }
    if (item.subMenu && item.subMenu.length) {
      this.expanded = !this.expanded;
    }
  }

}