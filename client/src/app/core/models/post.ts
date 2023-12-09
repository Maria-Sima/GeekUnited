export interface IPost {
  id: string;
  text: string;
  description: string;
  pictureUrl: string;
  board: string;
  author: string;
  parentId: string;
  children: string[];
  createdAt: Date;
}
