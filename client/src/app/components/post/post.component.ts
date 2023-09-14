import {Component, Input} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {Post} from "../../core/models/Post";
import {ReplyComponent} from "../reply/reply.component";

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent {
  @Input() postData?:Post;
  constructor(private dialog:MatDialog) {
  }
  onReply(){
    this.dialog.open(ReplyComponent,{data:this.postData?.id})
  }
}
