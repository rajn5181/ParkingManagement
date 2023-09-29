import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class JwtauthModule {
  isSuccess: boolean = false;
  message: string = '';
  result: {
    user: {
      role: string;
    };
    tokens: string;
  } = {
    user: {
      role: '',
    },
    tokens: '',
  };

  constructor() {}
}
