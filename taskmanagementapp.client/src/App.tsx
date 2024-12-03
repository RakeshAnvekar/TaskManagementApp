import { BrowserRouter , Route, Routes } from 'react-router-dom';
import './App.css'
import TaskItemsPage from './Components/Pages/TaskItems/TaskItemsPage'
import TaskItemDetailsCard from './Components/Pages/TaskItemDetailsCard/TaskItemDetailsCard'
import TaskItemCreatePage from './Components/Pages/TaskItemCreate/TaskItemCreatePage';
import { GlobalDropDownContextProvider } from './Contexts/Global/GlobalDropDownContext';
import UserRegistrationPage from './Components/Pages/UserRegistration/UserRegistrationPage';
import UserLoginPage from './Components/Pages/UserLogin/UserLoginPage';
import { UserContextProvider } from './Contexts/User/UserContext';
import ProtectedRoute from './Routes/ProtectedRoutes/ProtectedRoute';
import UserUnAuthorizePage from './Components/Pages/UserUnAuthorize/UserUnAuthorizePage';




function App() {

  return (
    <UserContextProvider>
      <GlobalDropDownContextProvider>
        <BrowserRouter>
            <Routes>
              <Route path='/' element={<UserLoginPage/>}/>
              <Route path='/details/:taskId' element={<ProtectedRoute><TaskItemDetailsCard/></ProtectedRoute>}/> 
              <Route path='/createTask' element={<ProtectedRoute><TaskItemCreatePage/></ProtectedRoute>} />
              <Route path='/userRegistration' element={<ProtectedRoute><UserRegistrationPage/></ProtectedRoute>} />   
              <Route path='/userTasks' element={<ProtectedRoute><TaskItemsPage/></ProtectedRoute>} />  
              <Route path='/userUnAuthorized' element={<UserUnAuthorizePage></UserUnAuthorizePage>} />  
            </Routes>
          </BrowserRouter>
      </GlobalDropDownContextProvider>
  </UserContextProvider>
   
  )
}

export default App
