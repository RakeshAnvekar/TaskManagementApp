import React from "react";
import unauthorizedIcon from '../../../assets/Icons/unauthorized-access.png'
import { Link } from "react-router-dom";
import "../../Pages/UserUnAuthorize/UserUnAuthorizePage.css";
const UserUnAuthorizePage:React.FC=()=>{

    return <>
    <div >
        <img src={unauthorizedIcon} alt="unauthorized-access" className="userUnAuthorized_img"/>
        <br/>
        <br/>
        <p>You are not authorized to access this application. Please register or log in with valid credentials.</p>
       <Link to="/">Login</Link><br/>
       <Link to="/userRegistration">Register</Link>
    </div>
    </>
}
export default UserUnAuthorizePage;