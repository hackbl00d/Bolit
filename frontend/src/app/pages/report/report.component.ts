import { Component } from '@angular/core';

@Component({
  selector: 'app-report',
  standalone: true,
  templateUrl: './report.component.html',
  styleUrl: './report.component.scss',
})
export class ReportComponent {
  readonly repoUrl = 'https://github.com/hackbl00d/Bolit';
  readonly newIssueUrl = 'https://github.com/hackbl00d/Bolit/issues/new';

  buildIssueUrl(): string {
    const title = encodeURIComponent('[Неточност] ');
    const body = encodeURIComponent(
      `## Дума\n(напишете думата тук)\n\n## Посока\n(Италиански → Български / Български → Италиански)\n\n## Текущ превод\n(какво показва речника)\n\n## Предложена корекция\n(какъв трябва да е правилният превод)\n\n## Допълнителна информация\n(по избор)`
    );
    return `${this.newIssueUrl}?title=${title}&body=${body}&labels=inaccuracy`;
  }
}
