import { PaymentDetail } from './payment-detail.model';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
  private readonly apiPath: string;
  formData:PaymentDetail;

  constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.apiPath = baseUrl + 'api/PaymentDetail';
  }

  // Communication with ASP.NET Controller
  postPaymentDetail(formData:PaymentDetail) {    
    return this.http.post(this.apiPath,formData)
  }
}
