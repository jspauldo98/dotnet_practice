import { Injectable } from "@angular/core";
@Injectable()
export class PaymentDetail {
   PMId           : number;
   CardOwnerName  : string;
   CardNumber     : string;
   ExpirationDate : string;
   CVV            : string;
}
