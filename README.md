# Bolit

Italian-Bulgarian and Bulgarian-Italian dictionary web application designed for Bulgarian students learning Italian. Features over 67,000 words with search, alphabet navigation, and lazy-loaded data for fast performance.

## Prerequisites

- [Node.js](https://nodejs.org/) (v18+)
- npm (comes with Node.js)

## Getting Started

Install dependencies:

```bash
npm install
```

Start the development server:

```bash
ng serve
```

Open your browser at `http://localhost:4200/`.

## Building for Production

```bash
ng build
```

Build artifacts are output to the `dist/` directory.

## Preprocessing Dictionary Data

If you modify the source dictionary files in `data/`, regenerate the per-letter chunks:

```bash
node scripts/split-dictionary.mjs
```

## Reporting Inaccuracies

Found a translation error? Open an issue at [github.com/hackbl00d/Bolit/issues](https://github.com/hackbl00d/Bolit/issues) or use the report button next to any word in the dictionary.
