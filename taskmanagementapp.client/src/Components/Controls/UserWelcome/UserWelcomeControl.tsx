import React, { useEffect, useState } from "react";

const UserWelcomeControl:React.FC=()=>{

    const [userDisplayName,setUserDisplayName]=useState<string|null>("");

    useEffect(()=>{
    var userName= localStorage.getItem("userDisplayName");
    setUserDisplayName(userName);
    },[])
    return <>
    <span>Welcome <b>{userDisplayName}</b> !</span>
    </>
}
export default UserWelcomeControl;