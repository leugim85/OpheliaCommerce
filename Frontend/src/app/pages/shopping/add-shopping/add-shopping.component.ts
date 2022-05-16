import { Component, OnInit } from '@angular/core';
import { ShoppingService } from '../../services/shopping.service';
import { Shopping } from '../models/shopping';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../products/models/product';
import { Client } from '../models/Clients';
import { ClientsService } from '../../services/clients.service';
import { ProductsService } from '../../services/products.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-shopping',
  templateUrl: './add-shopping.component.html',
  styleUrls: ['./add-shopping.component.css']
})
export class AddShoppingComponent implements OnInit {
  shopping!: Shopping;
  clients!: Client[];
  products!: Product[];

  shoppingForm: FormGroup = this.formBuilder.group({
    clientId: [, Validators.required],
    date: [,Validators.required],
    products: this.formBuilder.array([], Validators.required)  
  });

  newProduct: FormGroup = this.formBuilder.group({
    id:[ 0, Validators.required],
    quantity: [1 , Validators.required]
  }, Validators.required);

  get newProductArr() {
    return this.shoppingForm.get('products') as FormArray;
  }

  constructor(private shoppingService: ShoppingService,
              private formBuilder: FormBuilder,
              private clientsService: ClientsService,
              private productsService: ProductsService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadFormFieldsInfo();
    
  }

 loadFormFieldsInfo() {
    this.clientsService.getClients().subscribe(clients => this.clients = clients);
    this.productsService.getProducts().subscribe(products => this.products = products);
  }
  

  invalidField( field: string ){
    return this.shoppingForm.controls[field].invalid &&
     this.shoppingForm.controls[field].touched;
   }
 
   addProduct(){
     if (this.newProduct.invalid)
       return; 
       this.newProduct.controls["id"].setValue(parseInt(this.newProduct.controls["id"].value));
       this.newProductArr.push(new FormControl(this.newProduct.value, Validators.required));
       this.newProduct.reset();
   }
 
   save(){
     if (this.shoppingForm.invalid){
       this.shoppingForm.markAllAsTouched();
       return;
     }
     this.shoppingForm.controls["clientId"].setValue(parseInt(this.shoppingForm.controls["clientId"].value));
     this.shopping = this.shoppingForm.value;  
     this.shoppingService.addShopping(this.shopping).subscribe({
      error: (e) =>  this.toastr.error(e.error)
      });    
   }
 
   delete( index:number ){
     this.newProductArr.removeAt(index)
   }
  }
