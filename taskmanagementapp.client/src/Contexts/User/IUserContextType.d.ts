interface IUserContextType{
    user:IUser|null;
    setUserData: (userData: IUser) => void;
}