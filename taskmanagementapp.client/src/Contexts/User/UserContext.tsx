import { createContext, ReactNode, useState } from "react";

export const userContext=createContext<IUserContextType|undefined>(undefined);

interface ApiProviderProps {
    children: ReactNode;
  }



export  const UserContextProvider:React.FC<ApiProviderProps> = ({ children }) => {
    const [user, setUser] = useState<IUser | null>(null); // State to store user data

    const setUserData = (userData: IUser|null) => {
        setUser(userData); // Set the user data to the global state
      };

    return <userContext.Provider value={{ user, setUserData }}>
{children}
    </userContext.Provider>

}
export default {UserContextProvider,userContext}