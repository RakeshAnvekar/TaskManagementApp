import { ITaskCategory } from "../../Models/TaskCategory";
import { ITaskCategoryRepository } from "./ITaskCategoryRepository";

export default  class TaskCategoryRepository implements ITaskCategoryRepository{

  async  getAllTaskCategory(): Promise<ITaskCategory[] | null> {
        const url=`https://localhost:7296/api/TaskCategory/GetAllTaskCategory`;

        try{
            const response= await fetch(url,{
                method:"GET",
                headers:{ "Content-Type": "application/json"}
                
            });

            if(!response.ok){
                console.error(`Error: ${response.statusText}`);            
                return null;
            }
            const result:ITaskCategory[]=await response.json();
            return result;

        }catch(error){
            console.error(`Error: ${error}`);
            return null;
        }
       
    }
    
}