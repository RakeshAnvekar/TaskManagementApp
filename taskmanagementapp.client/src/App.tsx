import { BrowserRouter , Route, Routes } from 'react-router-dom';
import './App.css'
import TaskItemsPage from './Components/Pages/TaskItems/TaskItemsPage'
import TaskItemDetailsCard from './Components/Pages/TaskItemDetailsCard/TaskItemDetailsCard'
import TaskItemCreatePage from './Components/Pages/TaskItemCreate/TaskItemCreatePage';
import { GlobalDropDownContextProvider } from './Contexts/Global/GlobalDropDownContext';
import UserRegistrationPage from './Components/Pages/UserRegistration/UserRegistrationPage';
import UserLoginPage from './Components/Pages/UserLogin/UserLoginPage';
import { UserContextProvider } from './Contexts/User/UserContext';




function App() {

  return (
    <UserContextProvider>
      <GlobalDropDownContextProvider>
        <BrowserRouter>
            <Routes>
              <Route path='/' element={<UserLoginPage/>}/>
              <Route path='/details/:taskId' element={<TaskItemDetailsCard/>}/> 
              <Route path='/createTask' element={<TaskItemCreatePage/>} />
              <Route path='/userRegistration' element={<UserRegistrationPage/>} />   
              <Route path='/userTasks' element={<TaskItemsPage/>} />   
            </Routes>
          </BrowserRouter>
      </GlobalDropDownContextProvider>
  </UserContextProvider>
   
  )
}

export default App
