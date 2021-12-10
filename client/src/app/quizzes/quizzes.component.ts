import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz } from 'src/app/shared/models/quiz';
import { QuizService } from './service/quiz.service';
import { trigger, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-quizzes',
  templateUrl: './quizzes.component.html',
  styleUrls: ['./quizzes.component.scss'],
  animations: [
    trigger(
      'enterAnimation', [
        transition(':enter', [
          style({transform: 'translateX(100%)', opacity: 0, background: '#1BA4D1'}),
          animate('500ms', style({transform: 'translateX(0)', opacity: 1, 'overflow-x': 'hidden', background: '#fff'}))
        ]),
        transition(':leave', [
          style({transform: 'translateX(0)', opacity: 1}),
          animate('500ms', style({transform: 'translateX(100%)', opacity: 0}))
        ])
      ]
    ),
  ]
})
export class QuizzesComponent implements OnInit {
  quizzesPagination: IPagination<IQuiz[]> = {pageIndex: 1, pageSize: 10, count:0, data: []};
  @ViewChild('closeModal') closeModal!: ElementRef;

  constructor(private quizService: QuizService, private router: Router) { }

  ngOnInit(): void {
    this.getQuizzesFromService(1,10);
  }

  onPageChanged(event:{page:number; itemsPerPage:number;}){
    this.getQuizzesFromService(event.page, event.itemsPerPage);
  }

  getQuizzesFromService( pageIndex: number, pageSize: number){
    this.quizService.getQuizzes(pageIndex, pageSize).subscribe(data => {
      this.quizzesPagination = data;
    },err => console.log(err));
  }

  onRowClicked(quizId: number){
    this.router.navigateByUrl(`/quizzen/${quizId}`)
  }

  quizAdded(quiz: IQuiz) {
    this.quizzesPagination.data.unshift(quiz);
    this.quizzesPagination.data.pop();
    this.quizzesPagination.count++;

    this.closeModal.nativeElement.click();
    // this.router.navigateByUrl(`/quizzen/${id}`)
  }
}
