import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Meme } from 'src/app/Models/meme.model';
import { MemeService } from 'src/app/Services/meme.service';
import jwt_decode from "jwt-decode";

interface ItemData {
  href: string;
  title: string;
  avatar: string;
  description: string;
  content: string;
}
@Component({
  selector: 'app-meme-list',
  templateUrl: './meme-list.component.html',
  styleUrls: ['./meme-list.component.css']
})
export class MemeListComponent implements OnInit {

  constructor(private memeService:MemeService,
    private spinner: NgxSpinnerService) { }

  memeList: Meme[];
  upVotedMeme: Meme[];
  userId:string;
  ngOnInit(): void {
    this.userId = jwt_decode(localStorage.getItem('token')).id;
    // this.memeService.getAllMemes().subscribe(
    //   data =>{
    //     console.log(data);
    //     this.memeList = data;
    //     console.log("MEME")
    //     console.log(this.memeList);
    //   }
    // )
    this.loadData();
    this.getUpvoted();
    this.setUpvote();
  }

  getUpvoted(){
    this.memeService.getUpvotedMemes().subscribe(
      data=>{
        console.log(data);
        this.upVotedMeme = data;
      }
    )
  }
  loadData(): void {
    this.memeService.getAllMemes().subscribe(
      data =>{
        console.log(data);
        this.memeList = data;
      }
    )
  }
  setUpvote(){
    //TO DO check user logged
    this.memeList.forEach(element => {
      if(this.upVotedMeme.find(x=> x.id == element.id))
      {
        element.isUpvoted = true;
      }
    });
  }
  upvote(id:number){
    console.log(id)
    this.memeService.upvoteMeme(id, this.userId).subscribe(data=>{
      this.memeList = data;
    })
  }

  downvote(id:number){
    console.log(id)
    this.memeService.downvoteMeme(id, this.userId).subscribe(data=>{
      this.memeList = data;
    })
  }

  

}
