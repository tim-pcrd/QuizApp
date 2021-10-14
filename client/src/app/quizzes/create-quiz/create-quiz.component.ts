import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { debounceTime, map } from 'rxjs/operators';
import { ICategory } from 'src/app/shared/models/category';
import { QuizService } from '../service/quiz.service';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.scss']
})
export class CreateQuizComponent implements OnInit {
  @Output() quizAdded:EventEmitter<number> = new EventEmitter<number>();

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
    }, error => console.log('error'));
  }

  onSubmit() {
    if(this.quizForm.valid) {
      console.log(this.quizForm.value)
      this.quizService.createQuiz(this.quizForm.value)
        .subscribe(id => {
          this.quizAdded.emit(id);
          this.quizForm.reset();
        }, error => console.log(error))
    }
  }

  uniqueNameValidation(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if(!control.value) {
        return of(null);
      }

      return this.quizService.checkNameExists(control.value)
        .pipe(
          debounceTime(1000),
          map(exists => {
            console.log('exists api')
            if(exists) {
              return {exists: true};
            } else {
              return null;
            }
          })
        )
    }
  }


}
