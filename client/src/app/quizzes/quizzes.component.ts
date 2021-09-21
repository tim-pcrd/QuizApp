import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz } from 'src/app/shared/models/quiz';
import { QuizService } from './service/quiz.service';

@Component({
  selector: 'app-quizzes',
  templateUrl: './quizzes.component.html',
  styleUrls: ['./quizzes.component.scss']
})
export class QuizzesComponent implements OnInit {
  quizzes: IPagination<IQuiz[]> | undefined;

  constructor(private quizService: QuizService, private router: Router) { }

  ngOnInit(): void {
    this.getQuizzesFromService(1,10);
  }

  onPageChanged(event:{page:number; itemsPerPage:number;}){
    this.getQuizzesFromService(event.page, event.itemsPerPage);
  }

  getQuizzesFromService( pageIndex: number, pageSize: number){
    this.quizService.getQuizzes(pageIndex, pageSize).subscribe(data => {
      this.quizzes = data;
    },err => console.log(err));
  }

  onRowClicked(quizId: number){
    this.router.navigateByUrl(`/quizzen/${quizId}`)
  }
}
