import React, { useState } from "react";
import "../../../Components/Pages/UserRegistration/UserRegistrationPage.css"
import IocHelper from "../../../Helpers/Ioc/IocHelper";
import { IUserRegistration } from "../../../Models/IUserRegistration";
import { useNavigate } from "react-router-dom";

const  UserRegistrationPage:React.FC=()=>{
    const[userName,setUserName]=useState<string>("");
    const[emailId,setEmailId]=useState<string>("");
    const[password,setPassword]=useState<string>("");
    const[confirmPassword,setConfirmPassword]=useState<string>("");
    const iocHelper= new IocHelper();
    const userRegistrationRepository=iocHelper.getUserRegistrationRepository();
    const navigation=useNavigate();

    //for erros
    const [errors, setErrors] = useState({
        username: '',
        email: '',
        password: '',
        confirmPassword: ''
      });
      //
    const handleClickRegister=async()=>{
        let formErrors = {
            username: '',
            email: '',
            password: '',
            confirmPassword: ''
          };
          let isValid = true;

    // Username Validation
    if (userName.trim() === '') {
      formErrors.username = 'Username is required';
      isValid = false;
    }
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    if(!emailId){
        formErrors.email = 'Please enter a email';
        isValid = false;  
    }
    if (emailId && !emailRegex.test(emailId)) {
      formErrors.email = 'Please enter a valid email';
      isValid = false;
    }
    if (password.length < 6) {
        formErrors.password = 'Password must be at least 6 characters';
        isValid = false;
      }

      if (password !== confirmPassword) {
        formErrors.confirmPassword = 'Passwords do not match';
        isValid = false;
      }
      setErrors(formErrors);

       if(isValid){
        var user:IUserRegistration={
            userName: userName,
            userEmailId: emailId,
            userPassword: password,
            cserConfirmPassword: confirmPassword
        }
      var result= await userRegistrationRepository.register(user);
      if(result!=null){
        clearRegistrationFields();
        alert("Saved Sucessfully"); 
        navigation("/")       
      }
       }       
    }
    const clearRegistrationFields=()=>{
        setUserName("");
        setEmailId("");
        setPassword("");
        setConfirmPassword("");
    }
    const handleClickLogin=()=>{
      navigation("/")
    }
   
    return <>
    <h3>User Registration Page</h3>
    <div className="userRegistration__outer_container">
    <div className="userRegistration__inner_container"><br/>
    <br/>
    <span>User Name</span><input type="text" required className={"userRegistration__Input" +" "+ `${errors.username ? "errorBorder":""}`} id="userName" name="userName" value={userName} onChange={(e)=>setUserName(e.target.value)}></input>
    <br/>{errors.username?errors.username:""}
    <br/>
    <br/>
    <span>Email Id</span><input type="email" required className={"userRegistration__Input" +" "+ `${errors.email ? "errorBorder":""}`} id="emailId" name="emailId" value={emailId} onChange={(e)=>setEmailId(e.target.value)}></input>
    <br/>{errors.email?errors.email:""}
    <br/>
    <br/>
    <span>Password</span><input type="password" required className={"userRegistration__Input" +" "+ `${errors.password ? "errorBorder":""}`} id="password" name="password" value={password} onChange={(e)=>setPassword(e.target.value)}></input>
    <br/>{errors.password?errors.password:""}
    <br/>
    <br/>
    <span>Confirm Password</span><input type="password" required className={"userRegistration__Input" +" "+ `${errors.confirmPassword ? "errorBorder":""}`} id="confirmPassword" name="confirmPassword" value={confirmPassword} onChange={(e)=>setConfirmPassword(e.target.value)}></input>
    <br/>{errors.confirmPassword?errors.confirmPassword:""}
    <br/>
    <br/>
    <span><button className="button" onClick={handleClickRegister}>Register</button>
    <button className="button" onClick={handleClickLogin}>Login</button></span>    
      
    </div>      
</div></>
}
export default UserRegistrationPage;
    
