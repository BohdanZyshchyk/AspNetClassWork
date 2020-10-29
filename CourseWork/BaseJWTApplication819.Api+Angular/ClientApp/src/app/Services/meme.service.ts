import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meme } from '../Models/meme.model';

@Injectable({
  providedIn: 'root'
})
export class MemeService {

  constructor(private http: HttpClient) { }

  baseUrl = "/api/Meme";

  getAllMemes(): Observable<Meme[]> {
    return this.http.get<Meme[]>(this.baseUrl);
  }
  upvoteMeme(id:number): Observable<Meme[]>{
    return this.http.get<Meme[]>(`${this.baseUrl}/upvote/` + id);
  }
}
