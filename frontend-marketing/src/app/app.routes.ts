import { Routes } from '@angular/router';
import { ClientComponent } from './components/client/client.component';
import { ProduitComponent } from './components/produit/produit.component';
import { VenteComponent } from './components/vente/vente.component';

export const routes: Routes = [
  { path: '', component: ClientComponent },
  { path: 'produits', component: ProduitComponent },
  { path: 'ventes', component: VenteComponent },
];
