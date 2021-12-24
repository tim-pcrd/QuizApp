import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { IQuiz, IQuizDetails } from 'src/app/shared/models/quiz';
import { QuizService } from '../service/quiz.service';
import * as _ from 'underscore'
import { IQuestion } from 'src/app/shared/models/question';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-quiz-details',
  templateUrl: './quiz-details.component.html',
  styleUrls: ['./quiz-details.component.scss']
})
export class QuizDetailsComponent implements OnInit, OnDestroy {
  quiz!: IQuizDetails;
  sub: Subscription | undefined;
  newQuestion: IQuestion | undefined;
  createMode = false;
  deleteProgress: number = 0;


  constructor(private route: ActivatedRoute, private quizService: QuizService, private router: Router) { }


  ngOnInit(): void {
    this.sub = this.route.paramMap
    .pipe(
      tap(x => console.log(x)),
      switchMap(params => this.quizService.getQuizDetails(+params.get('id')!))
    )
    .subscribe(quiz => {
      this.quiz = quiz;
      this.quiz.questions = _.sortBy(this.quiz.questions, x => x.order);
      for(let question of this.quiz.questions){
        question.answers = _.sortBy(question.answers, x => x.order);
      }



    });
  }

  initNewQuestion(quiz: IQuizDetails) {
    const order = quiz.questions.length === 0
      ? 1
      : Math.max(...quiz.questions.map(x => x.order)) + 1;

    const question: IQuestion = {
      id: 0,
      order,
      text: '',
      imageUrl:'',
      quizId: quiz.id,
      answers: [
        {id: 0, text: '', correct: true, order: 1 },
        {id: 0, text: '', correct: false, order: 2 },
        {id: 0, text: '', correct: false, order: 3 },
        {id: 0, text: '', correct: false, order: 4 }
      ]
    }
    return question;
  }

  openNewQuiz() {
    this.newQuestion = this.initNewQuestion(this.quiz!);
    this.createMode = true;
  }

  onQuestionCreated(question: IQuestion) {
    this.quiz?.questions.push(question);
    this.createMode = false;
  }

  onTest(test: string){
    console.log(test);
  }

  onQuestionRemoved(question: IQuestion) {
    this.quiz!.questions = this.quiz!.questions.filter(x => x.id !== question.id)
  }

  cancelCreateQuestion() {
    this.createMode = false;
  }

  updateQuizStatus(status: string) {
    this.quizService.updateQuizStatus(this.quiz?.id, status).subscribe(() => {
      this.quiz.status = status;
    }, error => console.log(error));
  }

  holdHandler(e: any) {
    if (e <= 1000) {
      this.deleteProgress = (e/10);
    }
    else {
      // this.quizService.deleteQuiz(this.quiz.id).subscribe(x => {
      //   console.log('Quiz deleted');
      //   this.router.navigateByUrl('/quizzen');
      // })
    }
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

}
