import { Component, OnInit } from '@angular/core';
import { SessionService } from '@app/_services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.css']
})
export class AppHeaderComponent implements OnInit {
  user: any;

  constructor(private sessionService: SessionService) {
    this.sessionService.user.subscribe(x => this.user = x);
  }

  ngOnInit(): void {
  }

  logout() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You want to logout.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then((result) => {
      if (result.value) {
        this.sessionService.logout();
      } else if (result.dismiss === Swal.DismissReason.cancel) {

      }
    })
  }

}
