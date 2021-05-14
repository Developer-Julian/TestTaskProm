import { HttpProxyService } from './../../../services/http-proxy.service';
import { Router } from '@angular/router';
import { RegistrationService } from './../../../services/registration.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ListItem } from 'src/app/interfaces/list-item.interface';
import { Observable, of, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss'],
})
export class AddressComponent implements OnInit, OnDestroy {
  private unsubscribe$: Subject<void> = new Subject<void>();

  public form: FormGroup = new FormGroup({
    country: new FormControl('', [Validators.required]),
    countryFilter: new FormControl(''),
    province: new FormControl('', [Validators.required]),
    provinceFilter: new FormControl(''),
  });

  public countries: ListItem[] = [];
  public provinces: ListItem[] = [];

  constructor(
    private registrationService: RegistrationService,
    private router: Router,
    private httpProxy: HttpProxyService
  ) {}

  public ngOnDestroy(): void {
    this.unsubscribe$.next();
  }

  public ngOnInit(): void {
    this.getCountries();
    this.form.controls.country.valueChanges.subscribe((value: number) => {
      this.getProvinces(value);
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }

    this.registrationService.fillAddress(
      this.form.controls.country.value,
      this.form.controls.province.value
    );
    this.httpProxy
      .registerUser(this.registrationService.getLoginInfo())
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (_) => {
          this.registrationService.register();
          this.router.navigate(['/home']);
        },
        (error: any) => {
          console.error(error);
        }
      );
  }

  private getCountries(): void {
    this.httpProxy
      .getCountries()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (data: ListItem[]) => {
          this.countries = data;
        },
        (error: any) => {
          console.error(error);
        }
      );
  }

  private getProvinces(countryId: number): void {
    this.httpProxy
      .getProvinces(countryId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (data: ListItem[]) => {
          this.provinces = data;
        },
        (error: any) => {
          console.error(error);
        }
      );
  }
}
