import React, { createContext, ReactNode, useEffect, useState } from "react";
import { ITaskCategory } from "../Models/TaskCategory";
import IocHelper from "../Helpers/Ioc/IocHelper";


  interface ApiProviderProps {
    children: ReactNode;
  }

const GlobalDropDownContext= createContext<IGlobalDropDownContextType | undefined>(undefined);

const GlobalDropDownContextProvider: React.FC<ApiProviderProps> = ({ children }) => {
    const [categoriesData, setCategoriesData] = useState<ITaskCategory[]|null>(null);   
   const[prioritiesData,setPrioritiesData]=useState<ITaskPriority[]|null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const iocHelper=new IocHelper();
    const taskCategoryRepository=iocHelper.getTaskCategoryRepository();
    const taskPriorityRepository= iocHelper.getTaskPriorityRepository();


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
        const fetchTaskPriorityData=async()=>{
          try{
            setLoading(true);
            const priorities=await taskPriorityRepository.getAllTaskPriorities();
            setPrioritiesData(priorities);
          }catch(error){
            setError('Failed to fetch data');

          }finally{
            setLoading(false);
          }
        }
    
        fetchTaskCategiryData();
        fetchTaskPriorityData();
      }, []);
      return(
        <GlobalDropDownContext.Provider value={{categoriesData,prioritiesData,loading,error}}>
        {children}
        </GlobalDropDownContext.Provider>)
}
export {GlobalDropDownContext,GlobalDropDownContextProvider};

