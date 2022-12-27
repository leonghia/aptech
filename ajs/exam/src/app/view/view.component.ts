import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  mails: any = {};
  section: string = '';

  constructor(private route: ActivatedRoute ,private httpClient: HttpClient) {

  }
  ngOnInit() {
    this.httpClient.get("../assets/json/data.json").subscribe(data =>{
      this.mails = data;
    })
    this.route.params.subscribe(params => {
      if (params['section'])
        this.section = params['section'];
      else
        this.section = 'favorites_inbox';
    })
  }
}
