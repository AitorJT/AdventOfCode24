
using AdventOfCode24.Helpers;
using System.Text.RegularExpressions;

var inputPath = Helper.GetInputFilePath(3);
string input = File.ReadAllText(inputPath);
string regex1 = @"mul\((?<primerNumero>[0-9]{1,3}),(?<segundoNumero>[0-9]{1,3})\)";
string regex2 = @"(?<mul>mul\((?<primerNumero>[0-9]{1,3}),(?<segundoNumero>[0-9]{1,3})\))|(?<do>do\(\))|(?<dont>don't\(\))";
int sumaTotal = 0;
var hacer = true;
MatchCollection resultados = Regex.Matches(input, regex2);

foreach (Match resultado in resultados)
{
    if (hacer)
    {        
        if (EsDont(resultado))
        {
            hacer = false;
            continue;
        }
        if (EsMul(resultado))
        {
            sumaTotal += int.Parse(resultado.Groups["primerNumero"].Value) * int.Parse(resultado.Groups["segundoNumero"].Value);
        }
    }
    else
    {
        if (EsDo(resultado))
        {
            hacer = true;
            continue;
        }
    }    
}
static bool EsMul(Match resultado)
{
    if (resultado.Groups["mul"].Success)
    {
        return true;
    }
    return false;
}
static bool EsDo(Match resultado)
{
    if (resultado.Groups["do"].Success)
    {
        return true;
    }
    return false;
}
static bool EsDont(Match resultado)
{
    if (resultado.Groups["dont"].Success)
    {
        return true;
    }
    return false;
}
Console.WriteLine($"Me encanta trabajar con regex ojalá hacerlo a diario :C... por cierto el resultado de la suma tiene que ser {sumaTotal}");