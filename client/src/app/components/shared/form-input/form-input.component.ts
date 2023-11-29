import {Component, ElementRef, Input, OnInit, Self, ViewChild} from '@angular/core';
import {ControlValueAccessor, NgControl} from "@angular/forms";


@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild('input', {static: true}) input!: ElementRef;
  @Input() type: string = 'text';
  @Input() label: string = '';

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }

  ngOnInit() {
    const control = this.controlDir.control!;
    const validators = control.validator ? [control.validator] : [];
    const asyncValidators = control.asyncValidator ? [control.asyncValidator] : [];

    control.setValidators(validators);
    control.setAsyncValidators(asyncValidators);
    control.updateValueAndValidity();
  }

  onChange(event:Event) {
    const inputValue = (event.target as HTMLInputElement).value;
  }

  onTouched() {
  }

  writeValue(obj: any): void {
    this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
}
