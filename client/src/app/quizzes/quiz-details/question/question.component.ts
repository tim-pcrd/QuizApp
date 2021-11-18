import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { moveItemsInFormArray } from 'src/app/shared/functions/form-functions';
import { IQuestion, IQuestionToCreate } from 'src/app/shared/models/question';
import { IQuiz } from 'src/app/shared/models/quiz';
import * as _ from "underscore";
import { QuizService } from '../../service/quiz.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit, OnDestroy {
  @Input() question!: IQuestion;
  @Input() quizId!: number;
  @Output() questionCreated = new EventEmitter<IQuestion>()
  editMode = false;
  createMode = false;
  disableEditButton = false;
  questionForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private quizService: QuizService) { }

  ngOnDestroy(): void {
    this.quizService.disableEdit.next(false);
  }

  ngOnInit(): void {

    if (this.question.id === 0) {
      this.createMode = true;
      this.quizService.disableEdit.next(true)
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
      id: [this.question.id],
      text: [this.question.text, [Validators.required, Validators.maxLength(500)]],
      order: [this.question.order, [Validators.required]],
      answers: this.fb.array([])
    });
    this.addAnswers();
    console.log(this.question);
  }

  addAnswers() {
    for(let answer of this.question.answers) {
      this.answers.push(this.fb.group({
        id: [answer.id],
        order: [answer.order, [Validators.required]],
        text: [answer.text, [Validators.required, Validators.maxLength(50)]],
        correct: [answer.correct, [Validators.required]]
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

    if(this.questionForm.valid) {
      if(this.editMode) {
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
      } else {
        const createdQuestion: IQuestionToCreate = {
          quizId: this.quizId,
          text: this.questionForm.value.text,
          order: this.questionForm.value.order,
          answers: this.questionForm.value.answers.map(({id, ...answer}: any) => answer)
        }
        console.log(createdQuestion)
        this.questionCreated.emit(createdQuestion as IQuestion)
        // this.quizService.createQuiz(this.questionForm.value).subscribe(
        //   id => {
        //     this.createMode = false;
        //   },
        //   error => console.log(error)
        // );
      }
    }
  }

}


