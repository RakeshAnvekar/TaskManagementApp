import { TokenHelper } from "../Token/TokenHelper";

export default class GlobalHeader implements IGlobalHeader{
  async  getGlobalHeadersWithToken(): Promise<Headers> {

        var tokenHelper=new TokenHelper();
        const token = await tokenHelper.getToken();
        var header=new Headers();
        
        if(token){
            header.set('Authorization', `Bearer ${token}`);
            header.set('Content-Type', "application/json");
        }
        return header;        
    }
    
}