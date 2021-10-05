export interface IAnswer {
  id: number;
  text: string;
  correct:boolean;
  order: number;
  questionId: number;
}

export interface IAnswerToUpdate {
  id: number;
  text: string;
  correct: boolean;
  order: number;
}

