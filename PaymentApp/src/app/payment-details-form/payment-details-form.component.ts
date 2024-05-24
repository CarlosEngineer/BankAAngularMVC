import { PaymentDetail } from './../shared/payment-detail.model';
import { Component,OnInit } from '@angular/core';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-payment-details-form',
  templateUrl: './payment-details-form.component.html',
  styles: [
  ]
})
export class PaymentDetailsFormComponent {

  constructor(public service: PaymentDetailService, private toastr: ToastrService){

  }

    onSubmit(form:NgForm){
      this.service.formSubmitted = true
      if(form.valid){
        if(this.service.formatData.paymentDetailId == 0)
          this.insertRecord(form)
        else
        this.updateRecord(form)
      }
    
    }
    insertRecord(form:NgForm){
       this.service.postPaymentDetail()
        .subscribe({
          
          next:res=>{
  
            this.service.list = res as PaymentDetail[]
            this.service.resetForm(form)
            this.toastr.success( 'Inserted Successfuly', 'Payment Detail Register')
            
          },
          error:err => {console.log(err)}
        })

    }
   
    
    updateRecord(form:NgForm)
    {this.service.putPaymentDetail()
      .subscribe({
        next: res =>{

          this.service.list = res as PaymentDetail[]
          this.service.resetForm(form)
          this.toastr.info('Updated Successfuly', 'Payment Detail Register')
          
        },
        error:err => {console.log(err)}
      })
    }

}
