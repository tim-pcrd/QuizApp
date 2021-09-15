import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz } from 'src/app/shared/models/quiz';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators'

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
}


