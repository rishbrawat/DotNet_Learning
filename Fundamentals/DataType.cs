using System;

public class DataTypes
{
    public static void Main(String [] args) {
        /**
         * common data types are
         * int - 32bit or 4bytes
         * float - 32bit or 4bytes
         * long - 64bits or 8bytes
         * bool - truth or false value 1bit
         * char - 1 bit char
         * string - compile time sizing
         */

        int Integer = 10;
        float Area = 3.12f;
        long BigNumber = 1234567891011L;

        bool IsGreater = false;

        char FirstLetter = 'A';
        string FullName = "Rishabh Rawat";


        // Printing out everything to the console
        Console.WriteLine($"Integer: {Integer} \nArea: {Area} \nBigNumber: {BigNumber} \nIsGreater:{IsGreater} \nFirstLetter: {FirstLetter} \nFullName: {FullName}\n");
 }
}