import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClientService {
  private base = 'http://localhost:5137/api/clients';
  constructor(private http: HttpClient) {}
  getClients(): Observable<any[]> { return this.http.get<any[]>(this.base); }
  getClient(id:number){ return this.http.get<any>(`${this.base}/${id}`); }
  createClient(payload:any){ return this.http.post(this.base, payload); }
  updateClient(id:number,payload:any){ return this.http.put(`${this.base}/${id}`, payload); }
  deleteClient(id:number){ return this.http.delete(`${this.base}/${id}`); }
}
