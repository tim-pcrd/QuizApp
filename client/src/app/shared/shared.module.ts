import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControlValidationComponent } from './components/form-control-validation/form-control-validation.component';
import { ModalComponent } from './components/modal/modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { SafeHtmlPipe } from './pipes/safe-html.pipe';



@NgModule({
  declarations: [
    FormControlValidationComponent,
    ModalComponent,
    SafeHtmlPipe
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
    SafeHtmlPipe
  ]
})
export class SharedModule { }
