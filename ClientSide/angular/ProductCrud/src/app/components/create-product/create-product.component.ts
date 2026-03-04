import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
    selector: 'app-create-product',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './create-product.component.html',
    styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent {
    productForm: FormGroup;
    loading = signal(false);
    showSuccessMessage = signal(false);

    constructor(
        private fb: FormBuilder,
        private productService: ProductService,
        private router: Router
    ) {
        this.productForm = this.fb.group({
            name: ['', [Validators.required, Validators.minLength(2)]],
            price: ['', [Validators.required, Validators.min(0.01)]],
            description: ['', [Validators.required, Validators.minLength(5)]],
            productCode: ['', [Validators.required, Validators.minLength(3)]],
            imageUrl: ['', [Validators.pattern('https?://.*')]]
        });
    }

    get f() {
        return this.productForm.controls;
    }

    onSubmit(): void {
        if (this.productForm.valid) {
            this.loading.set(true);
            this.productService.createProduct(this.productForm.value).subscribe({
                next: () => {
                    this.showSuccessMessage.set(true);
                    setTimeout(() => {
                        this.router.navigate(['/']);
                    }, 1500);
                },
                error: (error) => {
                    console.error('Error creating product:', error);
                    this.loading.set(false);
                }
            });
        } else {
            Object.keys(this.productForm.controls).forEach(key => {
                this.productForm.controls[key].markAsTouched();
            });
        }
    }

    goBack(): void {
        this.router.navigate(['/']);
    }
}
