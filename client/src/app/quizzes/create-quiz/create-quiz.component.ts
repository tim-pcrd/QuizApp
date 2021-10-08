import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICategory } from 'src/app/shared/models/category';
import { QuizService } from '../service/quiz.service';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.scss']
})
export class CreateQuizComponent implements OnInit {
  categories: ICategory[] = [];
  quizForm: FormGroup = this.fb.group({
    name: ['', [Validators.required, Validators.maxLength(30)]],
    numberOfQuestions: [null, Validators.required],
    categoryId: [null, Validators.required]
  });

  constructor(private quizService: QuizService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.quizService.getCategories().subscribe(categories => {
      this.categories = categories;
    }, error => console.log('error'));


  }

  onSubmit() {
    console.log(this.quizForm);
  }

}
