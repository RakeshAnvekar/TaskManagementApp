import { Provider } from "react";
import { ITaskItem } from "../../Models/TaskItem";

 interface ITaskItemRepository{
  readonly  getAllTaskAsync():Promise<ITaskItem []| null>;
  readonly getTaskDetailsById(taskId:number):Promise<ITaskItem|null>;
  readonly createNewTaskItem(taskItem:TaskItem):Promise<ITaskItem|null>;
  readonly deleteTaskItemById(taskItemId :number):Promise<number|null>;
}