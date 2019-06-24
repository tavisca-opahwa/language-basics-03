using System;
using System.Linq;

using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int[] ans=new int[dietPlans.Length];
            int[] calories=new int[protein.Length];
            for(int i=0;i<fat.Length;i++)
                calories[i]=5*protein[i]+5*carbs[i]+9*fat[i];
               
            for(int i=0;i<dietPlans.Length;i++)
            {
                String diet=dietPlans[i];
                if(diet.Length==0)
                continue;
                 List <int> FinalList=new List<int>();
                List<int>TempList=new List<int>();
                for(int j=0;j<diet.Length;j++)
                {
                    switch(diet[j])
                    {
                    case 'P':
                        TempList=getMax(FinalList,protein);
                        break;
                   case 'F':
                        TempList=getMax(FinalList,fat);
                        break;
                    case 'C':
                        TempList=getMax(FinalList,carbs);
                        break;
                    case 'T':
                        TempList=getMax(FinalList,calories);
                        break;
                    case 'f':
                        TempList=getMin(FinalList,fat);
                        break;
                     case 'c':
                        TempList=getMin(FinalList,carbs);
                        break;
                     case 'p':
                        TempList=getMin(FinalList,protein);
                        break;
                     case 't':
                        TempList=getMin(FinalList,calories);
                        break;
                     default:
                        Console.Write("valid case doesnot exist");
                        break;
                    }
                   
                    if(FinalList.Count==0)
                    {
                        FinalList=TempList;
                    }
                    else
                    {
                        FinalList=FinalList.Intersect(TempList).ToList();
                    }
                    
                }
                int min=Int32.MaxValue;
                foreach(var x in FinalList)
                {
                    min=Math.Min(min,x);
                }
                ans[i]=min;
            }
            
            return ans;
        }
        public static List<int> getMax(List <int> FinalList,int[] array)
        {
            int max=Int32.MinValue;
            int index=0;
            List<int> TempList=new List<int>();
            for(int i=0;i<array.Length;i++)
            {
               if(array[i]>max)
               {
                   if(FinalList.Count==0)
                    {
                        max=array[i];
                        index=i;
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           max=array[i];
                        index=i;
                       }

                   }
               }
               
            }
            TempList.Add(index);
            for(int i=0;i<array.Length;i++)
            {
                if(max==array[i] && i!=index)
                {
                    if(FinalList.Count==0)
                    {
                        TempList.Add(i);
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           TempList.Add(i);
                       }

                   }
                }
            }
            
            return TempList;
        }
         public static List<int> getMin(List <int> FinalList,int[] array)
        {
            int min=Int32.MaxValue;
            int index=0;
            List<int> TempList=new List<int>();
            for(int i=0;i<array.Length;i++)
            {
               if(array[i]<min)
               {
                   if(FinalList.Count==0)
                    {
                        min=array[i];
                        index=i;
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           min=array[i];
                           index=i;
                       }

                   }
               }
               
            }
            TempList.Add(index);
            for(int i=0;i<array.Length;i++)
            {
                if(min==array[i] && i!=index)
                {
                    if(FinalList.Count==0)
                    {
                        TempList.Add(i);
                    }
                   else{
                       if(FinalList.Contains(i)==true)
                       {
                           TempList.Add(i);
                       }

                   }
                }
            }
            
            return TempList;
        }
}
}
