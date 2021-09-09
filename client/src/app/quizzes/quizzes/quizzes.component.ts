import { Component, OnInit } from '@angular/core';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz } from 'src/app/shared/models/quiz';
import { QuizService } from '../service/quiz.service';

@Component({
  selector: 'app-quizzes',
  templateUrl: './quizzes.component.html',
  styleUrls: ['./quizzes.component.scss']
})
export class QuizzesComponent implements OnInit {
  quizzes: IPagination<IQuiz[]> | undefined;

  constructor(private quizService: QuizService) { }

  ngOnInit(): void {
    this.quizService.getQuizzes().subscribe(quizzes => {
      this.quizzes = quizzes;
      console.log(quizzes);
    },err => console.log(err));
  }

}
