import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';

@Component({
    selector: 'app-product-details',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './product-details.component.html',
    styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
    product = signal<Product | null>(null);
    loading = signal(false);
    showSuccessMessage = signal(false);

    constructor(
        private productService: ProductService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.loadProduct(id);
        }
    }

    loadProduct(id: string | number): void {
        this.loading.set(true);
        this.productService.getProductById(id).subscribe({
            next: (data) => {
                this.product.set(data);
                this.loading.set(false);
            },
            error: (error) => {
                console.error('Error loading product:', error);
                this.loading.set(false);
                this.router.navigate(['/']);
            }
        });
    }

    updateProduct(): void {
        const product = this.product();
        if (product?.id) {
            this.router.navigate(['/update', product.id]);
        }
    }

    deleteProduct(): void {
        const product = this.product();
        if (product?.id && confirm('Are you sure you want to delete this product?')) {
            this.loading.set(true);
            this.productService.deleteProduct(product.id).subscribe({
                next: () => {
                    this.showSuccessMessage.set(true);
                    setTimeout(() => {
                        this.router.navigate(['/']);
                    }, 1500);
                },
                error: (error) => {
                    console.error('Error deleting product:', error);
                    this.loading.set(false);
                }
            });
        }
    }

    goBack(): void {
        this.router.navigate(['/']);
    }
}
