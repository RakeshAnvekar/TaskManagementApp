import { useEffect, useState } from "react";
import { ITaskItem } from "../../../Models/TaskItem";
import IocHelper from "../../../Helpers/Ioc/IocHelper";
import { Link, useNavigate} from "react-router-dom";
import  "../../Pages/TaskItems/TaskItemsPage.css"



const TaskItemsPage: React.FC = () => {
    const [tasks,setTasks]=useState<ITaskItem[]|null>([]);
    const iocHelper=new IocHelper();
    const itemTaskRepository= iocHelper.getTaskItemRepository();
    const navigate= useNavigate();
  
    useEffect(() => {
      const fetchTasks = async () => {   

          try {
               const fetchedTasks = await itemTaskRepository.getAllTaskAsync();
              if (fetchedTasks) {
                  setTasks(fetchedTasks); 
              } 
          } catch (err) {
              console.error("Error fetching tasks:", err);
          } 
      };

      fetchTasks();
  }, []);
   
  const handleCreateNewItem=async()=>{
    navigate("/createTask");
  }
    return (
        <div>
          <h3>Active Tasks</h3>
          {tasks?.length==0 &&<p>No Task item to show</p>}
          <ul className="styled-list">
            {tasks?.map((task: ITaskItem) => (
              <li key={task.taskId}>
                <Link to={`/details/${task.taskId}`}>{task.taskTitle}</Link>
              </li>
            ))}
          </ul>
          <p><button onClick={handleCreateNewItem} className="createNewItem__button">Create New</button></p>
        </div>

      );
};

export default TaskItemsPage;