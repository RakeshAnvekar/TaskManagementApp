import { useEffect, useState } from "react";
import IocHelper from "../../../Helpers/Ioc/IocHelper";
import { useNavigate, useParams } from "react-router-dom";
import "../TaskItemDetailsCard/TaskItemDetailsCard.css"
import { ITaskItem } from "../../../Models/TaskItem";
import backButtonIcon from "../../../assets/Icons/backButtonIcon.jpg";
import UserWelcomeControl from "../../Controls/UserWelcome/UserWelcomeControl";

const TaskItemDetailsCard = () => {
    const [taskItemDetails, setTaskItemDetails] = useState<ITaskItem | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null); 
    const iocHelper = new IocHelper();
    const taskItemRepository = iocHelper.getTaskItemRepository();
    const { taskId } = useParams(); 
    const taskItemId = Number(taskId); 
    const navigate = useNavigate();
  
    useEffect(() => {
      const getTaskItemDetailsById = async () => {
        setLoading(true);
        setError(null); 
        try {
          const itemDetails = await taskItemRepository.getTaskDetailsById(taskItemId);
          setTaskItemDetails(itemDetails);
        } catch (err) {
          setError('Failed to fetch task details.'+err); 
        } finally {
          setLoading(false); 
        }
      };
  
      if (taskItemId) {
        getTaskItemDetailsById();
      }
    }, [taskItemId]);
    const handleCreateNewTaskItem=()=>{
      navigate("/createTask")
    }
    const handleOnMarkAsDone=async()=>{
      confirm(`Are you sure you want to mark Task  ${taskItemDetails?.taskTitle} as done?`);
   const result= await taskItemRepository.deleteTaskItemById(taskItemId);
   if(result){
    alert(`${taskItemDetails?.taskTitle}  Task Deleted Sucessfully`);
    navigate("/")
   }
   else{
    alert(`Sorry,Problem deleting the task item.`);
   }
    }
    const handleBackButtonClick=async()=>{
      navigate("/")
    }

    if (loading) {
      return <div>Loading...</div>;
    }
  
    
    if (error) {
      return <div>{error}</div>;
    }
  
    // Render task details
    return (
      <>
      <UserWelcomeControl/>
      <p><button onClick={handleCreateNewTaskItem}>Create New Task Item</button></p>
      <span><img src={backButtonIcon} className="backButtonIcon" alt="go to main Page" onClick={handleBackButtonClick}></img></span>
        {taskItemDetails ? (
          <div>
           <h2 className="cardTitle">{taskItemDetails.taskTitle}</h2>           
            <div className="card">              
              <h1>{taskItemDetails.category}</h1>
              <p className="taskCompleted">{taskItemDetails.isCompleted ? 'Completed' : 'Not Completed'}</p>
              <p>{taskItemDetails.taskDescription}</p>
              <p>{taskItemDetails.deadline}</p>
              <p><button onClick={handleOnMarkAsDone}>Mask As Done.</button></p>
            </div>            
          </div>
        ) : (
          <div>Task details not found.</div> // In case no details were found
        )}
      </>
    );
  };
  
  export default TaskItemDetailsCard;