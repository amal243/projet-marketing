import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProduitService } from '../../services/produit.service';

@Component({
  selector: 'app-produit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './produit.component.html',
  styleUrls: ['./produit.component.css']
})
export class ProduitComponent {
  produits: any[] = [];
  nouveau = { nom:'', prix:0 };

  constructor(private service: ProduitService){
    this.load();
  }

  load(){ this.service.getProduits().subscribe(d=>this.produits = d, e=>console.error(e)); }
  add(){ this.service.createProduit(this.nouveau).subscribe(()=>this.load()); this.nouveau={nom:'',prix:0}; }
  remove(id:number){ this.service.deleteProduit(id).subscribe(()=>this.load()); }
}
