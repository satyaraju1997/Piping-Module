import { Component, HostBinding, Input, OnInit, ViewEncapsulation, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { SideNavService } from '../../../services/side-nav-service/side-nav.service';
import { LeftMenuDataService } from 'src/app/shared/services/left-menu-data/left-menu-data.service';

@Component({
  selector: 'app-side-nav2',
  templateUrl: './side-nav2.component.html',
  styleUrls: ['./side-nav2.component.css'],
  encapsulation: ViewEncapsulation.None,
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({ transform: 'rotate(0deg)' })),
      state('expanded', style({ transform: 'rotate(180deg)' })),
      transition('expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
      ),
    ])
  ]
})
export class SideNav2Component implements OnInit {

  expanded: boolean;
  activeOnIndex: number;

  @HostBinding('attr.aria-expanded') ariaExpanded = this.expanded;
  @Input() item: any;
  @Input() depth: number;
  toggleActive = false;
  @Output() menuList = new EventEmitter<object>();

  constructor(
    public router: Router,
    private sidenav: SideNavService,
    private menuDataService: LeftMenuDataService
    ) {
    if (this.depth === undefined) {
      this.depth = 0;
    }
  }

  ngOnInit(): void {
    this.expanded = false;
  }

  onItemSelected(item: any) {
    this.menuDataService.setMenuData(item);
    if (!item.subMenu || !item.subMenu.length) {
      this.menuList.emit({ item });
      this.sidenav.openNav();
      this.depth;
      if (this.depth >= 1) {
        this.activeOnIndex = item.index;
      }
    }
    if (item.subMenu && item.subMenu.length) {
      this.expanded = !this.expanded;
    }
  }

  onChildItemSelected(item: any) {
    if (item.subMenu && item.subMenu.length) {
      this.menuList.emit({ item });
      this.sidenav.openNav();
      this.depth;
      if (this.depth >= 1) {
        this.activeOnIndex = item.index;
      }
    } else {
      return;
    }
  }

  sideNavChild(i) {
    i
  }
  
  
}
