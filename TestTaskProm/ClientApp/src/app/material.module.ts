import { NgModule } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCommonModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { MatFormFieldModule } from '@angular/material/form-field';

const modules = [
  MatCardModule,
  MatInputModule,
  MatButtonModule,
  MatCommonModule,
  MatIconModule,
  MatCheckboxModule,
  MatSelectModule,
  MatFormFieldModule,
  NgxMatSelectSearchModule,
];

@NgModule({
  imports: modules,
  exports: modules,
})
export class MaterialModule {}
