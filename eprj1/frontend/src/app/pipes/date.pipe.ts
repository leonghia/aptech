import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'customDate'
})
export class CustomDatePipe implements PipeTransform {

  transform(value: string) {
    const date = new Date(value);
    const datePipe = new DatePipe('en-US');
    return datePipe.transform(date, 'MMMM d, yyyy');
  }

}