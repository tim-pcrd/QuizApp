import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { QuizService } from './service/quiz.service';

import { QuizzesComponent } from './quizzes.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('QuizzesComponent', () => {
  let component: QuizzesComponent;
  let fixture: ComponentFixture<QuizzesComponent>;
  let quizService: QuizService;
  let getQuizzes: jasmine.Spy;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterTestingModule],
      declarations: [ QuizzesComponent ],
      providers: [
        {provides: QuizService, useClass: MockQuizService}
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizzesComponent);
    quizService = TestBed.inject(QuizService);
    getQuizzes = spyOn(quizService, 'getQuizzes').and.returnValue(of({data: [], pageIndex: 1, pageSize: 1, count:1}))
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should subscribe to getQuizzes',() => {
    component.ngOnInit();
    expect(getQuizzes).toHaveBeenCalled();
  })
});

class MockQuizService {
  getQuizzes(){
  }
}
