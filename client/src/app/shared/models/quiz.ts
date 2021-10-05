import { IQuestion } from "./question";

export interface IQuiz {
  id: number;
  name: string;
  numberOfQuestions: number;
  category: string;
  status: string;
  createdAt: Date;
  startDate?: Date;
  createdBy: string;
}

export interface IQuizDetails extends IQuiz {
  questions: IQuestion[];
}


