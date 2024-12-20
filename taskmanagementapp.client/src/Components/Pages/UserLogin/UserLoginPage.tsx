import React, { useState } from "react";
import IocHelper from "../../../Helpers/Ioc/IocHelper";
import { useNavigate } from "react-router-dom";
import "../../Pages/UserLogin/UserLoginPage.css"

const UserLoginPage:React.FC=()=>{

    const[userEmailId,setUserEmailId]=useState("");
    const[password,setPassword]=useState<string>("");
   
    const iocHelper=new IocHelper();
    const userLoginRepository=iocHelper.getUserLoginRepository();
    const navigation= useNavigate();

    const handleUserLogin=async()=>{
        var user:IUserLogin={
            userEmailId: userEmailId,
            userPassword: password
        }
    const result=await userLoginRepository.login(user);
    if(result && result.token && result.user){
        localStorage.setItem('token', result.token);
        localStorage.setItem('userDisplayName', result.user.userDisplayName ? result.user.userDisplayName:"");
        navigation("/userTasks")
    }
    else{
        navigation("/userUnAuthorized")
    }
    }
    const handleUserRegister=()=>{
        navigation("/userRegistration") 
    }
    return <>    
     <h3>User Login Page</h3>
        <div className="userLogin__outer_container">
            <div className="userLogin__inner_container"><br/>
            <span>Email Id:</span><input type="text" className="userLogin__Input" required value={userEmailId}  onChange={(e)=>setUserEmailId(e.target.value)}></input>
                <br/>
                <br/>
            <span>Password:</span><input type="password" required className="userLogin__Input" id="password" name="password" value={password} onChange={(e)=>setPassword(e.target.value)}></input>
            <b/>
            <br/>
            <span>
                <button className="button" onClick={handleUserLogin}>Login</button>
                <button className="button" onClick={handleUserRegister}>Register</button>
            </span>
                
            </div>
        </div>
    </>
};
export default UserLoginPage;