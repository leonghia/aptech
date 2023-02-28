import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BridgeComponent } from './pages/bridge/bridge.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { FaqComponent } from './pages/faq/faq.component';
import { HomeComponent } from './pages/home/home.component';
import { GalleryComponent } from './pages/gallery/gallery.component';
import { AllComponent } from './pages/all/all.component';
import { CategorizedComponent } from './pages/categorized/categorized.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { SearchResultComponent } from './pages/search-result/search-result.component';
import { SuccessModalComponent } from './layout/success-modal/success-modal.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'all-bridges', component: AllComponent},
  {path: 'longest-bridges', component: CategorizedComponent},
  {path: 'bridge/:id', component: BridgeComponent},
  {path: 'gallery', component: GalleryComponent},
  {path: 'about', component: AboutComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'faq', component: FaqComponent},
  {path: 'search', component: SearchResultComponent},
  {path: 'success', component: SuccessModalComponent},
  {path: 'categorized/:sort', component: CategorizedComponent},
  
  // Wildcard route for 404 not found
  {path: '**', pathMatch: 'full', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
