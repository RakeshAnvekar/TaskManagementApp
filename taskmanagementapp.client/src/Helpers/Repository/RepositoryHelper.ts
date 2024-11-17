export default class RepositoryHelper implements IRepositoryHelper{
   public readonly sendData= async(url: string, 
    body: string | undefined | null, 
    method: "DELETE" | "GET" | "POST" | "PUT") :Promise<any>=>{
        fetch(url,{
            body,
            headers:{
                Accept:"application/json",
                "Content-Type":"application/json",
            },
            method,
        });
    }
 
}