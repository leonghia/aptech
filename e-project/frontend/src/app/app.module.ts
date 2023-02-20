import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { LogoCloudComponent } from './layout/logo-cloud/logo-cloud.component';
import { AlternatingFeatureComponent } from './layout/alternating-feature/alternating-feature.component';
import { GradientFeatureComponent } from './layout/gradient-feature/gradient-feature.component';
import { StatsComponent } from './layout/stats/stats.component';
import { CtaComponent } from './layout/cta/cta.component';
import { HeroComponent } from './layout/hero/hero.component';
import { ContactComponent } from './pages/contact/contact.component';
import { FaqComponent } from './pages/faq/faq.component';
import { AboutComponent } from './pages/about/about.component';
import { BridgeComponent } from './pages/bridge/bridge.component';
import { EnterTheViewportNotifierDirective } from './shared/viewport.directive';
import { GalleryComponent } from './pages/gallery/gallery.component';
import { LoginComponent } from './layout/login/login.component';
import { SignupComponent } from './layout/signup/signup.component';
import { BridgesComponent } from './pages/bridges/bridges.component';
import { CategoryComponent } from './pages/category/category.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LogoCloudComponent,
    AlternatingFeatureComponent,
    GradientFeatureComponent,
    StatsComponent,
    CtaComponent,
    HeroComponent,
    ContactComponent,
    FaqComponent,
    AboutComponent,
    BridgeComponent,
    EnterTheViewportNotifierDirective,
    GalleryComponent,
    LoginComponent,
    SignupComponent,
    BridgesComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
