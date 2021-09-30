import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { IQuestion } from 'src/app/shared/models/question';
import * as _ from "underscore";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  @Input() question!: IQuestion;
  editMode = false;
  quizForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.quizForm = this.fb.group({
      id: [this.question?.id],
      text: [this.question?.text],
      order: [this.question?.order],
      answers: this.fb.array([])
    });
    console.log(this.question);
  }

  addAnswers() {
    for(let answer of this.question?.answers!) {
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

  drop(event: CdkDragDrop<string[]>) {

    moveItemInArray(this.question.answers, event.previousIndex, event.currentIndex);
    this.question.answers = this.question.answers.map((answer,index) => {
      answer.order = index+1;
      return answer;
    })!

    console.log(this.question.answers);
  }

  onFormSubmit() {
    console.log(this.quizForm.value);
  }

}


