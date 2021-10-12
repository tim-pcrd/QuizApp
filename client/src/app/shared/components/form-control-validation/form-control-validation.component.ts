import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'form-control-validation',
  templateUrl: './form-control-validation.component.html',
  styleUrls: ['./form-control-validation.component.scss']
})
export class FormControlValidationComponent implements OnInit {
  @Input() control!: AbstractControl;
  @Input() controlName: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
