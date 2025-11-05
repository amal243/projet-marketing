import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-produit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './produit.component.html', 
  styleUrls: ['./produit.component.css']
})
export class ProduitComponent {
  produits = [
    { id: 1, nom: 'Ordinateur', prix: 1200 },
    { id: 2, nom: 'Téléphone', prix: 800 },
  ];

  nouveauProduit = { nom: '', prix: 0 };

  ajouterProduit() {
    if (this.nouveauProduit.nom.trim()) {
      this.produits.push({
        id: this.produits.length + 1,
        nom: this.nouveauProduit.nom,
        prix: this.nouveauProduit.prix
      });
      this.nouveauProduit = { nom: '', prix: 0 };
    }
  }
}
