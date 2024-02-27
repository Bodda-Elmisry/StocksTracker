import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientDetail } from './client_detail/client-detail.component';
import { ClientsList } from './clinets_list/clinets-list.component'
import { ClientAdd } from './client-add/client-add.component'

const routes: Routes = [
  { path: 'clientsList', component: ClientsList },
  { path: 'newClient', component: ClientAdd },
  { path: 'clientDetails/:id', component: ClientDetail }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
