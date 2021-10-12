import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    name: ['', [Validators.required, Validators.maxLength(30)]],
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

}
