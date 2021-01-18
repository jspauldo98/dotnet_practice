import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";

import { AppComponent } from './app.component';
import { PaymentDetailComponent } from './payment-details/payment-detail/payment-detail.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentDetailListComponent } from './payment-details/payment-detail/payment-detail-list/payment-detail-list.component';
import { PaymentDetailService } from './shared/payment-detail.service';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    PaymentDetailComponent,
    PaymentDetailsComponent,
    PaymentDetailListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass :'toast-bottom-right'
    })
  ],
  providers: [PaymentDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
