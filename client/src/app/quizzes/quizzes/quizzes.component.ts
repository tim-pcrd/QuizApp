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
    this.getQuizzesFromService(1,1);
  }

  onPageChanged(event:{page:number; itemsPerPage:number;}){
    this.getQuizzesFromService(event.page, event.itemsPerPage);
  }

  getQuizzesFromService( pageIndex: number, pageSize: number){
    this.quizService.getQuizzes(pageIndex, pageSize).subscribe(data => {
      this.quizzes = data;
      this.quizzes.count=50;
    },err => console.log(err));
  }
}
