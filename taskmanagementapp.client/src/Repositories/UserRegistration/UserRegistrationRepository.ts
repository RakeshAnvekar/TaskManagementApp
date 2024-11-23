import { IUserRegistration } from "../../Models/IUserRegistration";
import { IUserRegistrationRepository } from "./IUserRegistrationRepository";


export default class UserRegistrationRepository implements IUserRegistrationRepository{
    async register(userRegistration: IUserRegistration): Promise<IUserRegistration | null> {
        const url=`https://localhost:7296/api/User/Register`;
        try{

            const response= await fetch(url,{
                method:"POST",
                headers:{
                    "Content-Type": "application/json"
               },
               body:JSON.stringify(userRegistration)
            });
            if(!response.ok){
                console.error(`Error: ${response.statusText}`);
                return null;
            }
            const result:IUserRegistration=await response.json();
            return result;
        }catch(error){
            console.error(`Error: ${error}`);
            return null;
        }
    }
   
    
    }
    
