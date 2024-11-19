import React, { createContext, ReactNode, useEffect, useState } from "react";
import { ITaskCategory } from "../Models/TaskCategory";
import IocHelper from "../Helpers/Ioc/IocHelper";


  interface ApiProviderProps {
    children: ReactNode;
  }

const GlobalDropDownContext= createContext<IGlobalDropDownContextType | undefined>(undefined);

const GlobalDropDownContextProvider: React.FC<ApiProviderProps> = ({ children }) => {
    const [categoriesData, setCategoriesData] = useState<ITaskCategory[]|null>(null);   
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const iocHelper=new IocHelper();
    const taskCategoryRepository=iocHelper.getTaskCategoryRepository();


    useEffect(() => {
        const fetchTaskCategiryData = async () => {
          try {
            setLoading(true);          
           const categories= await taskCategoryRepository.getAllTaskCategory();
           setCategoriesData(categories);
    
             } catch (err) {
            setError('Failed to fetch data');
          } finally {
            setLoading(false);
          }
        };
    
        fetchTaskCategiryData();
      }, []);
      return(
        <GlobalDropDownContext.Provider value={{categoriesData,loading,error}}>
        {children}
        </GlobalDropDownContext.Provider>)
}
export {GlobalDropDownContext,GlobalDropDownContextProvider};

