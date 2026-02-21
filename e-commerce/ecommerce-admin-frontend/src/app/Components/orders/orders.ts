import { Component, inject, OnInit, signal } from '@angular/core';
import { OrdersService } from '../../Core/Services/orders';
import { Order } from '../../Core/Interfaces/iorder';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './orders.html',
  styleUrl: './orders.css',
})
export class Orders implements OnInit {
  private orderService = inject(OrdersService);

  orders = signal<Order[]>([]);

  ngOnInit(): void {
    this.orderService.getAllOrders().subscribe({
      next: (orders) => {
        this.orders.set(orders);
      },
    });

    console.log(this.orders);
  }
}
