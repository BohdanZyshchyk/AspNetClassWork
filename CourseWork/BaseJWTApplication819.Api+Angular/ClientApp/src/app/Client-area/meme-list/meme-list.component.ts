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
    private spinner: NgxSpinnerService) { 
      this.memeService.onUpvote.subscribe(()=>{
        this.loadData();
        this.getUpvoted();
      });

    }

  memeList: Meme[];
  upVotedMeme: Meme[];
  userId:string;
  ngOnInit(): void {
    this.userId = jwt_decode(localStorage.getItem('token')).id;
    this.loadData();
    this.getUpvoted();
    // this.setUpvote();
  }

  ngDoCheck(){
    this.setUpvote();
  }
  

  getUpvoted(){
    this.memeService.getUpvotedMemes(this.userId).subscribe(
      data=>{
        this.upVotedMeme = data;
      }
    )
  }
  loadData(): void {
    this.memeService.getAllMemes().subscribe(
      data =>{
        this.memeList = data;
      }
    )
  }
  setUpvote(){
    //TO DO check user logged
    // this.memeService.onUpvote.emit(false);
    this.memeList.forEach(element => {
      if(this.upVotedMeme.find(x=> x.id == element.id))
      {
        element.isUpvoted = true;
      }
    });
  }
  upvote(id:number){
    var meme = this.memeList.find(x=> x.id == id);
    if(meme.isUpvoted)
    {
      this.downvote(id);
      return;
    }
      this.memeService.upvoteMeme(id, this.userId).subscribe(data=>{
        this.memeList = data;
        this.memeService.onUpvote.emit(true);
      });
      this.getUpvoted();
  }

  downvote(id:number){
    this.memeService.downvoteMeme(id, this.userId).subscribe(data=>{
      this.memeList = data;
       this.getUpvoted();
       this.memeService.onUpvote.emit(false);
    })

    console.log("UPVOTED MEME");
    console.log(this.upVotedMeme);
    // this.setUpvote();
  }
  

}
