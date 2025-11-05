import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProduitService {
  private base = 'http://localhost:5137/api/produits';
  constructor(private http: HttpClient) {}
  getProduits(): Observable<any[]> { return this.http.get<any[]>(this.base); }
  createProduit(payload:any){ return this.http.post(this.base, payload); }
  deleteProduit(id:number){ return this.http.delete(`${this.base}/${id}`); }
}
