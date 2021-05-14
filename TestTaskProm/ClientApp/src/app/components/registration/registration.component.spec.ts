import { NO_ERRORS_SCHEMA } from "@angular/core";
import { RegistrationComponent } from "./registration.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("RegistrationComponent", () => {

  let fixture: ComponentFixture<RegistrationComponent>;
  let component: RegistrationComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [RegistrationComponent]
    });

    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
