import { ITaskItemRepository } from "../../Repositories/TaskItem/ITaskItemRepository";
import TaskItemRepository from "../../Repositories/TaskItem/TaskItemRepository";

export default class IocHelper{
    private static taskItemRepository:ITaskItemRepository | null = null;
;
    public readonly getTaskItemRepository=():ITaskItemRepository=>{
        if(IocHelper.taskItemRepository!==null)
            return IocHelper.taskItemRepository;

        IocHelper.taskItemRepository=new TaskItemRepository();
        return IocHelper.taskItemRepository;
    }

}