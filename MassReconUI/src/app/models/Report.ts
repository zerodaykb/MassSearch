export interface Report {
  searchPhrase: string;
  notes: string;
  status: string;
  quantity: number;
  title: string;
  reportItems: [];
  id: number | null;
}
