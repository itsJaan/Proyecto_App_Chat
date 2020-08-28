import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistryRoutingModule } from './registry-routing.module';
import { RegistryComponent } from './registry.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [RegistryComponent],
  imports: [
    CommonModule,
    RegistryRoutingModule,
    ReactiveFormsModule
  ]
})
export class RegistryModule { }
