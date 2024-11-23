import { IUserRegistration } from "../../Models/IUserRegistration";

public interface IUserRegistrationRepository{

    register(userRegistration:IUserRegistration):Promise<IUserRegistration|null>
}