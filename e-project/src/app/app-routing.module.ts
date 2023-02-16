import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BridgeComponent } from './pages/bridge/bridge.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { FaqComponent } from './pages/faq/faq.component';
import { HomeComponent } from './pages/home/home.component';
import { GalleryComponent } from './pages/gallery/gallery.component';
import { Gallery2Component } from './pages/gallery2/gallery2.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'faq', component: FaqComponent},
  {path: 'bridge', component: BridgeComponent},
  {path: 'gallery', component: GalleryComponent},
  {path: 'gallery2', component: Gallery2Component},


];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
