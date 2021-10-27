
interface IAnswerBase {
  text: string;
  correct:boolean;
  order: number;
}

export interface IAnswer extends IAnswerBase {
  id: number;
  questionId: number;
}

export interface IAnswerToUpdate extends IAnswerBase {
  id: number;
}

export interface IAnswerToCreate extends IAnswerBase {
}

