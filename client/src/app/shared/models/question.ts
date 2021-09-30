import { IAnswer } from "./answer";

export interface IQuestion {
  id: number;
  text: string;
  imageUrl: string;
  order: number;
  quizId: number;
  answers: IAnswer[];
}
