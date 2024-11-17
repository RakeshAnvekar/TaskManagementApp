export interface ITaskItem{
    taskId?:number|null|undefined;
    taskTitle:string;    
    taskDescription:string;
    category?:null|undefined|string;
    priority?:null|undefined|string;
    isCompleted:boolean;
    deadline:date;
    taskPriorityId:number;
    taskCategoryId:number;
    isActive:boolean;

}

