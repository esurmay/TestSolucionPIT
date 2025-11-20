using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var words = new string[]
{
    "al", "bums", "albums",
    "cat", "dog", "catdog",
    "hello", "world", "helloworld",
    "albu", "ms",

};

string filePath = Path.Combine(AppContext.BaseDirectory, "wordlist.txt");


string[] lineas = File.ReadAllLines(filePath);


////1er intento
//foreach (var word in lineas)
//{
//    if(word.Length != 6)
//        continue;

//    bool canbeconcatenated = false;

//    for (int i = 1; i < word.Length; i++)
//    {
//        var firtsWord = word.Substring(0, i);
//        var secondWord = word.Substring(i);
       
//        if (lineas.Contains(firtsWord) && lineas.Contains(secondWord))
//        {
//            canbeconcatenated = true;
//            Console.WriteLine($"From: {firtsWord} and {secondWord}: FIND: {firtsWord + secondWord}");
//        }
//    }

//}
////tiempo desarrollo aproximado: 20 minutos

Stopwatch stopwatch = Stopwatch.StartNew();
//2do intento optimizado
string palabracombinada = string.Empty;
for (int i = 0; i < lineas.Count(); i++)
{
    for (int j = 0; j < lineas.Count(); j++)
    {
        palabracombinada = lineas[i] + lineas[j];

        if (palabracombinada.Length == 6 && lineas.Contains(palabracombinada))
        {
            Console.WriteLine($"From: {lineas[i]} and {lineas[j]}: FIND: {palabracombinada}");
        }
    }
}
Console.WriteLine($"Elapsed Time if execution: {stopwatch.ElapsedMilliseconds} ms");

//tiempo desarrollo aproximado: 20 minutos

