using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        double LON = doubleParse(Console.ReadLine());
        double LAT = doubleParse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        List<DEFIB> DEFIBs = new List<DEFIB>();
        for (int i = 0; i < N; i++)
        {
            DEFIBs.Add(new DEFIB(Console.ReadLine()));
        }
        DEFIB someDefib = new DEFIB(DEFIBs[0]);
        foreach(DEFIB d in DEFIBs)
        {
            if(someDefib.distance(LAT, LON) > d.distance(LAT, LON))
            {
                someDefib = d;
            }
        }

        Console.WriteLine(someDefib.name);
    }
    public static double doubleParse(string num)
    {
        string[] nums = num.Split(',');
        return double.Parse($"{nums[0]}.{nums[1]}");
    }
}
class DEFIB
{
    public int index;
    public string name;
    public string address;
    public string phoneNum;
    public double Longitude;
    public double Latitude;
    public DEFIB(string s)
    {
        string[] splittedS = s.Split(';');
        index = int.Parse(splittedS[0]);
        name = splittedS[1];
        address = splittedS[2];
        phoneNum = splittedS[3];
        Longitude = doubleParse(splittedS[4]);
        Latitude = doubleParse(splittedS[5]);
    }
    public DEFIB(DEFIB d)
    {
        this.index = d.index;
        this.name = d.name;
        this.address = d.address;
        this.phoneNum = d.phoneNum;
        this.Longitude = d.Longitude;
        this.Latitude = d.Latitude;
}
    public double distance(double latitude, double longitude)
    {
        double x = (Longitude - longitude) * Math.Cos((latitude + Latitude) / 2);
        double y = Latitude - latitude;
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
    }
    public override string ToString()
    {
        return $"index:{index} \n " +
            $"name:{name} | address is '{address}' \n " +
            $"num:{phoneNum} \n " +
            $"coords: {Longitude} {Latitude}";
    }
    public static double doubleParse(string num)
    {
        string[] nums = num.Split(',');
        return double.Parse($"{nums[0]}.{nums[1]}");
    }
}