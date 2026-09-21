import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, shareReplay } from 'rxjs';
import { DictionaryEntry, DictionaryIndex, DictionaryDirection } from '../models/dictionary.model';

@Injectable({ providedIn: 'root' })
export class DictionaryService {
  private http = inject(HttpClient);
  private cache = new Map<string, Observable<DictionaryEntry[]>>();
  private indexCache = new Map<string, Observable<DictionaryIndex>>();

  getIndex(direction: DictionaryDirection): Observable<DictionaryIndex> {
    const key = direction;
    if (!this.indexCache.has(key)) {
      this.indexCache.set(
        key,
        this.http.get<DictionaryIndex>(`data/${direction}/index.json`).pipe(shareReplay(1))
      );
    }
    return this.indexCache.get(key)!;
  }

  getLetterEntries(direction: DictionaryDirection, letter: string): Observable<DictionaryEntry[]> {
    const key = `${direction}/${letter}`;
    if (!this.cache.has(key)) {
      const encodedLetter = encodeURIComponent(letter);
      this.cache.set(
        key,
        this.http
          .get<DictionaryEntry[]>(`data/${direction}/${encodedLetter}.json`)
          .pipe(shareReplay(1))
      );
    }
    return this.cache.get(key)!;
  }
}
