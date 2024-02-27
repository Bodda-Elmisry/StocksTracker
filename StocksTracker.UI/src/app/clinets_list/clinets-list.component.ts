import { ClientService } from '../services/client.service';
import { Client } from '../models/client.model';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'clients_list',
  templateUrl: './clinets-list.component.html'
})

export class ClientsList implements OnInit {

  clients: Client[] = [];
  errorMessage!: string;
  loading: boolean = false;
  trakingStarted: boolean = true;

  constructor(private clientService: ClientService, private router: Router) { }



  ngOnInit(): void {
    this.getClients();
  }

  startTracking() {
    this.trakingStarted = false;

    try {
      this.clientService.startTracking();
    }
    catch (error) {
      console.error('Error fetching clients:', error);
    }
  }



  getClients() {
    this.loading = true;
    this.errorMessage = "";

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
    catch (error) {
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

  addClient() {
    this.router.navigate(['newClient']);
  }

}
