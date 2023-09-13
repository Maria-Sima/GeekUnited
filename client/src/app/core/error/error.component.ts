import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment.prod";

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {

  baseUrl = environment.apiUrl;
  validationErrors: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'products/42').subscribe({
      next:(response)=>console.log(response),
      error:(e)=>console.log(e)
    });
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe({
      next:(response)=>console.log(response),
      error:(e)=>console.log(e)
    });
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next:(response)=>console.log(response),
      error:(e)=>console.log(e)
    });
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/fortytwo').subscribe({
      next:(response)=>console.log(response),
      error:(e)=>console.log(e)
    });
  }
}
