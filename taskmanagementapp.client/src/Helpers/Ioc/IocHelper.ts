import { ITaskCategoryRepository } from "../../Repositories/TaskCategory/ITaskCategoryRepository";
import TaskCategoryRepository from "../../Repositories/TaskCategory/TaskCategoryRepository";
import { ITaskItemRepository } from "../../Repositories/TaskItem/ITaskItemRepository";
import TaskItemRepository from "../../Repositories/TaskItem/TaskItemRepository";
import { ITaskPriorityRepository } from "../../Repositories/TaskPriority/ITaskPriorityRepository";
import TaskPriorityRepository from "../../Repositories/TaskPriority/TaskPriorityRepository";
import UserLoginRepository from "../../Repositories/UserLogin/UserLoginRepository";
import { IUserRegistrationRepository } from "../../Repositories/UserRegistration/IUserRegistrationRepository";
import UserRegistrationRepository from "../../Repositories/UserRegistration/UserRegistrationRepository";

export default class IocHelper{
    private static taskItemRepository:ITaskItemRepository | null = null;
    private static taskCategoryRepository:ITaskCategoryRepository|null=null;
    private static taskPriorityRepository:ITaskPriorityRepository|null=null;
    private static userRegistrationRepository:IUserRegistrationRepository|null=null;
    private static userLoginRepository:IUserLoginRepository|null=null;



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
    public readonly getTaskPriorityRepository=():ITaskPriorityRepository=>{
        if(IocHelper.taskPriorityRepository!==null)  return IocHelper.taskPriorityRepository;
        IocHelper.taskPriorityRepository= new TaskPriorityRepository();
        return IocHelper.taskPriorityRepository;
    }

    public readonly getUserRegistrationRepository=():IUserRegistrationRepository=>{
        if(IocHelper.userRegistrationRepository!=null) return IocHelper.userRegistrationRepository;

        IocHelper.userRegistrationRepository=new UserRegistrationRepository()
        return IocHelper.userRegistrationRepository;
    }
    public readonly getUserLoginRepository=():IUserLoginRepository=>{
        if(IocHelper.userLoginRepository!=null) return IocHelper.userLoginRepository;

        IocHelper.userLoginRepository=new UserLoginRepository();
        return IocHelper.userLoginRepository;
    }

}