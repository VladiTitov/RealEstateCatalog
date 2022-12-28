import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { IPropertyBase } from '../model/IPropertyBase.Interface';
import { Property } from '../model/Property';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getAllProperties(SellRent: number) : Observable<IPropertyBase[]> {
    return this.http.get('data/properties.json').pipe(
      map(data => {
        const array = data as Array<IPropertyBase>;
        const propertiesArray: Array<IPropertyBase> = [];
        for (const id in array) {
          if (array.hasOwnProperty(id) && array[id].SellRent === SellRent){
            propertiesArray.push(array[id]);
          }
        }
        return propertiesArray;
      })
    );
  }

  addProperty(property: Property) {
    localStorage.setItem('newProp', JSON.stringify(property));
  }
}
