import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
  createMode = false;
  disableEditButton = false;
  questionForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private quizService: QuizService) { }

  ngOnInit(): void {

    if (this.question.id === 0) {
      this.createMode = true;
    }

    this.quizService.disableEdit.subscribe(disable => this.disableEditButton = disable);


    this.initForm();
  }

  activateEditMode(){
    this.quizService.disableEdit.next(true);
    this.editMode = true;
  }

  cancel() {
    this.editMode = false;
    this.initForm();
    this.quizService.disableEdit.next(false);
  }

  initForm() {

    this.questionForm = this.fb.group({
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
      this.answers.push(this.fb.group({
        id: [answer.id],
        order: [answer.order],
        text: [answer.text],
        correct: [answer.correct]
      }));
    }
  }

  get answers() {
    return this.questionForm.get('answers') as FormArray;
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemsInFormArray(this.answers, event.previousIndex, event.currentIndex);

    for(let [index, control] of this.answers.controls.entries()){
      control.patchValue({order: index + 1})
    }

    console.log(this.answers.value);
  }

  onFormSubmit() {
    console.log(this.questionForm.value);

    this.quizService.updateQuestion(this.questionForm.value).subscribe(
      () => {
        this.question = {
          ...this.question,
          ...this.questionForm.value
        }
        this.editMode = false;
        this.quizService.disableEdit.next(false);
      },
      err => console.log(err));
  }

}


