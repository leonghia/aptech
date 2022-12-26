import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatExpansionModule} from '@angular/material/expansion';


import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ViewComponent } from './view/view.component';
import { FavoritesComponent } from './sidebar/favorites/favorites.component';
import { InboxComponent } from './sidebar/favorites/inbox/inbox.component';
import { SentComponent } from './sidebar/favorites/sent/sent.component';
import { JohnComponent } from './sidebar/john/john.component';
import { JohnInboxComponent } from './sidebar/john/john-inbox/john-inbox.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    ViewComponent,
    FavoritesComponent,
    InboxComponent,
    SentComponent,
    JohnComponent,
    JohnInboxComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
