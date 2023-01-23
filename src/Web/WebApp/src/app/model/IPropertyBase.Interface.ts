export interface IPropertyBase {
  id: number;
  sellRent: number;
  name: string;
  propertyType: string;
  furnishingType: string;
  price: number;
  bhk: number;
  buildArea: number;
  city: string;
  readyToMove: boolean;
  image?: string;
  estPossessionOn: string;
}
