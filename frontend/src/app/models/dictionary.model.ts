export interface DictionaryEntry {
  word: string;
  senses: string[];
  examples: string[];
}

export interface LetterInfo {
  letter: string;
  count: number;
}

export interface DictionaryIndex {
  name: string;
  totalEntries: number;
  letters: LetterInfo[];
}

export type DictionaryDirection = 'ita-bul' | 'bul-ita';
