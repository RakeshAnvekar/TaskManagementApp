import { ITaskPriorityRepository } from "./ITaskPriorityRepository";

export default class TaskPriorityRepository implements ITaskPriorityRepository{
  async  getAllTaskPriorities(): Promise<ITaskPriority[] | null> {
        const url=`https://localhost:7296/api/TaskPriority/GetAllTakPriorities`;
        
        try{
            const response =await fetch(url,{
                method:"GET",
                headers:{
                     "Content-Type": "application/json"
                },
            });
            if(!response.ok){
                console.error(`Error: ${response.statusText}`);            
                return null;
            }
    
            const result :ITaskPriority[]=await response.json();
            return result;
        }catch(error){
            console.error(`Error: ${error}`);
            return null;
        }
    }
        
    
    }
    
