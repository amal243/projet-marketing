import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class VenteService {
  private base = 'http://localhost:5137/api/ventes';
  constructor(private http: HttpClient) {}
  getVentes(): Observable<any[]> { return this.http.get<any[]>(this.base); }
  createVente(payload:any){ return this.http.post(this.base, payload); }
}
