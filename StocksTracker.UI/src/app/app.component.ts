import { Component, OnInit } from '@angular/core';
import { ClientService } from './services/client.service'
import { Client } from './models/client.model'
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  clients: Client[] = [];
  errorMessage!: string;
  loading: boolean = false;

  constructor(private clientService: ClientService, private router: Router) { }

  ngOnInit(): void {
    this.getClients();
  }

  checkValues(name: any) {
    console.log(name);
  }

  getClients() {
    this.loading = true;
    this.errorMessage = "";
    //await this.clientService.getClients().subscribe(c => {
    //  this.clients = c;
    //  console.log(this.clients);
    //});
    try {
      this.clientService.getClients().subscribe(
        (response) => {
          console.log('response received')
          console.log(response)
          this.clients = response; 
        },
        (error) => {                              //error() callback
          console.error('Request failed with error')
          console.error(error)
          this.errorMessage = error;
          this.loading = false;
        },
        () => {                                   //complete() callback
          console.log('Request completed')
          this.loading = false;
          
        }
      )
    }
    catch(error){
      console.error('Error fetching clients:', error);
    }
  }


  deleteClient(id: number) {
    this.clientService.deleteClient(id).subscribe(
      (response) => {
        console.log("response received = " + response);
        if (response == true) {
          this.getClients();
        }
      },
      (error) => {                              //error() callback
        console.error('Request failed with error')
        console.error(error)
        this.errorMessage = error;
        this.loading = false;
      },
      () => {                                   //complete() callback
        console.log('Request completed')
        this.loading = false;

      }
    )
  }

  updateClient(id: number) {
    this.router.navigate(['clientDetails', id]);
  }





}
