import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IPropertyBase } from 'src/app/model/IPropertyBase.Interface';
import { ICity } from 'src/app/model/ICity.Interface';
import { Property } from 'src/app/model/Property';
import { HousingService } from 'src/app/services/housing.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { IKeyValuePair } from 'src/app/model/IKeyValuePair';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})

export class AddPropertyComponent implements OnInit {
  @ViewChild('formTabs') formTabs: TabsetComponent;
  addPropertyForm: FormGroup;
  nextClicked: boolean;
  property = new Property();

  propertyView : IPropertyBase = {
    id: 0,
    sellRent: 0,
    name: '',
    propertyType: '',
    furnishingType: '',
    bhk: 0,
    buildArea: 0,
    city: '',
    readyToMove: false,
    price: 0,
    estPossessionOn: ''
  };

  propertyTypes: IKeyValuePair[];
  furnishTypes: IKeyValuePair[];
  moveTypes: Array<string> = ['East', 'West', 'South', 'North'];
  cityList: Array<ICity>;

  constructor(
    private datePipe: DatePipe,
    private fb: FormBuilder,
    private router: Router,
    private housingService: HousingService,
    private alertify: AlertifyService) { }

  ngOnInit() {
    if (!localStorage.getItem('username')) {
      this.alertify.onError('You must be logged in to add a property');
      this.router.navigate(['/user-login']);
    }

    this.CreateAddPropertyForm();
    this.housingService.getAllCities().subscribe(data => {
      this.cityList = data;
    });

    this.housingService.getPropertyTypes().subscribe(data => {
      this.propertyTypes = data;
    });

    this.housingService.getFurnishingTypes().subscribe(data => {
      this.furnishTypes = data;
    });
  }

  CreateAddPropertyForm() {
    this.addPropertyForm = this.fb.group({
      BasicInfo: this.fb.group({
        SellRent: ['1', Validators.required],
        BHK: [null, Validators.required],
        PType: [null, Validators.required],
        FType: [null, Validators.required],
        Name: [null, Validators.required],
        City: [null, Validators.required]
      }),
      PriceInfo: this.fb.group({
        Price: [null, Validators.required],
        BuildArea: [null, Validators.required],
        CarpetArea: [0],
        Security: [0],
        Maintenance: [0]
      }),
      AddressInfo: this.fb.group({
        FloorNo: [0],
        TotalFloor: [0],
        Address: [null, Validators.required],
        LandMark: [null]
      }),
      OtherInfo: this.fb.group({
        ReadyToMove: [null, Validators.required],
        PossessionOn: [null, Validators.required],
        AOP: [null],
        Gated: [null],
        MainEntrance: [null],
        Description: [null]
      })
    });
  }

  //#region <BasicInfo>
  get BasicInfo(){
    return this.addPropertyForm.controls.BasicInfo as FormGroup;
  }

  get SellRent() {
    return this.BasicInfo.controls.SellRent as FormControl;
  }

  get BHK() {
    return this.BasicInfo.controls.BHK as FormControl;
  }

  get PType() {
    return this.BasicInfo.controls.PType as FormControl;
  }

  get FType() {
    return this.BasicInfo.controls.FType as FormControl;
  }

  get Name() {
    return this.BasicInfo.controls.Name as FormControl;
  }

  get City() {
    return this.BasicInfo.controls.City as FormControl;
  }
  //#endregion

  //#region <PriceInfo>
  get PriceInfo() {
    return this.addPropertyForm.controls.PriceInfo as FormGroup;
  }

  get Price() {
    return this.PriceInfo.controls.Price as FormControl;
  }

  get BuildArea() {
    return this.PriceInfo.controls.BuildArea as FormControl;
  }

  get CarpetArea() {
    return this.PriceInfo.controls.CarpetArea as FormControl;
  }

  get Security() {
    return this.PriceInfo.controls.Security as FormControl;
  }

  get Maintenance() {
    return this.PriceInfo.controls.Maintenance as FormControl;
  }
  //#endregion

  //#region <AddressInfo>
  get AddressInfo() {
    return this.addPropertyForm.controls.AddressInfo as FormGroup;
  }

  get FloorNo() {
    return this.AddressInfo.controls.FloorNo as FormControl;
  }

  get TotalFloor() {
    return this.AddressInfo.controls.TotalFloor as FormControl;
  }

  get Address() {
    return this.AddressInfo.controls.Address as FormControl;
  }

  get LandMark() {
    return this.AddressInfo.controls.LandMark as FormControl;
  }
  //#endregion

  //#region <OtherInfo>
  get OtherInfo() {
    return this.addPropertyForm.controls.OtherInfo as FormGroup;
  }

  get RTM() {
    return this.OtherInfo.controls.ReadyToMove as FormControl;
  }

  get PossessionOn() {
    return this.OtherInfo.controls.PossessionOn as FormControl;
  }

  get AOP() {
    return this.OtherInfo.controls.AOP as FormControl;
  }

  get Gated() {
    return this.OtherInfo.controls.Gated as FormControl;
  }

  get MainEntrance() {
    return this.OtherInfo.controls.MainEntrance as FormControl;
  }

  get Description() {
    return this.OtherInfo.controls.Description as FormControl;
  }
  //#endregion

  onBack(){
    this.router.navigate(['/']);
  }

  onSubmit() {
    this.nextClicked = true;
    if (this.allTabsValid()) {
      this.mapProperty();
      this.housingService.addProperty(this.property).subscribe(
        () => {
          this.alertify.onSuccess('Congratulations, your property has been successfully added to our site.');
          console.log(this.addPropertyForm);

          if (this.SellRent.value === '2') {
            this.router.navigate(['/rent-property']);
          } else {
            this.onBack();
          }
        }
      );
    }
    else {
      this.alertify.onError('Please review the form and provide all valid entries.');
    }
  }

  mapProperty(): void {
    this.property.id = this.housingService.newPropID();
    this.property.sellRent = +this.SellRent.value;
    this.property.bhk = this.BHK.value;
    this.property.propertyTypeId = this.PType.value;
    this.property.name = this.Name.value;
    this.property.cityId = this.City.value;
    this.property.furnishingTypeId = this.FType.value;
    this.property.price = this.Price.value;
    this.property.security = this.Security.value;
    this.property.maintenance = this.Maintenance.value;
    this.property.buildArea = this.BuildArea.value;
    this.property.carpetArea = this.CarpetArea.value;
    this.property.floorNo = this.FloorNo.value;
    this.property.totalFloor = this.TotalFloor.value;
    this.property.address = this.Address.value;
    this.property.address2 = this.LandMark.value;
    this.property.mainEntrance = this.MainEntrance.value;
    this.property.description = this.Description.value;
    this.property.estPossessionOn =
    this.datePipe.transform(this.PossessionOn.value, 'yyyy-MM-dd') || new Date().toDateString();
    this.property.readyToMove = this.getBooleanValue(this.RTM.value);
    this.property.gated = this.getBooleanValue(this.Gated.value);
}

  getBooleanValue(value: string) : boolean {
    if (value === 'true') {
      return true;
    } else {
      return false;
    }
  }
  allTabsValid() : boolean {
    if (this.BasicInfo.invalid) {
      this.formTabs.tabs[0].active = true;
      return false;
    }
    if (this.PriceInfo.invalid) {
      this.formTabs.tabs[1].active = true;
      return false;
    }
    if (this.AddressInfo.invalid) {
      this.formTabs.tabs[2].active = true;
      return false;
    }
    if (this.OtherInfo.invalid) {
      this.formTabs.tabs[3].active = true;
      return false;
    }
    return true;
  }

  selectTab(tabId: number, isCurrentTabValid: boolean) {
    this.nextClicked = true;
    if (isCurrentTabValid) {
      this.formTabs.tabs[tabId].active = true;
    }
  }

  convertToDate(value: string) : Date {
    if (value) return new Date(value);
    return new Date();
  }
}
