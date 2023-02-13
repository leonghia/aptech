import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { LogoCloudComponent } from './shared/logo-cloud/logo-cloud.component';
import { AlternatingFeatureComponent } from './sections/alternating-feature/alternating-feature.component';
import { GradientFeatureComponent } from './sections/gradient-feature/gradient-feature.component';
import { StatsComponent } from './sections/stats/stats.component';
import { CtaComponent } from './sections/cta/cta.component';
import { HeroComponent } from './sections/hero/hero.component';
import { ContactComponent } from './pages/contact/contact.component';
import { PageHeadingComponent } from './shared/page-heading/page-heading.component';
import { FaqComponent } from './pages/faq/faq.component';
import { AboutComponent } from './pages/about/about.component';
import { BridgeComponent } from './bridge/bridge.component';

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
    PageHeadingComponent,
    FaqComponent,
    AboutComponent,
    BridgeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
