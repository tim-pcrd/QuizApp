import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { IQuiz } from 'src/app/shared/models/quiz';
import{ HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { QuizService } from './quiz.service';
import { environment } from 'src/environments/environment';

describe('QuizService', () => {
  let service: QuizService;
  let httpMock: HttpTestingController;
  let baseUrl = environment.apiUrl;


  let quizServiceStub: Partial<QuizService> = {
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
    });
    service = TestBed.inject(QuizService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // it('be able to retrieve posts from the API via GET',() => {
  //   const dummyQuizzes: IQuiz[] = [
  //     {
  //       id: 1,
  //       name: 'test',
  //       numberOfQuestions: 10,
  //       category: 'sport',
  //       status: 'creating',
  //       createdAt: new Date(),
  //       createdBy: 'tim'
  //     },
  //     {
  //       id: 2,
  //       name: 'test 2',
  //       numberOfQuestions: 15,
  //       category: 'algemeent',
  //       status: 'creating',
  //       createdAt: new Date(),
  //       createdBy: 'tim'
  //     },
  //   ];

  //   service.getQuizzes().subscribe(quizzes => {
  //     expect(quizzes.length).toBe(2);
  //     expect(quizzes).toEqual(dummyQuizzes);
  //   });

  //   const request = httpMock.expectOne(baseUrl + 'quizzes');
  //   request.flush(dummyQuizzes);
  //   expect(request.request.method).toBe('GET');

  // })

  // afterEach(() => {
  //   httpMock.verify();
  // })

});
