import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BridgeComponent } from './pages/bridge/bridge.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { FaqComponent } from './pages/faq/faq.component';
import { HomeComponent } from './pages/home/home.component';
import { GallerysComponent } from './gallerys/gallerys.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'faq', component: FaqComponent},
  {path: 'bridge', component: BridgeComponent},
  {path: 'gallerys', component: GallerysComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
