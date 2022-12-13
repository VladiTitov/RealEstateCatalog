import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-datail',
  templateUrl: './property-datail.component.html',
  styleUrls: ['./property-datail.component.css']
})

export class PropertyDatailComponent implements OnInit {
  public propertyId: number;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.propertyId = this.route.snapshot.params["id"];
  }

  onSelectNext(){
    this.propertyId++;
    this.router.navigate(['property-detail', this.propertyId]);
  }
}
