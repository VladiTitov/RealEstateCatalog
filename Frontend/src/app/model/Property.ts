import { IPropertyBase } from "./IPropertyBase.Interface";

export class Property implements IPropertyBase {
  Id: number;
  SellRent: number;
  Name: string;
  PType: string;
  BHK: number;
  FType: string;
  Price: number;
  BuildArea: number;
  CarpetArea?: string;
  Address: string;
  Address2?: string;
  City: string;
  FloorNo?: string;
  TotalFloor?: string;
  ReadyToMove: number;
  AOP?: string;
  MainEntrance?: string;
  Security?: number;
  Gated?: number;
  Maintenance?: number;
  Possession?: string;
  Image?: string;
  Description?: string;
  PostedOn: string;
  PostedBy: number;
}
