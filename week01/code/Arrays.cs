using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        //***PLAN***: 
        //1-Keep track of number and lenght (N, L), taking two integers.
        //2-Create an empty array 
        //3-Append N to the array. It will be on index 0
        //4-Use the the number N, and lenght L on a loop. Loop "L" times if N is greater than 0. 
        //3-Get the last integer on the array. Add LastDigit + N. (Do this on every loop, and append to the array). 
        /// Example: N = 3, L=5
        /// Create empty array
        /// Append N to the array.
        /// Create variable to keep track of the loop. keepTrack = 0
        /// While keepTrack < L, Loop, and add 1 to Keeptrack on each loop:
        /// 1ST LOOP: Array = [3] 
        /// 2ND LOOP: Array = [3, 3+3]
        /// 3RD LOOP: Array = [3, 3+3, 6+3] 
        /// update-need to use multiplication instead to get the multiples.
        //

         double[] multiples = new double[length];
         for (int i = 0; i < length; i++)
        {
            
            multiples[i] = number * (i + 1);
        }

        return multiples; 
    }

    
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle edge cases
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // No rotation needed
        }

        // Step 2: Normalize the amount to avoid redundant rotations
        int effectiveAmount = amount % data.Count;

        if (effectiveAmount == 0)
        {
            return; // No rotation needed
        }

        // Step 3: Extract the elements to rotate
        List<int> tail = data.GetRange(data.Count - effectiveAmount, effectiveAmount);

        // Step 4: Remove the extracted elements from the end
        data.RemoveRange(data.Count - effectiveAmount, effectiveAmount);

        // Step 5: Insert the extracted elements at the beginning
        data.InsertRange(0, tail);
    }

}
