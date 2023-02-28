import { Component } from '@angular/core';
import { ApiService } from 'src/app/shared/api.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  loading: boolean = false;
  newUser = {
    username: '',
    email: '',
    password: '',
    first_name: '',
    last_name: ''
  };

  success: boolean = false;

  constructor(private apiService: ApiService) {}

  onSubmit() {
    this.loading = true;
    this.apiService.addUser(this.newUser).subscribe((response) => {
      // Handle the response here
      
    });
    setTimeout(() => {
      this.loading = false;
      this.success = true;
    }, 1500);
    
  }
}
