import { IAnswer, IAnswerToUpdate } from "./answer";

export interface IQuestion {
  id: number;
  text: string;
  imageUrl: string;
  order: number;
  quizId: number;
  answers: IAnswer[];
}

export interface IQuestionToUpdate {
  id: number;
  text: string;
  order: number;
  anwers: IAnswerToUpdate[];
}
