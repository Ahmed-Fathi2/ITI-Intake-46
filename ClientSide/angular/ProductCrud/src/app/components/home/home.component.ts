import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    products = signal<Product[]>([]);
    loading = signal(false);

    constructor(
        private productService: ProductService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.loadProducts();
    }

    loadProducts(): void {
        this.loading.set(true);
        this.productService.getAllProducts().subscribe({
            next: (data) => {
                this.products.set(data);
                this.loading.set(false);
            },
            error: (error) => {
                console.error('Error loading products:', error);
                this.loading.set(false);
            }
        });
    }

    viewProduct(id: string | number | undefined): void {
        if (id) {
            this.router.navigate(['/product', id]);
        }
    }

    createProduct(): void {
        this.router.navigate(['/create']);
    }
}
