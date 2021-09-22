import { Component, Input, OnInit } from '@angular/core';
import { IQuestion } from 'src/app/shared/models/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  @Input() question: IQuestion | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
