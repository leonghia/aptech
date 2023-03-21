import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BridgeComponent } from './components/bridge/bridge.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { FaqComponent } from './components/faq/faq.component';
import { HomeComponent } from './components/home/home.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { AllComponent } from './components/all/all.component';
import { CategorizedComponent } from './components/categorized/categorized.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { TermsComponent } from './components/terms/terms.component';
import { SitemapComponent } from './components/sitemap/sitemap.component';
import { FavoritesComponent } from './components/favorites/favorites.component';

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
  {path: 'categorized/:sort', component: CategorizedComponent},
  {path: 'terms-conditions', component: TermsComponent},
  {path: 'sitemap', component: SitemapComponent},
  {path: 'favorites', component: FavoritesComponent},
  
  // Wildcard route for 404 not found
  {path: '**', pathMatch: 'full', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
