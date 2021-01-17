import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import {PaymentDetail} from 'src/app/shared/payment-detail.model'

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: [],
  providers: [PaymentDetail]
})
export class PaymentDetailComponent implements OnInit {

  constructor(public service:PaymentDetail) { }

  ngOnInit(): void {
  }

}
