import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({ providedIn: 'root' })
export class SuggestionService {
  private base = 'http://localhost:5137/api/suggestions';
  constructor(private http: HttpClient) {}
  getSuggestions(){ return this.http.get<any[]>(this.base); }
  createSuggestion(p:any){ return this.http.post(this.base, p); }
}
