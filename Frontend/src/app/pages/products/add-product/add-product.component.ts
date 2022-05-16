import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs';
import { ProductsService } from '../../services/products.service';
import { NewProduct } from '../models/newProduct';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  product!: NewProduct;
  isUpdating : boolean = false;
  id!: number;
  error: string = "";

  productForm: FormGroup = this.formBuilder.group({
    name: ["", [Validators.required, Validators.minLength(4)]],
    stock: [0,[Validators.required, Validators.min(0)]],
    description: ["",[Validators.required]],
    price:[,[Validators.required, Validators.min(1)]],
    categoryId:[ , [Validators.required]]
  }); 

  constructor(private productService: ProductsService,
              private formBuilder: FormBuilder,
              private activatedRoute: ActivatedRoute,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params
    .pipe(
      switchMap(({ id }) => this.productService.getProductById(parseInt(id)))
      ).subscribe(product => {
        this.productForm.patchValue({name: product.name, stock: product.stock, description: product.description, price: product.price, categoryId: product.categoryId})
        this.id = product.id;
        this.isUpdating = product.id != undefined ? true: false;
      }); 
    }

  saveProduct(productForm: FormGroup){
    if(this.productForm.invalid){
      this.productForm.markAllAsTouched();
    return;
    }

    this.product = productForm.value;
    
    if (this.isUpdating) {
      this.product.id = this.id;
      this.productService.updateProduct(this.product).subscribe({
        error: (e) =>  this.toastr.error(e.error)
        });

      this.productForm.reset();   
      this.router.navigate(['/products/list'])   
    }else{
      this.productService.addNewProduct(this.product).subscribe({
        error: (e) =>  this.toastr.error(e.error)
        });
      this.productForm.reset();  
    }
  }

  invalidField( control: string ): boolean {
    return (this.productForm.controls[control].touched && this.productForm.controls[control].invalid); 
  }


}
