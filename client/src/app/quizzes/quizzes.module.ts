import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuizzesComponent } from './quizzes/quizzes.component';
import { SharedModule } from '../shared/shared.module';
import { QuizzesRoutingModule } from './quizzes-routing.module';



@NgModule({
  declarations: [
    QuizzesComponent
  ],
  imports: [
    SharedModule,
    QuizzesRoutingModule
  ]
})
export class QuizzesModule { }
