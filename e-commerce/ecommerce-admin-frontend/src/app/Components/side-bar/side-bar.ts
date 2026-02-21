import { Component, inject } from '@angular/core';
import { SidebarService } from '../../Core/Services/sidebar.service';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-side-bar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './side-bar.html',
  styleUrl: './side-bar.css',
})
export class SideBar {
  private sidebar = inject(SidebarService);

  protected isOpen = this.sidebar.isOpen;

  toggle(): void {
    this.sidebar.toggle();
  }

  open(): void {
    this.sidebar.open();
  }

  close(): void {
    this.sidebar.close();
  }
}
