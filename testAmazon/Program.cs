using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace testAmazon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var divider = divideTest(new[] {2, 4, 6, 8, 10}, 5);
            var states1 = cellComplete(new[] {1, 0, 0, 0, 0, 1, 0, 0}, 1);
            Console.WriteLine(states1);
            var states2 = cellComplete(new[] {1, 1, 1, 0, 1, 1, 1, 1}, 2);
            var packages = new List<KeyValuePair<int, int>>();
            List<int> packagesSpace = new List<int>();
            
            
            packages.Add(new 
                    KeyValuePair
                        <int, int>());

            foreach (var item in packages)
            {
                
            }

            int findMinDiff(int []arr, int n) 
            { 
          
                // Initialize difference as infinite 
                int diff = int.MaxValue; 
      
                // Find the min diff by comparing difference 
                // of all possible pairs in given array 
                for (int i = 0; i < n-1; i++) 
                for (int j = i+1; j < n; j++) 
                    if (Math.Abs((arr[i] - arr[j]) ) < diff) 
                        diff = Math.Abs((arr[i] - arr[j])); 
      
                // Return min diff  
                return diff; 
            } 
            Console.WriteLine(states2);
            //Console.WriteLine(divider - 1);
            Console.ReadKey();
        }

        static int[] cellComplete(int[] states, int days)
        {
            var day = 1;
        
            while(day < days + 1)
            {
                states = changeStatesforDay(states);
                day++;
            }
            return states;
        }
        //23280666918029

        static int[] changeStatesforDay(int[] states)
        {
            var changable = new Dictionary<int,int>();
            for (int i = 0; i < states.Length; i++)
            {
                if (i == 0)
                {
                    if (states[i + 1] == 0)
                    {
                        changable.Add(i, 0);
                    }
                    else
                    {
                        changable.Add(i,1);
                    }
                }
                else if(i != states.Length - 1)
                {
                    if (states[i - 1] == 1 && states[i + 1] == 1 || states[i - 1] == 0 && states[i + 1] == 0)
                    {
                        changable.Add(i, 0);
                    }
                    else
                    {
                        changable.Add(i,1);
                    }
                }
                else
                {
                    if (states[i - 1] == 0)
                    {
                        changable.Add(i,0);
                    }
                    else
                    {
                        changable.Add(i,1);
                    }
                }
            }

            foreach (var item in changable)
            {
                states[item.Key] = item.Value;
            }

            return states;
        }

        static bool isChangableState(int[] array, int index)
        {
            if (array[index - 1] == 1 && array[index + 1] == 1 || array[index - 1] == 0 && array[index + 1] == 0)
            {
                return true;
            }

            return false;
        }

        static int divideTest(int[] arr, int num)
        {
            var divider = 1;
            var result = 0;
            while(result == 0)
            {
                result = divisionForArray(arr, divider, num);
                if (result != 0)
                {
                    break;
                }

                divider++;
            }

            return divider - 1;
        }

        static int divisionForArray(int[] array, int divider, int num)
        {
            var result = 0;
            for (var i = 0; i < num; i++)
            {
                result = array[i] % divider;
                if (result != 0)
                {
                    break;
                }
            }

            return result;
        }

        
    }
}
