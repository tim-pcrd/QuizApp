import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { moveItemsInFormArray } from 'src/app/shared/functions/form-functions';
import { IQuestion } from 'src/app/shared/models/question';
import * as _ from "underscore";
import { QuizService } from '../../service/quiz.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  @Input() question!: IQuestion;
  editMode = false;
  quizForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private quizService: QuizService) { }

  ngOnInit(): void {
    this.quizForm = this.fb.group({
      id: [this.question?.id],
      text: [this.question?.text],
      order: [this.question?.order],
      answers: this.fb.array([])
    });
    this.addAnswers();
    console.log(this.question);
  }

  addAnswers() {
    for(let answer of this.question.answers) {
      (this.quizForm.get('answers') as FormArray).push(this.fb.group({
        id: [answer.id],
        order: [answer.order],
        text: [answer.text],
        correct: [answer.correct]
      }));
    }
  }

  activateEditMode(){
    this.editMode = true;
  }

  endEditMode() {
    this.editMode = false;
  }

  get answers() {
    return this.quizForm.get('answers') as FormArray;
  }

  drop(event: CdkDragDrop<string[]>) {

    moveItemsInFormArray(this.answers, event.previousIndex, event.currentIndex);

    for(let [index, control] of this.answers.controls.entries()){
      control.patchValue({order: index + 1})
    }

    console.log(this.answers.value);
  }

  onFormSubmit() {
    console.log(this.quizForm.value);

    this.quizService.updateQuestion(this.quizForm.value)
      .subscribe(x => console.log("Update gelukt"), err => console.log(err));
  }

}


