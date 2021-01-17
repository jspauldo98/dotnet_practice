import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import {PaymentDetail} from 'src/app/shared/payment-detail.model'
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: [],
  providers: [PaymentDetail]
})
export class PaymentDetailComponent implements OnInit {

  constructor(public service:PaymentDetail, private service2:PaymentDetailService) { }

  ngOnInit() {
    this.service = {
      PMId          :0,
      CardOwnerName :'',
      CardNumber    :'',
      ExpirationDate:'',
      CVV           :''
    }
  }

  onSubmit(form:NgForm) {    
    this.service2.postPaymentDetail(form.value).subscribe(
      res => {},
      err => {
        console.log(err);
      }
    )
    if (form != null)
      form.resetForm();
  }
}
