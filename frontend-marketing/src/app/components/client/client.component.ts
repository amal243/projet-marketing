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
  model: any = {};
  loading = false;
  error = '';

  constructor(private clientService: ClientService) {}

  ngOnInit() {
    this.loadClients();
  }

  loadClients() {
    this.loading = true;
    this.clientService.getClients().subscribe({
      next: data => {
        this.clients = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Erreur de chargement des clients';
        this.loading = false;
      }
    });
  }

  create(f: any) {
    if (f.valid) {
      this.clientService.createClient(this.model).subscribe({
        next: () => {
          this.loadClients();
          f.resetForm();
        },
        error: () => this.error = 'Erreur lors de la création du client'
      });
    }
  }

  delete(id: number) {
    this.clientService.deleteClient(id).subscribe({
      next: () => this.loadClients(),
      error: () => this.error = 'Erreur lors de la suppression'
    });
  }
}
