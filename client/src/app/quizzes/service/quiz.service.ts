import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz, IQuizDetails, IQuizToCreate } from 'src/app/shared/models/quiz';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators'
import { IQuestionToUpdate } from 'src/app/shared/models/question';
import { ICategory } from 'src/app/shared/models/category';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getQuizzes(pageIndex: number, pageSize: number) {
    let params = new HttpParams()
      .set('pageIndex',pageIndex.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<IPagination<IQuiz[]>>(this.baseUrl + 'quizzes', {params})
      .pipe(tap(x => console.log(x)));
  }

  getQuizDetails(quizId: number) {
    return this.http.get<IQuizDetails>(`${this.baseUrl}quizzes/${quizId}`)
      .pipe(tap(x => console.log(x)));
  }

  updateQuestion(question: IQuestionToUpdate) {
    return this.http.put(`${this.baseUrl}questions/${question.id}`, question)
  }

  getCategories() {
    return this.http.get<ICategory[]>(`${this.baseUrl}categories`);
  }

  createQuiz(quiz: IQuizToCreate) {
    return this.http.post<number>(`${this.baseUrl}quizzes`, quiz);
  }

  checkNameExists(name: string) {
    return this.http.get<boolean>(`${this.baseUrl}quizzes/nameexists?name=${name}`)
  }


}


