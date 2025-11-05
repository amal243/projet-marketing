import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UtilisateurService } from '../../services/utilisateur.service';

@Component({
  selector: 'app-utilisateur',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './utilisateur.component.html',
  styleUrls: ['./utilisateur.component.css']
})
export class UtilisateurComponent {
  utilisateurs: any[] = [];
  nouveau = { nom:'', email:'', role:'responsable' };
  constructor(private s: UtilisateurService){ this.load(); }
  load(){ this.s.getUtilisateurs().subscribe(d=>this.utilisateurs=d); }
  add(){ this.s.createUtilisateur(this.nouveau).subscribe(()=>this.load()); this.nouveau={nom:'',email:'',role:'responsable'}; }
}
