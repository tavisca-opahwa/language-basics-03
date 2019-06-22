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
                 List <int> l=new List<int>();
                List<int>l1=new List<int>();
                for(int j=0;j<diet.Length;j++)
                {
                    if(diet[j]=='P')
                    {
                        l1=getMax(l,protein);
                    }
                    else if(diet[j]=='F')
                    {
                        l1=getMax(l,fat);
                    }
                    else if(diet[j]=='C')
                    {
                        l1=getMax(l,carbs);
                    }
                    else if(diet[j]=='T')
                    {
                        l1=getMax(l,calories);
                    }
                    else if(diet[j]=='f')
                    {
                        l1=getMin(l,fat);
                    }
                     else if(diet[j]=='c')
                    {
                        l1=getMin(l,carbs);
                    }
                     else if(diet[j]=='p')
                    {
                        l1=getMin(l,protein);
                    }
                     else if(diet[j]=='t')
                    {
                        l1=getMin(l,calories);
                    }
                    if(l.Count==0)
                    {
                        l=l1;
                    }
                    else if(l.Count!=0)
                    {
                        l=l.Intersect(l1).ToList();
                    }
                    
                }
                int min=1000;
                foreach(var x in l)
                {
                    min=Math.Min(min,x);
                }
                ans[i]=min;
            }
            
            return ans;
             throw new NotImplementedException();
        }
        public static List<int> getMax(List <int> l,int[] a)
        {
            int max=0;
            int index=0;
            List<int> l1=new List<int>();
            for(int i=0;i<a.Length;i++)
            {
               if(a[i]>max)
               {
                   if(l.Count==0)
                    {
                        max=a[i];
                        index=i;
                    }
                   else{
                       if(l.Contains(i)==true)
                       {
                           max=a[i];
                        index=i;
                       }

                   }
               }
               
            }
            l1.Add(index);
            for(int i=0;i<a.Length;i++)
            {
                if(max==a[i] && i!=index)
                {
                    if(l.Count==0)
                    {
                        l1.Add(i);
                    }
                   else{
                       if(l.Contains(i)==true)
                       {
                           l1.Add(i);
                       }

                   }
                }
            }
            
            return l1;
        }
        public static List<int> getMin(List <int> l,int[] a)
        {
            int min=100000;
            int index=0;
            List<int> l1=new List<int>();
            for(int i=0;i<a.Length;i++)
            {
               if(a[i]<min)
               {
                   if(l.Count==0)
                    {
                        min=a[i];
                        index=i;
                    }
                   else if(l.Count!=0){
                   if(l.Contains(i)==true)
                       {
                           min=a[i];
                           index=i;
                       }

                   }
               }
               
            }
            
            l1.Add(index);
            for(int i=0;i<a.Length;i++)
            {
                if(min==a[i] && i!=index)
                {
                    if(l.Count==0)
                    {
                        l1.Add(i);
                    }
                   else{
                       if(l.Contains(i)==true)
                       {
                           l1.Add(i);
                       }

                   }
                }
            }
             
            return l1;
        }
    }




}
