using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaksValleyFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int[] myArray = new int[] { 4, 1, 8, 5, 3, 6, 3, 2, 9};
            p.MergeSort(myArray, 0, myArray.Length-1);
            myArray = p.PeakValleySort(myArray);
            foreach(int i in myArray)
            {
                Console.WriteLine(i);
            }


        }

        private int[] PeakValleySort(int[] arr)
        {
            int[] newArr = new int[arr.Length]; //{1, 2, 3, 3, 4, 5, 6, 8, 9} Length = 8
            int mid = newArr.Length/2;            //8/2 = 4th element {1, 2, 3, 3, 4(mid), 5, 6, 8, 9}
            int leftArr = 0;                        //Start from first element
            int rightArr = arr.Length-1;         //Start from last element

            if(leftArr < rightArr)
            {
                for (int i = 1; i < arr.Length; i+=2) //Increment twice
                {
                    newArr[i-1] = arr[rightArr]; 
                    newArr[i] = arr[leftArr];
                    leftArr++;
                    rightArr--;
                }
               
                //If amount of elements is odd, place last element
                if((arr.Length % 2) != 0)
                {
                    newArr[arr.Length-1] = arr[mid];
                }
            }
            return newArr;
        }
        private void MergeSort(int [] arr, int left, int right)
        {
            //If array does not contain only one element
            if(left < right)
            {
                int middle = (left + right) / 2; //Get middle of array

                MergeSort(arr, left, middle);    //Split the left side of the array until it's one element
                MergeSort(arr, middle + 1, right); //Split the right side of the array until it's one element

                Merge(arr, left, middle, right);
            } 
        }

        private void Merge(int [] arr, int left, int middle, int right)
        {
            int[] leftArr = new int[middle - left + 1]; //Get size by splitting array from the middle to the left
            int[] rightArr = new int[right - middle]; //Get size by splitting array from the middle to the left
            
            Array.Copy(arr, left, leftArr, 0, middle - left + 1); //Copy the elements from left side of array into leftArr
            Array.Copy(arr, middle + 1, rightArr, 0, right - middle); //Copy the elements from right side of array into rightArr

            int i = 0; //Used to keep track of element in left array
            int j = 0; //Used to keep track of element in right array

            for (int k = left; k < right + 1; k++) //Loop entire array size
            {
                if (i == leftArr.Length) //If there are no more elements in leftArr, put element rightArr
                {                        //into base array and increment rightArr counter
                    arr[k] = rightArr[j];
                    j++;
                }
                else if (j == rightArr.Length)  //If there are no more elements in rightArr, put element leftArr
                {                               //into base array and increment leftArr counter
                    arr[k] = leftArr[i];
                    i++;
                }
                else if (leftArr[i] <= rightArr[j]) //If leftArr's value is less than or equal to 
                {                                    //rightArr's value then base array is leftArr 
                    arr[k] = leftArr[i];             //value and increment leftArr counter
                    i++;
                }
                else //rightArr's element gets put into base array, increment rightArr counter
                {
                    arr[k] = rightArr[j];
                    j++;
                }
            }
        }
    }
}
