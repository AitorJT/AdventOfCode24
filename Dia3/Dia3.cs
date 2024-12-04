
using AdventOfCode24.Helpers;
using System.Text.RegularExpressions;




var inputPath = Helper.GetInputFilePath(3);
string input = File.ReadAllText(inputPath);
string regex = @"mul\((?<primerNumero>[0-9]{1,3}),(?<segundoNumero>[0-9]{1,3})\)";
int sumaTotal = 0;

MatchCollection resultados = Regex.Matches(input, regex);

foreach (Match resultado in resultados)
{
    sumaTotal += int.Parse(resultado.Groups["primerNumero"].Value) * int.Parse(resultado.Groups["segundoNumero"].Value);

    
}

Console.WriteLine($"Me encanta trabajar con regex ojalá hacerlo a diario :C... por cierto el resultado de la suma tiene que ser {sumaTotal}");