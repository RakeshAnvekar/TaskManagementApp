interface IUserLogin{
    userEmailId:string|null;
    userPassword:string|null;
    token?:string|null;
    user?:{userDisplayName:string|null}
}