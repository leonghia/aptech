import { Component, OnInit } from '@angular/core';
import { FavoritesService } from 'src/app/services/favorites.service';
import { FavoritesNotiService } from './favorites-noti.service';

@Component({
  selector: 'app-favorites-noti',
  templateUrl: './favorites-noti.component.html',
  styleUrls: ['./favorites-noti.component.css']
})
export class FavoritesNotiComponent implements OnInit {
  bridgeNoti!: {
    bridgeName: string,
    status: string
  };

  constructor(private favoritesService: FavoritesService, private favoritesNotiService: FavoritesNotiService) {}

  ngOnInit(): void {
    this.favoritesService.isNotified.subscribe((bridgeNoti: {bridgeName: string, status: string} ) => {
      this.bridgeNoti = bridgeNoti;
      console.log(this.bridgeNoti);
    })
  }

  onCloseFavoritesNoti(): void {
    this.favoritesNotiService.closeFavoritesNoti();
  }
}
