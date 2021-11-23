import { IAnswer, IAnswerToCreate, IAnswerToUpdate } from "./answer";

interface IQuestionBase {
  text: string;
  order: number;
}

export interface IQuestion extends IQuestionBase {
  id: number;
  imageUrl?: string;
  answers: IAnswer[]
  quizId: number;
}

export interface IQuestionToUpdate extends IQuestionBase {
  id: number;
  answers: IAnswerToUpdate[];
}

export interface IQuestionToCreate extends IQuestionBase {
  quizId: number;
  imageFile?: {image: string, extension: string};
  answers: IAnswerToCreate[];
}
