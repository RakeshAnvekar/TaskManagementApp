interface IRepositoryHelper{
    readonly sendData:(
        url:string,body:string|undefined|null,
        method:"DELETE" | "GET" |"POST"|"PUT"
    )=>Promise<any>
}