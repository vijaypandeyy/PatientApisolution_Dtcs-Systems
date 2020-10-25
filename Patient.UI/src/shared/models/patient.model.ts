export class Patient {
    public Name: string;
    public SurName: string;
    public DOB: Date;
    public Gender: string;
    public cityId: number;
    public id: number;
    public city: string;
    public state: String;

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}

export interface SimpleObject {
    Id: number,
    Name: string,

}
