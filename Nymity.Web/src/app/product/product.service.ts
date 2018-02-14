import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable'

import { API_URL } from '../app.config';
import { Product } from '../product/product';

@Injectable()
export class ProductService {

    constructor(private http: HttpClient) { }

    list(){
        console.log("Call API....");
        return this.http.get(`${API_URL}/products`)
            .map((products) => {
                return products;
            })
            .catch((error) => {
                return Observable.throw('Error on service get products.');
            });
    }

    get(id: number){
        console.log("Call API....");
        return this.http.get(`${API_URL}/products/${id}`)
            .map((products) => {
                return products;
            })
            .catch((error) => {
                return Observable.throw('Error on service get products.');
            });
    }

}
