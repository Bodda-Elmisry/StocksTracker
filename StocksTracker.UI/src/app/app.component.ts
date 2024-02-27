import { Component, OnInit, ViewChild, viewChild } from '@angular/core';
import { Router } from '@angular/router';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.navigate(['clientsList']);   
  }
  



  checkValues(name: any) {
    console.log(name);
  }

  


  





}
