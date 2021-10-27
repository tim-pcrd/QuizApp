import { findLast } from '@angular/compiler/src/directive_resolver';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, of, timer } from 'rxjs';
import { debounceTime, finalize, map, switchMap } from 'rxjs/operators';
import { ICategory } from 'src/app/shared/models/category';
import { IQuiz } from 'src/app/shared/models/quiz';
import { QuizService } from '../service/quiz.service';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.scss']
})
export class CreateQuizComponent implements OnInit {
  @Output() quizAdded:EventEmitter<IQuiz> = new EventEmitter<IQuiz>();

  categories: ICategory[] = [];
  quizForm: FormGroup = this.fb.group({
    name: ['', [Validators.required, Validators.maxLength(30)], this.uniqueNameValidation()],
    numberOfQuestions: [null, Validators.required],
    categoryId: [null, Validators.required]
  });

  constructor(private quizService: QuizService, private fb: FormBuilder, private router:Router) { }

  ngOnInit(): void {
    this.quizService.getCategories().subscribe(categories => {
      this.categories = categories;
    }, error => console.log(error));
  }

  onSubmit() {
    if(this.quizForm.valid) {
      console.log(this.quizForm)
      this.quizService.createQuiz(this.quizForm.value)
        .subscribe(id => {
          this.quizAdded.emit({
            id: id,
            name: this.quizForm.value.name,
            numberOfQuestions: this.quizForm.value.numberOfQuestions,
            category: this.categories.find(x => x.id === this.quizForm.value.categoryId)!.name,
            createdAt: new Date()
          });
          this.quizForm.reset();
        }, error => console.log(error))
    }
  }

  uniqueNameValidation(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if(!control.value) {
        return of(null);
      }

      return timer(1000)
        .pipe(
          switchMap(() => {
            return this.quizService.checkNameExists(control.value)
              .pipe(
                map(exists => exists ? {exists: true} : null),
                finalize(() => console.log('finished inner'))
              )
          }),
          finalize(() => console.log('finished outer'))

        )
    }
  }


}
