import { Component } from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss']
})
export class CreatePostComponent {
  selectedImage?:File;
  constructor(private dialog:MatDialogRef<CreatePostComponent>) {
  }
  onPhotoSelected(photoSelector:HTMLInputElement){
    if (!photoSelector.files) return;
    this.selectedImage=photoSelector.files[0];
    if (!this.selectedImage)return;
    let fileReader=new FileReader();
    fileReader.readAsDataURL(this.selectedImage);
    fileReader.addEventListener(
      "loadend",
      ev=>{
        let readableString= fileReader.result?.toString();
        let postPreviewImage=<HTMLImageElement> document.getElementById("post-preview-image");
        postPreviewImage.src=readableString as string;
      }
    )
  }
}
