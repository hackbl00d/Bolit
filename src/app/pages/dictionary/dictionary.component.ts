import { Component, OnInit, OnDestroy, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { Subject, forkJoin, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap, takeUntil, catchError } from 'rxjs/operators';
import { DictionaryService } from '../../services/dictionary.service';
import { DictionaryEntry, DictionaryDirection, LetterInfo } from '../../models/dictionary.model';

@Component({
  selector: 'app-dictionary',
  standalone: true,
  imports: [CommonModule, FormsModule, ScrollingModule],
  templateUrl: './dictionary.component.html',
  styleUrl: './dictionary.component.scss',
})
export class DictionaryComponent implements OnInit, OnDestroy {
  private dictService = inject(DictionaryService);
  private destroy$ = new Subject<void>();
  private search$ = new Subject<string>();

  direction: DictionaryDirection = 'ita-bul';
  letters: LetterInfo[] = [];
  activeLetter = '';
  entries: DictionaryEntry[] = [];
  searchQuery = '';
  loading = false;
  searchMode = false;
  totalEntries = 0;

  get directionLabel(): string {
    return this.direction === 'ita-bul' ? 'Италиански → Български' : 'Български → Италиански';
  }

  get directionLabelShort(): string {
    return this.direction === 'ita-bul' ? 'IT → BG' : 'BG → IT';
  }

  ngOnInit(): void {
    this.loadIndex();

    this.search$
      .pipe(
        debounceTime(250),
        distinctUntilChanged(),
        switchMap(query => {
          if (!query || query.length < 2) {
            this.searchMode = false;
            // Reload active letter or clear
            if (this.activeLetter) {
              return this.dictService.getLetterEntries(this.direction, this.activeLetter);
            }
            return of([]);
          }
          this.searchMode = true;
          this.loading = true;
          // Load all letters and search across them
          const letterKeys = this.letters.map(l => l.letter);
          const requests = letterKeys.map(letter =>
            this.dictService.getLetterEntries(this.direction, letter).pipe(catchError(() => of([])))
          );
          return forkJoin(requests).pipe(
            switchMap(results => {
              const all = results.flat();
              const q = query.toLowerCase();
              const filtered = all.filter(
                e =>
                  e.word.toLowerCase().includes(q) ||
                  e.senses.some(s => s.toLowerCase().includes(q))
              );
              return of(filtered);
            })
          );
        }),
        takeUntil(this.destroy$)
      )
      .subscribe(entries => {
        this.entries = entries;
        this.loading = false;
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  loadIndex(): void {
    this.loading = true;
    this.dictService
      .getIndex(this.direction)
      .pipe(takeUntil(this.destroy$))
      .subscribe(index => {
        this.letters = index.letters;
        this.totalEntries = index.totalEntries;
        this.loading = false;
        // Auto-select first letter
        if (this.letters.length > 0 && !this.activeLetter) {
          this.selectLetter(this.letters[0].letter);
        }
      });
  }

  switchDirection(): void {
    this.direction = this.direction === 'ita-bul' ? 'bul-ita' : 'ita-bul';
    this.activeLetter = '';
    this.entries = [];
    this.searchQuery = '';
    this.searchMode = false;
    this.loadIndex();
  }

  selectLetter(letter: string): void {
    this.activeLetter = letter;
    this.searchQuery = '';
    this.searchMode = false;
    this.loading = true;
    this.dictService
      .getLetterEntries(this.direction, letter)
      .pipe(takeUntil(this.destroy$))
      .subscribe(entries => {
        this.entries = entries;
        this.loading = false;
      });
  }

  onSearch(query: string): void {
    this.search$.next(query);
  }

  buildReportUrl(entry: DictionaryEntry): string {
    const title = encodeURIComponent(`[Неточност] ${entry.word}`);
    const dirLabel = this.direction === 'ita-bul' ? 'Италиански → Български' : 'Български → Италиански';
    const body = encodeURIComponent(
      `## Дума\n${entry.word}\n\n## Посока\n${dirLabel}\n\n## Текущ превод\n${entry.senses.join('; ')}\n\n## Предложена корекция\n(опишете тук)\n\n## Допълнителна информация\n(по избор)`
    );
    return `https://github.com/hackbl00d/Bolit/issues/new?title=${title}&body=${body}&labels=inaccuracy`;
  }

  trackByWord(_index: number, entry: DictionaryEntry): string {
    return entry.word;
  }
}
