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
    user: string;
    tokens: string;
  };

  constructor() {
    this.result = {
      user: '',
      tokens: '',
    };
  }
}
