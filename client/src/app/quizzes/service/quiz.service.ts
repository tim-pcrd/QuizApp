import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from 'src/app/shared/models/pagination';
import { IQuiz } from 'src/app/shared/models/quiz';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getQuizzes() {
    return this.http.get<IPagination<IQuiz[]>>(this.baseUrl + 'quizzes');
  }
}
