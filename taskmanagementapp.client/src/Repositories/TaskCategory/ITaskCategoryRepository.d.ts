import { ITaskCategory } from "../../Models/TaskCategory";

public interface ITaskCategoryRepository{

    getAllTaskCategory():Promise<ITaskCategory[]|null>
}