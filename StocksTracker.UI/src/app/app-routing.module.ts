import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientDetail } from './client_detail/client-detail.component'

const routes: Routes = [
  { path: 'clientDetails/:id', component: ClientDetail }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
