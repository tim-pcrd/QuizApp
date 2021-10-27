import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControlValidationComponent } from './components/form-control-validation/form-control-validation.component';
import { ModalComponent } from './components/modal/modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [
    FormControlValidationComponent,
    ModalComponent
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
    ModalComponent
  ]
})
export class SharedModule { }
