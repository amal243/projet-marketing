import { Routes } from '@angular/router';
import { CampagneComponent } from './components/campagne/campagne.component';
import { ClientComponent } from './components/client/client.component';
import { ProduitComponent } from './components/produit/produit.component';
import { VenteComponent } from './components/vente/vente.component';
import { SuggestionComponent } from './components/suggestion/suggestion.component';
import { UtilisateurComponent } from './components/utilisateur/utilisateur.component';

export const routes: Routes = [
  { path: '', component: CampagneComponent },
  { path: 'campagnes', component: CampagneComponent },
  { path: 'clients', component: ClientComponent },
  { path: 'produits', component: ProduitComponent },
  { path: 'ventes', component: VenteComponent },
  { path: 'suggestions', component: SuggestionComponent },
  { path: 'utilisateurs', component: UtilisateurComponent },
];
