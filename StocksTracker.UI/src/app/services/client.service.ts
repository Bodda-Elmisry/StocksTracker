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

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseURL + "clients").pipe(
      catchError(error => {
        console.error('Error fetching clients:', error);
        return throwError(error); 
      })
    );
    
  }

  getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(this.baseURL + 'clientbyid').pipe(
      catchError(error => {
        console.error('Error fetching clients:', error);
        return throwError(error); 
      })
    );
  }

  createClient(client: Client): Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + 'createclient', client).pipe(
      catchError(error => {
        console.error('Error fetching clients:', error);
        return throwError(error);
      })
    );
  }

  updateClient(client: Client): Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + 'updateclient', client).pipe(
      catchError(error => {
        console.error('Error fetching clients:', error);
        return throwError(error); 
      })
    );
  }
  

  deleteClient(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseURL + 'deleteclient').pipe(
      catchError(error => {
        console.error('Error fetching clients:', error);
        return throwError(error); 
      })
    );
  }

}
