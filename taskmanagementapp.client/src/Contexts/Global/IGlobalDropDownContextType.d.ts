interface IGlobalDropDownContextType {
    categoriesData: ITaskCategory[]|null; 
    prioritiesData:ITaskPriority[]|null;   
    loading: boolean;
    error: string | null;
  }