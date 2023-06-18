export interface CreateCar{
    ownerName: string;
    numberPlate: string;
    engineCapacity: number;
    typeOfColor: string;
    horsepower: number;
    makeId: number;
    modelId: number;
    images: Array<File>;
}