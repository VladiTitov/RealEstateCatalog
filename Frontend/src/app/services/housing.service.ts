import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { IProperty } from '../property/IProperty.Interface';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getAllProperties() : Observable<IProperty[]> {
    return this.http.get('data/properties.json').pipe(
      map(data => {
        const array = data as Array<IProperty>;
        const propertiesArray: Array<IProperty> = [];
        for (const id in array) {
          if (array.hasOwnProperty(id)){
            propertiesArray.push(array[id]);
          }
        }
        return propertiesArray;
      })
    );
  }
}
