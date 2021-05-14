import { NO_ERRORS_SCHEMA } from "@angular/core";
import { LoginInfoComponent } from "./login-info.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("LoginInfoComponent", () => {

  let fixture: ComponentFixture<LoginInfoComponent>;
  let component: LoginInfoComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [LoginInfoComponent]
    });

    fixture = TestBed.createComponent(LoginInfoComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
