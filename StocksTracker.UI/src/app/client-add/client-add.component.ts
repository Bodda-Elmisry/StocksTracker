import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from '../models/client.model';
import { ClientService } from '../services/client.service';

@Component({
  selector: 'app-cluent-add',
  templateUrl: './cluent-add.component.html'
})

export class ClientAdd implements OnInit {
  newClient: Client = { id: 0, firstName: '', lastName: '', emailAddress: '', phoneNumber: '', nationality: '' }
  nationalities: any[] = []

  constructor(private rout: ActivatedRoute, private clientService: ClientService, private router: Router) { }


  ngOnInit() {
    this.getNationalities();
  }

  saveClient() {

    this.addClient();
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


  addClient() {
    this.clientService.createClient(this.newClient).subscribe(
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


}
