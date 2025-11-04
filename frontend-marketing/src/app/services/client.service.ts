import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClientService {

  private apiUrl = 'http://localhost:5137/api/clients';

  constructor(private http: HttpClient) {}

  getClients(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  createClient(client: any): Observable<any> {
    return this.http.post(this.apiUrl, client);
  }

  deleteClient(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
