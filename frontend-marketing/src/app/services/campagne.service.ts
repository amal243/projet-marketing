import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({ providedIn: 'root' })
export class CampagneService {
  private base = 'http://localhost:5137/api/campagnes';
  constructor(private http: HttpClient) {}
  getCampagnes(){ return this.http.get<any[]>(this.base); }
  createCampagne(p:any){ return this.http.post(this.base, p); }
  updateCampagne(id:number,p:any){ return this.http.put(`${this.base}/${id}`, p); }
}
