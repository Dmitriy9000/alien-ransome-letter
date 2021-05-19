using System;
using System.Collections.Generic;

namespace AlienRansomeLib
{
    public class AlienRansomeProblem
    {
        /*
        N - ransome letter input length
        M - magazine input length

        Solution Complexity: O(2N + M)
        */
        public bool SolveUsingDictionary() {
          
            var ransomeCodes = GetInput(); // O(N)

            // Input validation
            if (ransomeCodes == null) 
            {
                Console.Error.WriteLine("Invalid ransome letter input");
                return false;
            }

            // Edge case
            if (ransomeCodes.Count == 0) 
            {
                return true;
            }

            var magazineCodes = GetInput(); // O(M)

            // Input validation
            if (magazineCodes == null) 
            {
                Console.Error.WriteLine("Invalid magazine input");
                return false;
            }

            // Edge case
            if (magazineCodes.Count == 0) 
            {
                return false;
            }

            // If magazine codes count less than ransome codes count, then there is no reason to iterate over dictionary (`fail fast` optimization)
            if (magazineCodes.Count < ransomeCodes.Count) 
            {
                return false;
            }

            foreach (var i in ransomeCodes) // O(N)
            { 
                if (magazineCodes.ContainsKey(i.Key)) // O(1)
                { 
                    if (magazineCodes[i.Key] < i.Value) // O(1)
                    { 
                        return false;
                    }
                }
                else 
                {
                    return false;
                }
            }

            return true;
        }

        // Populates the dictionary from user's input
        // ['code1'] = number of encounters of code1
        // ['code2'] = number of encounters of code2
        // ...
        private Dictionary<string, long> GetInput() 
        {
            var lengthInput = Console.ReadLine();

            long length = 0;
            if (!long.TryParse(lengthInput, out length)) 
            {
                Console.Error.WriteLine("Incorrect input");
                return null;
            }

            var result = new Dictionary<string, long>();

            while (length > 0)
            {
                var nextSymbol = Console.ReadLine();
                if (result.ContainsKey(nextSymbol))
                {
                    result[nextSymbol]++;
                }
                else 
                {
                    result.Add(nextSymbol, 1);
                }

                length--;   
            }

            return result;
        }      
    }
}
