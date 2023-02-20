import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BridgeComponent } from './pages/bridge/bridge.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { FaqComponent } from './pages/faq/faq.component';
import { HomeComponent } from './pages/home/home.component';
import { GalleryComponent } from './pages/gallery/gallery.component';
import { BridgesComponent } from './pages/bridges/bridges.component';
import { CategoryComponent } from './pages/category/category.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'all-bridges', component: BridgesComponent},
  {path: 'bridge', component: BridgeComponent},
  {path: 'gallery', component: GalleryComponent},
  {path: 'about', component: AboutComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'faq', component: FaqComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
