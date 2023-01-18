import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Property } from 'src/app/model/Property';
import { HousingService } from 'src/app/services/housing.service';
import { NgxGalleryAnimation } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-property-datail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})

export class PropertyDatailComponent implements OnInit {
  public propertyId: number;
  property = new Property();
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService) { }

  ngOnInit() {
    this.propertyId = +this.route.snapshot.params["id"];
    this.route.data.subscribe(
      (data) => {
        this.property = data['prp'];
    });

    this.property.age = this.housingService.getPropertyAge(this.property.estPossessionOn);

    this.galleryOptions = [
      {
        width: '100%',
        height: '465px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide
      }
    ];

    this.galleryImages = [
      {
        small: 'assets/images/img-1.jpg',
        medium: 'assets/images/img-1.jpg',
        big: 'assets/images/img-1.jpg'
      },
      {
        small: 'assets/images/img-2.jpg',
        medium: 'assets/images/img-2.jpg',
        big: 'assets/images/img-2.jpg'
      },
      {
        small: 'assets/images/img-3.jpg',
        medium: 'assets/images/img-3.jpg',
        big: 'assets/images/img-3.jpg'
      }
    ];
  }
}
