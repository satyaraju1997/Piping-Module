import { Component, OnInit } from '@angular/core';
import {ViewEncapsulation } from '@angular/core';
import { AuthenticateService } from '../../authentication/authenticate.service';
import { PipingService } from '../../http/piping/piping.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class HeaderComponent implements OnInit {

  userInfo: any;
  piping: any;
  pipingOptions: any;
  subMenu = false;
  selected = "2";
  basic = "basic";
  
  constructor(private authenticateService: AuthenticateService, private pipingService: PipingService, public router: Router) { }

  ngOnInit(): void {
    this.authenticateService.currentUserInfo().subscribe((user) => {
      this.userInfo = user;
    });

    this.pipingService.getPipingById(this.userInfo.userID).subscribe( (res) => {      
      this.pipingOptions = res;
    });
  }

  showSubMenu() {
    this.subMenu = true;
  }

  logout()
  {
    localStorage.removeItem('access_token');
    this.router.navigate(['/auth/login']);
  }
}
