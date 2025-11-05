import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-vente',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vente.component.html',
  styleUrls: ['./vente.component.css']
})
export class VenteComponent {
  ventes = [
    { id: 1, produit: 'Ordinateur', client: 'Amal', montant: 1200 },
    { id: 2, produit: 'Téléphone', client: 'Wièm', montant: 800 },
  ];

  nouvelleVente = { produit: '', client: '', montant: 0 };

  ajouterVente() {
    if (this.nouvelleVente.produit.trim() && this.nouvelleVente.client.trim()) {
      this.ventes.push({
        id: this.ventes.length + 1,
        produit: this.nouvelleVente.produit,
        client: this.nouvelleVente.client,
        montant: this.nouvelleVente.montant
      });
      this.nouvelleVente = { produit: '', client: '', montant: 0 };
    }
  }
}
