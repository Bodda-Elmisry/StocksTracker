import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from '../models/client.model';
import { ClientService } from '../services/client.service';


@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html'
})

export class ClientDetail implements OnInit {
  client: Client = { id: 0, firstName: '', lastName: '', emailAddress: '', phoneNumber: '', nationality: '' }
  nationalities: any[] = []

  constructor(private rout: ActivatedRoute, private clientService: ClientService, private router: Router) { }


  ngOnInit() {
    const id = this.rout.snapshot.paramMap.get('id');
    if (id) {
      this.getNationalities();
      this.getClientDetails(parseInt(id));

    }
  }

  getClientDetails(id: number) {
    this.clientService.getClientById(id).subscribe(
      (response) => {
        console.log("response received = " + response);
        this.client = response;
      },
      (error) => {                              //error() callback
        console.error('Request failed with error')
        console.error(error);
      },
      () => {                                   //complete() callback
        console.log('Request completed')
      }
    );
  }

  getNationalities() {
    this.clientService.getNationalities().subscribe(
      (response) => {
        console.log('response received')
        console.log(response)
        this.nationalities = response;
      },
      (error) => {                              //error() callback
        console.error('Request failed with error')
        console.error(error)
      },
      () => {                                   //complete() callback
        console.log('Request completed')

      }
    )
  }

  saveClient() {
    if (this.client.id) {
      this.updateClient();
    }
    else {
      this.addClient();
    }
    
  }

  updateClient() {
    this.clientService.updateClient(this.client).subscribe(
      (response) => {
        console.log("response received = " + response);
        if (response) {
          this.router.navigate(['clientsList']);
        }
      },
      (error) => {                              //error() callback
        console.error('Request failed with error')
        console.error(error);
      },
      () => {                                   //complete() callback
        console.log('Request completed')
      }
    );
  }

  addClient() {
    this.clientService.createClient(this.client).subscribe(
      (response) => {
        console.log("response received = " + response);
        if (response) {
          //navigate to home component
        }
      },
      (error) => {                              //error() callback
        console.error('Request failed with error')
        console.error(error);
      },
      () => {                                   //complete() callback
        console.log('Request completed')
      }
    );
  }


}
