import { ITaskItemRepository } from "../../Repositories/TaskItem/ITaskItemRepository";
import TaskItemRepository from "../../Repositories/TaskItem/TaskItemRepository";
import RepositoryHelper from "../Repository/RepositoryHelper";

export default class IocHelper{
    private static taskItemRepository:ITaskItemRepository | null = null;
    private static repositoryHelper:IRepositoryHelper|null=null;
;
    public readonly getRepositoryHelper=():IRepositoryHelper=>{
        if(IocHelper.repositoryHelper!==null) return IocHelper.repositoryHelper;

        IocHelper.repositoryHelper= new RepositoryHelper();
        return IocHelper.repositoryHelper;
    }

    public readonly getTaskItemRepository=():ITaskItemRepository=>{
        if(IocHelper.taskItemRepository!==null)
            return IocHelper.taskItemRepository;

        IocHelper.taskItemRepository=new TaskItemRepository();
        return IocHelper.taskItemRepository;
    }

}