import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControlValidationComponent } from './components/form-control-validation/form-control-validation.component';
import { ModalComponent } from './components/modal/modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { SafeHtmlPipe } from './pipes/safe-html.pipe';
import { HoldableDirective } from './directives/holdable.directive';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';



@NgModule({
  declarations: [
    FormControlValidationComponent,
    ModalComponent,
    SafeHtmlPipe,
    HoldableDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CommonModule,
    PaginationModule,
    ModalModule,
    ReactiveFormsModule,
    FormControlValidationComponent,
    ModalComponent,
    SafeHtmlPipe,
    HoldableDirective,
    ProgressbarModule
  ]
})
export class SharedModule { }
