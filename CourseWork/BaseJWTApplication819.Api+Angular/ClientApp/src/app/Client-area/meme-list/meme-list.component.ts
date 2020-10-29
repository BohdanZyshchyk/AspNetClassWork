import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Meme } from 'src/app/Models/meme.model';
import { MemeService } from 'src/app/Services/meme.service';

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

  ngOnInit(): void {
    this.memeService.getAllMemes().subscribe(
      data =>{
        console.log(data);
        this.memeList = data;
        console.log("MEME")
        console.log(this.memeList);
      }
    )
    // this.loadData();
  }

  loadData(): void {
    this.memeService.getAllMemes().subscribe(
      data =>{
        console.log(data);
        this.memeList = data;
      }
    )
  }

  upvote(id:number){
    console.log(id)
    this.memeService.upvoteMeme(id).subscribe(data=>{
      this.memeList = data;
    })
  }

  

}
