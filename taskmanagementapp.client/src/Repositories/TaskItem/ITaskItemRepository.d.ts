import { ITaskItem } from "../../Models/TaskItem";

 interface ITaskItemRepository{
   getAllTaskAsync():Promise<ITaskItem []| null>;
   getTaskDetailsById(taskId:number):Promise<ITaskItem|null>;
   createNewTaskItem(taskItem:TaskItem):Promise<ITaskItem|null>;
   deleteTaskItemById(taskItemId :number):Promise<number|null>;
}