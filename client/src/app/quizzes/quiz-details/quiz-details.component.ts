import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { IQuizDetails } from 'src/app/shared/models/quiz';
import { QuizService } from '../service/quiz.service';

@Component({
  selector: 'app-quiz-details',
  templateUrl: './quiz-details.component.html',
  styleUrls: ['./quiz-details.component.scss']
})
export class QuizDetailsComponent implements OnInit, OnDestroy {
  quiz: IQuizDetails | undefined;
  sub: Subscription | undefined;

  constructor(private route: ActivatedRoute, private quizService: QuizService) { }


  ngOnInit(): void {
    this.sub = this.route.paramMap
    .pipe(
      tap(x => console.log(x)),
      switchMap(params => this.quizService.getQuizDetails(+params.get('id')!))
    )
    .subscribe(quiz => {
      this.quiz = quiz;
    });
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
