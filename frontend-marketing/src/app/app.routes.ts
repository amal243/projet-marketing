import { Routes } from '@angular/router';
import { ClientComponent } from './components/client/client.component';
import { ProduitComponent } from './components/produit/produit.component';
import { VenteComponent } from './components/vente/vente.component';

export const routes: Routes = [
  { path: '', redirectTo: '/client', pathMatch: 'full' },
  { path: 'client', component: ClientComponent },
  { path: 'produit', component: ProduitComponent },
  { path: 'vente', component: VenteComponent },
];
