import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuizzesComponent } from './quizzes.component';
import { SharedModule } from '../shared/shared.module';
import { QuizzesRoutingModule } from './quizzes-routing.module';
import { QuizDetailsComponent } from './quiz-details/quiz-details.component';
import { QuestionComponent } from './quiz-details/question/question.component';
import {DragDropModule} from '@angular/cdk/drag-drop';



@NgModule({
  declarations: [
    QuizzesComponent,
    QuizDetailsComponent,
    QuestionComponent,

  ],
  imports: [
    SharedModule,
    QuizzesRoutingModule,
    DragDropModule
  ]
})
export class QuizzesModule { }
