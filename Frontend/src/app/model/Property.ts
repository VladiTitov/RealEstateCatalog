import { IPropertyBase } from "./IPropertyBase.Interface";

export class Property implements IPropertyBase {
  id: number;
  sellRent: number;
  name: string;
  propertyTypeId: number;
  propertyType: string;
  bhk: number;
  furnishingTypeId: number;
  furnishingType: string;
  price: number;
  buildArea: number;
  carpetArea?: string;
  address: string;
  address2?: string;
  cityId: number;
  city: string;
  floorNo?: string;
  totalFloor?: string;
  readyToMove: boolean;
  age?: string;
  mainEntrance?: string;
  security?: number;
  gated?: number;
  maintenance?: number;
  estPossessionOn: string;
  image?: string;
  description?: string;
}
