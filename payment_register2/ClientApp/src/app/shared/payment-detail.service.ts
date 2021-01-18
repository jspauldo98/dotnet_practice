import { PaymentDetail } from './payment-detail.model';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
  private readonly apiPath: string;
  formData:PaymentDetail;
  list: PaymentDetail[];

  constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.apiPath = baseUrl + 'api/PaymentDetail';
  }

  // Communication with ASP.NET Controller

  postPaymentDetail() {    
    // return this.http.post(this.apiPath, this.formData);
  }

  putPaymentDetail() {    
    // return this.http.put(this.apiPath + '/' + this.formData.PMId, this.formData);
  }

  deletePaymentDetail(id) {    
    // return this.http.delete(this.apiPath + '/' + id);
  }

  refreshList() {
    // this.http.get(this.apiPath).toPromise().then(res => this.list = res as PaymentDetail[]);
  }
}
