import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControlValidationComponent } from './components/form-control-validation/form-control-validation.component';



@NgModule({
  declarations: [
    FormControlValidationComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CommonModule,
    PaginationModule,
    ReactiveFormsModule,
    FormControlValidationComponent
  ]
})
export class SharedModule { }
