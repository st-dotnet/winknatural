import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { User } from '@app/_helpers/CommonModel';
import { ContactService, SessionService } from '@app/_services';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  contactform: FormGroup;

  constructor(
    private builder: FormBuilder,
    private contactService: ContactService,
    private sessionService: SessionService) {
      this.sessionService.scrollToTop();
    }


  ngOnInit() {
    this.contactform = this.builder.group({
      // name: new FormControl('', [Validators.required]),
      // Email: new FormControl('', [Validators.required]),
      // Comment: new FormControl('', [Validators.required])
    });
  }

  get f() {
    return this.contactform.controls;
  }

  onSubmit() {
    debugger;
    if (this.contactform.invalid) {
      return;
    }

    const user = new User();
    user.name = this.f.name.value;
    user.mobile = this.f.mobile.value;
    user.email = this.f.email.value;
    user.notes = this.f.notes.value;

    console.log(user);
    this.contactService.contactUser(user)
      .subscribe(response => {
        //location.href = 'https://mailthis.to/confirm'
        console.log(response)
      }, error => {
        console.warn(error.responseText)
        console.log({ error })
      });
  }
}

