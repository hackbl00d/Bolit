/**
 * Splits ItaBul.json and BulIta.json into per-letter JSON chunks
 * for lazy loading in the frontend.
 *
 * Output: public/data/{ita-bul,bul-ita}/{LETTER}.json + index.json (letter list)
 */

import { readFileSync, writeFileSync, mkdirSync, existsSync } from 'fs';
import { join, dirname } from 'path';
import { fileURLToPath } from 'url';

const __dirname = dirname(fileURLToPath(import.meta.url));
const ROOT = join(__dirname, '..');
const DATA_DIR = join(ROOT, 'data');
const OUT_DIR = join(ROOT, 'public', 'data');

function splitDictionary(filename, outSubdir) {
  const filePath = join(DATA_DIR, filename);
  const raw = JSON.parse(readFileSync(filePath, 'utf-8'));
  const entries = raw.entries;
  const name = raw.name;

  const outDir = join(OUT_DIR, outSubdir);
  mkdirSync(outDir, { recursive: true });

  // Group entries by uppercase first letter
  const groups = {};
  for (const entry of entries) {
    const word = entry.word.trim();
    if (!word) continue;
    let firstChar;
    if (outSubdir === 'ita-bul') {
      firstChar = word[0].toLocaleUpperCase('it-IT');
    } else if (outSubdir === 'bul-ita') {
      firstChar = word[0].toLocaleUpperCase('bg-BG');
    } else {
      firstChar = word[0].toUpperCase();
    }
    // Group non-letter chars under '#'
    const key = /\p{L}/u.test(firstChar) ? firstChar : '#';
    if (!groups[key]) groups[key] = [];
    groups[key].push(entry);
  }

  // Sort entries within each group
  for (const key of Object.keys(groups)) {
    groups[key].sort((a, b) => a.word.localeCompare(b.word));
  }

  // Write per-letter files
  const letters = Object.keys(groups).sort((a, b) => a.localeCompare(b));
  for (const letter of letters) {
    const outPath = join(outDir, `${letter}.json`);
    writeFileSync(outPath, JSON.stringify(groups[letter]), 'utf-8');
  }

  // Write index with letter + count
  const index = {
    name,
    totalEntries: entries.length,
    letters: letters.map(l => ({ letter: l, count: groups[l].length })),
  };
  writeFileSync(join(outDir, 'index.json'), JSON.stringify(index), 'utf-8');

  console.log(`✓ ${filename} → ${letters.length} letter files in ${outSubdir}/ (${entries.length} entries)`);
}

splitDictionary('ItaBul.json', 'ita-bul');
splitDictionary('BulIta.json', 'bul-ita');
console.log('Done!');
