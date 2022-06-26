// See https://aka.ms/new-console-template for more information

using System.Text;

var str = "あ123刀𩸽";

Console.WriteLine(str);

var byteArray = Encoding.Unicode.GetBytes(str);

var byteArray1lack = new byte[byteArray.Length * 2];
var byteArray2lack = new byte[byteArray.Length * 2];
var byteArray3lack = new byte[byteArray.Length * 2];
var byteArray4lack = new byte[byteArray.Length * 2];

Array.Copy(byteArray, byteArray1lack, byteArray.Length - 1);
Array.Copy(byteArray, byteArray2lack, byteArray.Length - 2);
Array.Copy(byteArray, byteArray3lack, byteArray.Length - 3);
Array.Copy(byteArray, byteArray4lack, byteArray.Length - 4);

var str1lack = Encoding.Unicode.GetString(byteArray1lack);
var str2lack = Encoding.Unicode.GetString(byteArray2lack);
var str3lack = Encoding.Unicode.GetString(byteArray3lack);
var str4lack = Encoding.Unicode.GetString(byteArray4lack);

Console.WriteLine(str1lack);
Console.WriteLine(str2lack);
Console.WriteLine(str3lack);
Console.WriteLine(str4lack);

str1lack = str1lack.TrimEnd('\0');
str2lack = str2lack.TrimEnd('\0');
str3lack = str3lack.TrimEnd('\0');
str4lack = str4lack.TrimEnd('\0');

Console.WriteLine(str1lack);
Console.WriteLine(str2lack);
Console.WriteLine(str3lack);
Console.WriteLine(str4lack);

var charArray = str.ToCharArray();
var charArray1lack = new char[charArray.Length];
var charArray2lack = new char[charArray.Length];
Array.Copy(charArray, charArray1lack, charArray.Length - 1);
Array.Copy(charArray, charArray2lack, charArray.Length - 2);

str1lack = new string(charArray1lack);
str2lack = new string(charArray2lack);

Console.WriteLine(str1lack);
Console.WriteLine(str2lack);

var charArray1lackReverce = charArray1lack.Reverse().ToArray();
var charArray2lackReverce = charArray2lack.Reverse().ToArray();

var found1 = Array.FindIndex(charArray1lackReverce, c => c != '\0');
var found2 = Array.FindIndex(charArray2lackReverce, c => c != '\0');

if (found1 != -1
    && char.IsHighSurrogate(charArray1lackReverce[found1]))
{
    charArray1lackReverce[found1] = '\0';
}

if (found2 != -1
    && char.IsHighSurrogate(charArray2lackReverce[found2]))
{
    charArray2lackReverce[found2] = '\0';
}

str1lack = new string(charArray1lackReverce.Reverse().ToArray());
str2lack = new string(charArray2lackReverce.Reverse().ToArray());

str1lack = str1lack.TrimEnd('\0');
str2lack = str2lack.TrimEnd('\0');

Console.WriteLine(str1lack);
Console.WriteLine(str2lack);