import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VenteService } from '../../services/vente.service';

@Component({
  selector: 'app-vente',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vente.component.html',
  styleUrls: ['./vente.component.css']
})
export class VenteComponent {
  ventes: any[] = [];
  nouveau = { produit:'', client:'', montant:0 };

  constructor(private s: VenteService){ this.load(); }
  load(){ this.s.getVentes().subscribe(d=>this.ventes=d, e=>console.error(e)); }
  add(){ this.s.createVente(this.nouveau).subscribe(()=>this.load()); this.nouveau={produit:'',client:'',montant:0}; }
}
