using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'pylons' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static int pylons(int k, List<int> arr)
    {
          int n = arr.Count;
        int plants = 0;
        int position = 0;
        
        while (position < n) {
            // Find the farthest position where we can place a plant
            int plantPos = Math.Min(position + k - 1, n - 1);
            
            // Move left until we find a valid city to build a plant
            while (plantPos >= Math.Max(0, position - k + 1) && arr[plantPos] == 0) {
                plantPos--;
            }
            
            // If no valid city found within range, return -1
            if (plantPos < Math.Max(0, position - k + 1)) {
                return -1;
            }
            
            // Place plant at plantPos
            plants++;
            
            // Move to the next uncovered position
            position = plantPos + k;
        }
        
        return plants;
    }

    }
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.pylons(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
