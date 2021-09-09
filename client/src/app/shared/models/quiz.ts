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
