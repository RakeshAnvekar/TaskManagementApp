import React, { useContext, useState } from "react";
import "../TaskItemCreate/TaskItemCreate.css";
import 'react-calendar/dist/Calendar.css';
import IocHelper from "../../../Helpers/Ioc/IocHelper";
import { ITaskItem } from "../../../Models/TaskItem";
import { useNavigate } from "react-router-dom";
import backButtonIcon from "../../../assets/Icons/backButtonIcon.jpg";
import { GlobalDropDownContext } from "../../../Contexts/Global/GlobalDropDownContext";

const TaskItemCreatePage: React.FC = () => {
  const [taskTitle,setTaskTitle]=useState('');
  const [taskDesctiption,setTaskDescription]=useState('');
  const [taskCategory,setTaskCategory]=useState<number>(0);
  const [taskPriority,setTaskPriority]=useState<number>(0);
  const [activeTaskItem]=useState(true);
  const [taskDeadline,setTaskDeadline] = useState<any>(null);
  const navigate =useNavigate();

  const iocHelper=new IocHelper();
  const taskRepository=iocHelper.getTaskItemRepository();  
  const context = useContext(GlobalDropDownContext);  
  const handleResetTaskItem=async()=>{
  setTaskTitle('');
  setTaskDescription('');
  setTaskCategory(0);
  setTaskPriority(0);
  setTaskDeadline('');
}
const handleCreateTaskItem=async()=>{
const newTaskItemResult:ITaskItem={  
  taskTitle: taskTitle,
  taskDescription: taskDesctiption,  
  isCompleted: false,
  deadline: taskDeadline,
  taskPriorityId: taskPriority,
  taskCategoryId: taskCategory,
  isActive: true
};


 const result= await taskRepository.createNewTaskItem(newTaskItemResult);
 if(result){
alert("Item Saved Scuessfully");
handleResetTaskItem();
navigate("/")
 }
}
const handleBackButtonClick=async()=>{
  navigate("/")
}
 return <>

  <div className="createTaskItem__outer_container">
    
    <br/>
    <br/>
        <span><img src={backButtonIcon} className="backButtonIcon" alt="go to main Page" onClick={handleBackButtonClick} ></img></span><h2>Create New Task Item</h2>
      <div>
      <div className="createTaskItem__inner_container">
        <span>Task Title</span><input type="text" required className="createTaskItem__Input" id="taskTitle" name="taskTitle" value={taskTitle} onChange={(e)=>setTaskTitle(e.target.value)}></input>
          <br/>
          <br/>
          <span>Category</span>
          <select id="taskCategory" name="taskCategory" className="createTaskItem__Input" value={taskCategory} onChange={(e)=>setTaskCategory(Number(e.target.value))}>
          {context?.categoriesData?.map(category=>
            <option value={category?.taskCategoryId}>{category?.category}</option>
          )};
          </select>          
          <br/>
          <br/>
          <span>Priority</span>
          <select id="taskPriority" name="taskPriority" className="createTaskItem__Input" value={taskPriority} onChange={(e)=>setTaskPriority(Number(e.target.value))}>
          {context?.prioritiesData?.map(priority=>
            <option value={priority.taskPriorityId}>{priority.priority}</option>
           )}; 
           </select>
          <br/>
          <br/>
          <span>Description</span><textarea  id="taskDescription" name="taskDescription" required className="createTaskItem__Input-textarea" value={taskDesctiption} onChange={(e)=>setTaskDescription(e.target.value)}></textarea >
       <br/><br/>
       <span>Active</span><input 
            type="checkbox" className="calenderIcon"
            checked={activeTaskItem}            
          />
          <br/>
          <br/>
          <span>Deadline</span>
          <input type="date" min={Date.now()} id="taskDeadline" name="taskDeadline" value={taskDeadline} onChange={(e)=>setTaskDeadline(e.target.value)} className="createTaskItem__Input"></input>
      <br/>
      <br/>
       <span><button className="button" onClick={handleCreateTaskItem}>Create</button><button className="button" onClick={handleResetTaskItem}>Reset</button></span>
       </div> 
      </div>            
  </div>
           </>
}
export default TaskItemCreatePage;