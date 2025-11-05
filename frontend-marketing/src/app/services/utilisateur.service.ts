import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({ providedIn: 'root' })
export class UtilisateurService {
  private base = 'http://localhost:5137/api/utilisateurs';
  constructor(private http: HttpClient) {}
  getUtilisateurs(){ return this.http.get<any[]>(this.base); }
  createUtilisateur(p:any){ return this.http.post(this.base, p); }
}
