import { ITaskCategory } from "../../Models/TaskCategory";

public interface ITaskPriorityRepository{

    getAllTaskPriorities():Promise<ITaskPriority[]|null>
}