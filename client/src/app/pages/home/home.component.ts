import { Component } from '@angular/core';
import {MatBottomSheet} from "@angular/material/bottom-sheet";
import {AuthenthicatorComponent} from "../account/authenthicator/authenthicator.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {


  constructor(private authSheet:MatBottomSheet) {
  }

  onGetStarted(){
    this.authSheet.open(AuthenthicatorComponent);
  }
}
