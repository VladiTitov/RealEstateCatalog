import { Injectable } from '@angular/core';
import {HttpClient, HttpHandler, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { ICity } from '../model/ICity.Interface';
import { Property } from '../model/Property';
import { environment } from 'src/environments/environment';
import { IKeyValuePair } from '../model/IKeyValuePair';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAllCities() : Observable<IKeyValuePair[]>{
    return this.http.get<IKeyValuePair[]>(this.baseUrl + '/city');
  }

  getProperty(id: number) {
    return this.http.get<Property>(this.baseUrl + '/property/detail/' + id?.toString());
  }

  getFurnishingTypes() : Observable<IKeyValuePair[]> {
    return this.http.get<IKeyValuePair[]>(this.baseUrl + '/furnishingtype/list');
  }

  getPropertyTypes() : Observable<IKeyValuePair[]> {
    return this.http.get<IKeyValuePair[]>(this.baseUrl + '/propertytype/list');
  }

  getAllProperties(SellRent?: number) : Observable<Property[]> {
    return this.http.get<Property[]>(this.baseUrl + '/property/list/' + SellRent?.toString());
  }

  addProperty(property: Property) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.post(this.baseUrl + '/property/add', property, httpOptions);
  }

  newPropID() {
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(+localStorage.getItem('PID')! + 1));
      return +localStorage.getItem('PID')!;
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }

  getPropertyAge(dateofEstablishment: Date) : string {
    const today = new Date();
    const estDate = new Date(dateofEstablishment);
    let age = today.getFullYear() - estDate.getFullYear();
    const m = today.getMonth() - estDate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
      age --;
    }

    if (today < estDate) {
      return '0';
    }

    if (age === 0) {
      return 'Less than a year';
    }

    return age.toString();
  }
}
