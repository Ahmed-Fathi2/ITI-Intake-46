import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
    selector: 'app-update-product',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './update-product.component.html',
    styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
    productForm: FormGroup;
    loading = signal(false);
    showSuccessMessage = signal(false);
    productId: string | number = '';

    constructor(
        private fb: FormBuilder,
        private productService: ProductService,
        private route: ActivatedRoute,
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

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.productId = id;
            this.loadProduct(this.productId);
        }
    }

    loadProduct(id: string | number): void {
        this.loading.set(true);
        this.productService.getProductById(id).subscribe({
            next: (product) => {
                this.productForm.patchValue({
                    name: product.name,
                    price: product.price,
                    description: product.description,
                    productCode: product.productCode,
                    imageUrl: product.imageUrl || ''
                });
                this.loading.set(false);
            },
            error: (error) => {
                console.error('Error loading product:', error);
                this.loading.set(false);
                this.router.navigate(['/']);
            }
        });
    }

    get f() {
        return this.productForm.controls;
    }

    onSubmit(): void {
        if (this.productForm.valid) {
            this.loading.set(true);
            this.productService.updateProduct(this.productId, this.productForm.value).subscribe({
                next: () => {
                    this.showSuccessMessage.set(true);
                    setTimeout(() => {
                        this.router.navigate(['/']);
                    }, 1500);
                },
                error: (error) => {
                    console.error('Error updating product:', error);
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
