import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app'; // correspond à src/app/app.ts

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent], // si AppComponent est standalone
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    // adapte la chaîne ci-dessous au h1 réellement rendu par ton template `app.html`
    expect(compiled.querySelector('h1')?.textContent).toContain('Application Marketing');
  });
});
