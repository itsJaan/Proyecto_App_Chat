import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistryRoutingModule } from './registry-routing.module';
import { RegistryComponent } from './registry.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


@NgModule({
  declarations: [RegistryComponent],
  imports: [
    CommonModule,
    RegistryRoutingModule,
    FormsModule
  ]
})
export class RegistryModule { }
