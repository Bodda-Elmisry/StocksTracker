import { Injectable } from "@angular/core"
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from "rxjs"
import { map, catchError } from 'rxjs/operators';
import { Client } from "../models/client.model"

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseURL: string = "http://localhost:5013/api/Client/";
  //clientsList: any[] = [];

  constructor(private http: HttpClient) {

  }

  startTracking(): Observable<Client[]> {
    return this.http.get<Client[]>("http://localhost:5013/api/stock/CallWCF");

  }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseURL + "clients");
    
  }

  getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(this.baseURL + 'clientbyid?Id=' + id);
  }

  getNationalities(): Observable<any[]> {
    return this.http.get<[]>(this.baseURL + 'GetNationalitiyes');
  }

  createClient(client: Client): Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + 'createclient', client);
  }

  updateClient(client: Client): Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + 'updateclient', client);
  }
  

  deleteClient(id: number): Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + 'deleteclient' , id);
  }

}
