import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CampagneService } from '../../services/campagne.service';

@Component({
  selector: 'app-campagne',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './campagne.component.html',
  styleUrls: ['./campagne.component.css']
})
export class CampagneComponent implements OnInit {
  campagnes: any[] = [];
  nouveau = { nom:'', description:'', dateDebut:'', dateFin:'', budget:0 };

  constructor(private s: CampagneService){}
  ngOnInit(){ this.load(); }
  load(){ this.s.getCampagnes().subscribe(d=>this.campagnes=d, e=>console.error(e)); }
  add(){ this.s.createCampagne(this.nouveau).subscribe(()=>this.load()); this.nouveau={nom:'',description:'',dateDebut:'',dateFin:'',budget:0}; }
}
