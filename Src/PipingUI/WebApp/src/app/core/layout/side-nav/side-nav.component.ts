import { Component, OnInit, ViewEncapsulation, ViewChild, Input } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SideNavService } from '../../services/side-nav-service/side-nav.service';
import { AuthenticateService } from '../../authentication/authenticate.service';
import { LeftMenuService } from '../../http/left-menu/left-menu.service';
import { Router } from '@angular/router';
import { LeftMenuDataService } from 'src/app/shared/services/left-menu-data/left-menu-data.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SideNavComponent implements OnInit {

  @ViewChild('sideNav2') public sideNav2: MatSidenav;
  @ViewChild('sideNav1') public sideNav1: MatSidenav;

  userInfo: any;
  leftMenu: any;
  masterMenuList = [];
  fluidMenu: any;
  fluidSubMenu: any;
  activeOnIndex;
  activeOnLink;
  quickLink: any;
  pipeMasterMenu: any;
  // menu;

  isExpanded: boolean;

  constructor(
    private router: Router,
    private sidenavService: SideNavService,
    private authenticateService: AuthenticateService,
    private leftMenuService: LeftMenuService,
    private quickLinkService: LeftMenuService,
    private menuDataService: LeftMenuDataService
  ) { }

  ngOnInit(): void {
    this.isExpanded = true;
    this.authenticateService.currentUserInfo().subscribe((user) => {
      this.userInfo = user;
    });

    this.leftMenuService.getLeftMenuById(this.userInfo.companyID).subscribe((data) => {
      this.leftMenu = data;
    });

    this.quickLinkService.getQuickLinkById(this.userInfo.userID).subscribe((data) => {
      this.quickLink = data;
    });
  }

  ngAfterViewInit() {
    this.sidenavService.appDrawer = this.sideNav2;
  }

  toggleSideNav() {
    if (this.isExpanded) {
      this.isExpanded = false;
    } else {
      this.isExpanded = true;
      this.sideNav2.close();
    }
  }

  activateClassNOpenSideNav(e, i) {
    this.toggleSideNav();
    this.isExpanded ? this.sideNav1.close() : this.sideNav1.open();
    this.activeOnIndex = i;
    this.collapsedLeftMenu(i);
  }

  collapsedLeftMenu(i) {
    if (i.quickLinkID) {
      this.activeOnLink = i.quickLinkName;
      const code = localStorage.getItem('item');
      if (i.quickLinkName === 'Piping Reports') {
        this.router.navigate(['/pipe-master/pipe-report'], {queryParams: {equipmentNo: code}});
      } else if (i.quickLinkName === 'POF Master Records') {
        this.router.navigate(['/pipe-master/pof-ic-calc']);
      }
      else if (i.quickLinkName === 'Lookup Tables') {
        this.router.navigate(['/pipe-master/lookup-tables']);
      }
      else if (i.quickLinkName === 'Risk Analysis') {
        this.router.navigate(['/pipe-master/risk-analysis']);
      }
      else if (i.quickLinkName === 'Inspection Program') {
        this.router.navigate(['/pipe-master/inspection-program']);
      }
      else if (i.quickLinkName === 'Corrosion Study') {
        this.router.navigate(['/pipe-master/corrosion-study']);
      }
      else if (i.quickLinkName === 'Pipe Master Import') {
        this.router.navigate(['/pipe-master/pipe-import']);
      }
      
      else {
        return;
      }
    } else {
      this.activeOnIndex = i;
      if (this.leftMenu[i].subMenu.length) {
        this.menuDataService.setMenuData(this.leftMenu[i]);
        // this.menuDataService = this.leftMenu[i].code;
        this.fluidMenu = this.leftMenu[i].subMenu;
        this.router.navigate(['/pipe-master/dashboard']);
      }
    }
  }

  menuList(event) {
    for (let i = 0; i < this.fluidMenu.length; i++) {
      if (this.fluidMenu[i].subMenu && this.fluidMenu[i].subMenu.length) {
        this.fluidSubMenu = this.fluidMenu[i].subMenu;
        for (let j = 0; j < this.fluidSubMenu.length; j++) {
          if (this.fluidSubMenu[j].id === event.item.id) {
            this.pipeMasterMenu = this.fluidSubMenu[j].subMenu;
          }
        }
      }
    }
  }

}
