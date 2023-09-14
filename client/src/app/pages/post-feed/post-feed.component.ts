import {Component, OnInit} from '@angular/core';
import {Post} from "../../core/models/Post";
import {MatDialog} from "@angular/material/dialog";
import {CreatePostComponent} from "../../components/create-post/create-post.component";

@Component({
  selector: 'app-post-feed',
  templateUrl: './post-feed.component.html',
  styleUrls: ['./post-feed.component.scss']
})
export class PostFeedComponent implements OnInit{
  posts:Post[]=[];

  constructor(private dialog:MatDialog) {

  }

  ngOnInit(): void {
    this.getPosts();
  }
  onCreatePost(){
    this.dialog.open(CreatePostComponent)
  }

  getPosts():Post[]{
    return this.posts;
  }

}
