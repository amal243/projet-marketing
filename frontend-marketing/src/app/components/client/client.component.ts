import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  clients: any[] = [];
  nouveau = { nom:'', email:'', telephone:'' };
  loading = false;
  error = '';

  constructor(private service: ClientService){}

  ngOnInit(){ this.load(); }

  load(){
    this.loading = true;
    this.service.getClients().subscribe({
      next: data=>{ this.clients = data; this.loading=false; },
      error: err=>{ this.error='Erreur'; console.error(err); this.loading=false; }
    });
  }

  add(){
    this.service.createClient(this.nouveau).subscribe(()=> this.load(), err=>console.error(err));
    this.nouveau = { nom:'', email:'', telephone:'' };
  }

  remove(id:number){ this.service.deleteClient(id).subscribe(()=> this.load()); }
}
