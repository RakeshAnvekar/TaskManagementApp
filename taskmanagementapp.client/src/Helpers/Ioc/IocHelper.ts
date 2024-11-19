import { ITaskCategoryRepository } from "../../Repositories/TaskCategory/ITaskCategoryRepository";
import TaskCategoryRepository from "../../Repositories/TaskCategory/TaskCategoryRepository";
import { ITaskItemRepository } from "../../Repositories/TaskItem/ITaskItemRepository";
import TaskItemRepository from "../../Repositories/TaskItem/TaskItemRepository";

export default class IocHelper{
    private static taskItemRepository:ITaskItemRepository | null = null;
    private static taskCategoryRepository:ITaskCategoryRepository|null=null
;
    public readonly getTaskItemRepository=():ITaskItemRepository=>{
        if(IocHelper.taskItemRepository!==null)
            return IocHelper.taskItemRepository;

        IocHelper.taskItemRepository=new TaskItemRepository();
        return IocHelper.taskItemRepository;
    }
    public readonly getTaskCategoryRepository=():ITaskCategoryRepository=>{
        if(IocHelper.taskCategoryRepository!==null)
            return IocHelper.taskCategoryRepository;

        IocHelper.taskCategoryRepository=new TaskCategoryRepository();
        return IocHelper.taskCategoryRepository;
    }

}