import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs/operators';
import { moveItemsInFormArray } from 'src/app/shared/functions/form-functions';
import { IQuestion, IQuestionToCreate } from 'src/app/shared/models/question';
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
  @Output() questionRemoved = new EventEmitter<IQuestion>();
  @Output() questionCreated = new EventEmitter<IQuestion>();

  imageSrc: string|null = null;
  editMode = false;
  createMode = false;
  disableEditButton = false;
  questionForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private quizService: QuizService, private toastr: ToastrService ) { }

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
      image: [null],
      imageExt: [null],
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

  onFileChange(event:any) {
    const reader = new FileReader();
    const file:File = event.target.files[0];


    if (file) {
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.imageSrc = reader.result as string;
        this.questionForm.patchValue({image: this.imageSrc.split('base64,')[1], imageExt: file.name.split('.').slice(-1)[0]});
        console.log(this.questionForm.value);
      }
    }
  }

  deleteQuestion() {
    if (this.question.id) {

      this.quizService.deleteQuestion(this.question.id).subscribe(() => {
        console.log('Vraag verwijderd');
        this.questionRemoved.emit(this.question);
        this.toastr.success(`Vraag (id: ${this.question.id}) succesvol verwijderd`)
      },error => console.log(error));
    }

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
            this.toastr.success(`Vraag (id: ${this.question.id}) succesvol gewijzigd`)
          },
          err => console.log(err));
      } else {

        const imageFile = this.questionForm.value.image && this.questionForm.value.imageExt
          ? {image: this.questionForm.value.image, extension: this.questionForm.value.imageExt}
          : undefined;

        const createdQuestion: IQuestionToCreate = {
          quizId: this.quizId,
          text: this.questionForm.value.text,
          order: this.questionForm.value.order,
          imageFile,
          answers: this.questionForm.value.answers.map(({id, ...answer}: any) => answer)
        }
        this.quizService.createQuestion(createdQuestion).pipe(
          switchMap((response: any) => this.quizService.getQuestion(response.id))
        )
        .subscribe((question: IQuestion) => {
          this.createMode = false;
          this.questionCreated.emit(question);
          this.toastr.success(`Vraag (id: ${question.id}) succesvol toegevoegd`)
        }, error => console.log(error))
      }
    }
  }

}


