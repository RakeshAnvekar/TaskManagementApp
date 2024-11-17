import { BrowserRouter , Route, Routes } from 'react-router-dom';
import './App.css'
import TaskItemsPage from './Components/Pages/TaskItems/TaskItemsPage'
import TaskItemDetailsCard from './Components/Pages/TaskItemDetailsCard/TaskItemDetailsCard'
import TaskItemCreatePage from './Components/Pages/TaskItemCreate/TaskItemCreatePage';

function App() {
  

  return (
   <BrowserRouter>
    <Routes>
      <Route path='/' element={<TaskItemsPage/>}/>
      <Route path='/details/:taskId' element={<TaskItemDetailsCard/>}/> 
      <Route path='/createTask' element={<TaskItemCreatePage/>} />   
    </Routes>
    
   </BrowserRouter>
  )
}

export default App
