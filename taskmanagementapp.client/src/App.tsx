import { BrowserRouter , Route, Routes } from 'react-router-dom';
import './App.css'
import TaskItemsPage from './Components/Pages/TaskItems/TaskItemsPage'
import TaskItemDetailsCard from './Components/Pages/TaskItemDetailsCard/TaskItemDetailsCard'
import TaskItemCreatePage from './Components/Pages/TaskItemCreate/TaskItemCreatePage';
import { GlobalDropDownContextProvider } from './Contexts/GlobalDropDownContext';
import UserRegistrationPage from './Components/Pages/UserRegistration/UserRegistrationPage';




function App() {

  return (
  <GlobalDropDownContextProvider>
    <BrowserRouter>
        <Routes>
          <Route path='/' element={<TaskItemsPage/>}/>
          <Route path='/details/:taskId' element={<TaskItemDetailsCard/>}/> 
          <Route path='/createTask' element={<TaskItemCreatePage/>} />
          <Route path='/userRegistration' element={<UserRegistrationPage/>} />   
        </Routes>    
      </BrowserRouter>
  </GlobalDropDownContextProvider>
   
  )
}

export default App
