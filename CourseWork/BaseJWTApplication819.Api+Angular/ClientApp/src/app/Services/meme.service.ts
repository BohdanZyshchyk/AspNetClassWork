import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meme } from '../Models/meme.model';

@Injectable({
  providedIn: 'root'
})
export class MemeService {

  constructor(private http: HttpClient) { }

  memeUrl = "/api/Meme";

  getAllMemes(): Observable<Meme[]> {
    return this.http.get<Meme[]>(this.memeUrl);
  }
  upvoteMeme(id:number): Observable<Meme[]>{
    return this.http.get<Meme[]>(`${this.memeUrl}/upvote/` + id);
  }
  downvoteMeme(id:number): Observable<Meme[]>{
    return this.http.get<Meme[]>(`${this.memeUrl}/downvote/` + id);
  }

  getMemeById(id: number): Observable<Meme>{
    return this.http.get<Meme>(`${this.memeUrl}/detail/`+ id);
  }

}
