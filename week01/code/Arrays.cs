using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// Return an array with the first `count` multiples of `number`.
    /// Example: MultiplesOf(3,5) -> {3,6,9,12,15}
    /// </summary>
    public static double[] MultiplesOf(double number, int count)
    {
        /*
        PLAN FOR MULTIPLESOF FUNCTION:

        1) Create a double[] of length count.
        2) For i from 0 to count-1 compute number * (i+1) and store in array[i].
        3) Return the array.

        Keep comments as required by the assignment.
        */

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "count must be non-negative");

        double[] multiples = new double[count];
        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
            Debug.WriteLine($"Multiple {i + 1}: {number} × {i + 1} = {multiples[i]}");
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the list to the right by `amount` positions, in-place.
    /// For example: data={1,2,3,4,5,6,7,8,9}, amount=3 -> {7,8,9,1,2,3,4,5,6}
    /// amount is expected to be between 1 and data.Count inclusive.
    /// </summary>
    public static void RotateListRight<T>(List<T> data, int amount)
    {
        /*
        PLAN FOR ROTATELISTRIGHT FUNCTION:

        1) Validate input (data != null, amount in allowed range).
        2) If amount == data.Count, rotation results in the same list -> return.
        3) Compute splitIndex = data.Count - amount.
        4) Extract right part (last 'amount' elements) and left part (first splitIndex elements).
        5) Clear original list, then add right part followed by left part.
        */

        if (data == null)
            throw new ArgumentNullException(nameof(data));

        if (data.Count == 0)
            return; // nothing to rotate

        if (amount < 1 || amount > data.Count)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be between 1 and the list count inclusive");

        // If rotating by full length -> same list
        if (amount == data.Count)
            return;

        Debug.WriteLine($"Rotating list right by {amount} positions");

        int splitIndex = data.Count - amount;
        List<T> rightPortion = data.GetRange(splitIndex, amount);
        List<T> leftPortion = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPortion);
        data.AddRange(leftPortion);
    }
}
