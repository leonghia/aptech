import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SwiperModule } from 'swiper/angular';

import { authInterceptorProviders } from './helpers/auth.interceptor';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { LogoCloudComponent } from './components/logo-cloud/logo-cloud.component';
import { AlternatingFeatureComponent } from './components/alternating-feature/alternating-feature.component';
import { GradientFeatureComponent } from './components/gradient-feature/gradient-feature.component';
import { StatsComponent } from './components/stats/stats.component';
import { CtaComponent } from './components/cta/cta.component';
import { HeroComponent } from './components/hero/hero.component';
import { ContactComponent } from './components/contact/contact.component';
import { FaqComponent } from './components/faq/faq.component';
import { AboutComponent } from './components/about/about.component';
import { BridgeComponent } from './components/bridge/bridge.component';
import { EnterTheViewportNotifierDirective } from './directives/viewport.directive';
import { GalleryComponent } from './components/gallery/gallery.component';
import { AllComponent } from './components/all/all.component';
import { CategorizedComponent } from './components/categorized/categorized.component';
import { CustomDatePipe } from './pipes/date.pipe';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { RelatedComponent } from './components/related/related.component';
import { LoginModalComponent } from './components/login-modal/login-modal.component';
import { SignupModalComponent } from './components/signup-modal/signup-modal.component';
import { ProfileComponent } from './components/profile/profile.component';
import { BoardUserComponent } from './components/board-user/board-user.component';
import { SuccessModalComponent } from './components/success-modal/success-modal.component';
import { CompareComponent } from './components/compare/compare.component';
import { CompareNotiComponent } from './components/compare/compare-noti/compare-noti.component';
import { TermsComponent } from './components/terms/terms.component';
import { SitemapComponent } from './components/sitemap/sitemap.component';
import { ReviewModalComponent } from './components/review-modal/review-modal.component';
import { FavoritesComponent } from './components/favorites/favorites.component';
import { FavoritesNotiComponent } from './components/favorites/favorites-noti/favorites-noti.component';

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
    AllComponent,
    CategorizedComponent,
    CustomDatePipe,
    NotFoundComponent,
    SearchResultComponent,
    RelatedComponent,
    LoginModalComponent,
    SignupModalComponent,
    ProfileComponent,
    BoardUserComponent,
    SuccessModalComponent,
    CompareComponent,
    CompareNotiComponent,
    TermsComponent,
    SitemapComponent,
    ReviewModalComponent,
    FavoritesComponent,
    FavoritesNotiComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SwiperModule,
    ReactiveFormsModule
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
