import { IAnswer } from "./answer";

export interface IQuestion {
  id: number;
  text: string;
  imageUrl: string;
  quizId: number;
  answers: IAnswer[];
}
