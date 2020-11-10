import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meme } from '../Models/meme.model';

@Injectable({
  providedIn: 'root'
})
export class MemeService {

  constructor(private http: HttpClient) { }

  memeUrl = "/api/Meme";
  onUpvote = new EventEmitter<boolean>();
  getAllMemes(): Observable<Meme[]> {
    return this.http.get<Meme[]>(this.memeUrl);
  }
  getUpvotedMemes(userId:string):Observable<Meme[]> {
    return this.http.get<Meme[]>(`${this.memeUrl}/getupvote/${userId}`);
  }
  getDownvotedMemes():Observable<Meme[]> {
    return this.http.get<Meme[]>(`${this.memeUrl}/getdownvote`);
  }
  upvoteMeme(id:number, userId:string): Observable<Meme[]>{
    return this.http.get<Meme[]>(`${this.memeUrl}/upvote/${id}/${userId}`);
  }
  downvoteMeme(id:number, userId: string): Observable<Meme[]>{
    return this.http.get<Meme[]>(`${this.memeUrl}/downvote/${id}/${userId}`);
  }

  getMemeById(id: number): Observable<Meme>{
    return this.http.get<Meme>(`${this.memeUrl}/detail/`+ id);
  }

}
