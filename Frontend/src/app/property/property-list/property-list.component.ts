import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  properties: Array<any> = [
    {
      "Name": "Birla House",
      "Type":"House",
      "Price":1200,
      "Id":1,
    },
    {
      "Name": "Single Stack",
      "Type":"House",
      "Price":1400,
      "Id":2,
    },
    {
      "Name": "Four Walls",
      "Type":"House",
      "Price":1670,
      "Id":3,
    },
    {
      "Name": "New Tiles",
      "Type":"House",
      "Price":1510,
      "Id":4,
    },
    {
      "Name": "Blue Windows",
      "Type":"House",
      "Price":2100,
      "Id":5,
    },
    {
      "Name": "Double Doors",
      "Type":"House",
      "Price":1000,
      "Id":6,
    }
]

  constructor() { }

  ngOnInit() {
  }

}
