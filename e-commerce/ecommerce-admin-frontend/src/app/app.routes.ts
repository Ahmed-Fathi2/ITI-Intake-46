import { Routes } from '@angular/router';
import { Products } from './Components/products/products';
import { Orders } from './Components/orders/orders';
import { Users } from './Components/users/users';
import { NotFounded } from './Components/not-founded/not-founded';
import { Login } from './Components/login/login';
import { AdminLayout } from './Components/admin-layout/admin-layout';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },
  {
    path: 'admin',
    component: AdminLayout,
    children: [
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'products', component: Products },
      { path: 'orders', component: Orders },
      { path: 'customers', component: Users },
    ],
  },
  { path: '**', component: NotFounded },
];
