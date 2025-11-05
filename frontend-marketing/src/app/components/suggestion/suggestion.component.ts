import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SuggestionService } from '../../services/suggestion.service';

@Component({
  selector: 'app-suggestion',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './suggestion.component.html',
  styleUrls: ['./suggestion.component.css']
})
export class SuggestionComponent {
  suggestions: any[] = [];
  nouveau = { texte:'', type:'' };
  constructor(private s: SuggestionService){ this.load(); }
  load(){ this.s.getSuggestions().subscribe(d=>this.suggestions=d); }
  add(){ this.s.createSuggestion(this.nouveau).subscribe(()=>this.load()); this.nouveau={texte:'',type:''}; }
}
