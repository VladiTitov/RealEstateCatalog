import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/model/Property';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-datail',
  templateUrl: './property-datail.component.html',
  styleUrls: ['./property-datail.component.css']
})

export class PropertyDatailComponent implements OnInit {
  public propertyId: number;
  property = new Property();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService) { }

  ngOnInit() {
    this.propertyId = this.route.snapshot.params["id"];

    this.route.params.subscribe((params) => {
      this.propertyId = +params['id'];
      this.housingService
        .getProperty(this.propertyId)
        .subscribe(data =>
          {
            var mappedData = data as Property;
            this.property = mappedData;
          });
    });
  }
}
