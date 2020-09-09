import { NgModule } from '@angular/core';
import { Routes, RouterModule , Params } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  { path: 'dashboard/:username', component: DashboardComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
