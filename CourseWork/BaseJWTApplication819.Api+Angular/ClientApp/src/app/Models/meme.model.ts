export class Meme {
  public id: number;
  public date: string;
  public image: string;
  public rating: number;

  constructor(Id: number, Date: string, Image: string, Rating: number) {
    this.id = Id
    this.date = Date
    this.image = Image
    this.rating = Rating
  }
}