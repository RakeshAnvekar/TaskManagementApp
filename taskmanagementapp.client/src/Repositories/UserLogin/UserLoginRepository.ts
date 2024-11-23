export default class UserLoginRepository implements IUserLoginRepository{
   async login(userlogin: IUserLogin): Promise<IUserLogin | null> {

    const url=`https://localhost:7296/api/User/Login`;

    try{
        const response= await fetch(url,{
            method:"POST",
            headers:{
                "Content-Type": "application/json"
            },body:JSON.stringify(userlogin),
        });

        if(!response.ok){
            console.error(`Error: ${response.statusText}`);   
            return null;
        }
        const result:IUserLogin=await response.json();
        return result;

    }catch(error){
        console.error(`Error: ${error}`); 
    return null;
    }
}

}