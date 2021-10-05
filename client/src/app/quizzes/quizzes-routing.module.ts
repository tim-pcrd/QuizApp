import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuizDetailsComponent } from './quiz-details/quiz-details.component';
import { QuizzesComponent } from './quizzes.component';

const routes: Routes = [
  {path:'', component: QuizzesComponent},
  {path:':id', component: QuizDetailsComponent},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class QuizzesRoutingModule { }
