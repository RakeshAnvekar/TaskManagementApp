
import { ITaskItem } from "../../Models/TaskItem";
import { ITaskItemRepository } from "./ITaskItemRepository";

export default class TaskItemRepository implements ITaskItemRepository{
  async  deleteTaskItemById(taskItemId: number): Promise<number|null> {
        if(taskItemId == null || undefined) 
            throw new Error("Task Item Id canot be null");

        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error("Token not found.");
        }
        const url=`https://localhost:7296/api/TaskManagement/DeleteTask?taskItemId=${taskItemId}`;
                try{
            const response=await fetch(url,
                {method:"Put",
                    headers: {
                        'Authorization': `Bearer ${token}`,
                           "Content-Type": "application/json"
                      }
                });

                if(!response.ok){
                    console.error(`Error: ${response.statusText}`);
                return null;
                }
                const result:number=await response.json();
                return result;
        }catch(error){
            console.error(`Error: ${error}`);
            return null;
        }
    };

   async  createNewTaskItem(taskItem: ITaskItem): Promise<ITaskItem | null> {
        if(taskItem == null)
        throw new Error("Task item canot be null");

        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error("Token not found.");
        }
        const url="https://localhost:7296/api/TaskManagement/CreateNewTaskItem";

        try{
            const response= await fetch(url,{
                method:"POST",
                headers: {
                    'Authorization': `Bearer ${token}`,
                       "Content-Type": "application/json"
                  }
                ,body:JSON.stringify(taskItem)
            });
    
            if(!response.ok){
                console.error(`Error: ${response.statusText}`);
                return null;
            }
            const result:ITaskItem=await response.json();
            return result;
        }catch(ex){
            console.error(`Error: ${ex}`);
            return null;
        }
       
    }

async getAllTaskAsync(): Promise<ITaskItem[] | null> {
    const url = "https://localhost:7296/api/TaskManagement/GetAllTasks";
   
    const token = localStorage.getItem('token');
    if (!token) {
        throw new Error("Token not found.");
    }
    try {
         const response = await fetch(url, {
            method: "GET", 
            headers: {
                'Authorization': `Bearer ${token}`,
                   "Content-Type": "application/json"
              }
        });

        if (!response.ok) {
            console.error(`Error: ${response.statusText}`);
            return null;
        }

        const result: ITaskItem[] = await response.json();
        return result;
    } catch (error) {
         console.error("Error fetching tasks:", error);
        return null;
    }
}
async getTaskDetailsById(taskId:number):Promise<ITaskItem|null>{
    try{
        const url=`https://localhost:7296/api/TaskManagement/GetTaskDetails?taskItemId=${taskId}`
       
        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error("Token not found.");
        }
        const response= await fetch(url,{
            method:"GET",
            headers: {
                'Authorization': `Bearer ${token}`,
                   "Content-Type": "application/json"
              }   
        });

        if (!response.ok) {
            console.error(`Error: ${response.statusText}`);
            return null;
        }
       const result:ITaskItem=await response.json();
       return result;

    }catch(error){
        console.error(`Error fetching tasks by task id ${taskId}:`, error);
        return null;

    }
}


}