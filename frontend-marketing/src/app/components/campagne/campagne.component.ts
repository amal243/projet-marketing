import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Campagne {
  nom: string;
  description: string;
  dateDebut: string;
  dateFin: string;
  budget: number;
}

@Component({
  selector: 'app-campagne',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './campagne.component.html',
  styleUrls: ['./campagne.component.css']
})
export class CampagneComponent {
  campagnes: Campagne[] = [];

  nouveau: Campagne = {
    nom: '',
    description: '',
    dateDebut: '',
    dateFin: '',
    budget: 0
  };

  add() {
    this.campagnes.push({ ...this.nouveau });
    this.nouveau = { nom: '', description: '', dateDebut: '', dateFin: '', budget: 0 };
  }
}
