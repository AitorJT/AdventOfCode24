using System.Runtime.CompilerServices;

string rutaInput = "F:/Codigo/CodigoDeAdvientoPorquePolvoronesNoMeHacenFalta/Dia2/Dia2/input.txt";
int validReports = 0;
var sr = new StreamReader(rutaInput);
string input = sr.ReadToEnd();
var lineas = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
//var lineas = input.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
foreach (var linea in lineas)
{

    //pasamos a lista de ints haciendo un int.parse para todos los elementos resultantes de separarlo por espacios
    List<int> levels = linea.Split(' ').Select(int.Parse).ToList();

    //foreach (var level in levels)
    //{
    //    Console.WriteLine(level);
    //}
    bool creciente = levels[0] < levels[1];
    bool esValido = false;
    if (creciente)
    {
        esValido = Ascendente(levels);
    }
    else
    {
        esValido = Descendente(levels);
    }

    if (esValido)
    {
        validReports++;
    }
    else
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var ignorado = levels[i];
            levels.RemoveAt(i);

            creciente = levels[0] < levels[1];

            if (creciente)
            {
                esValido = Ascendente(levels);
            }
            else
            {
                esValido = Descendente(levels);
            }

            if (esValido)
            {
                validReports++;
                break;
            }
            //dejamos el array como estaba
            levels.Insert(i, ignorado);
        }
    }
}

Console.WriteLine($"Deberían ser {validReports} reports validos.");

bool Descendente(List<int> levels)
{
    //se pasa por todos los elementos ya sabiendo que tienen que descender
    for (int i = 0; i < levels.Count - 1; i++)
    {
        var diferencia = Math.Abs(levels[i] - levels[i + 1]);
        //no hace falta CalcularIncrementoValido si sbemos directamente que tiene que ser mayor que la siguiente posicion pero sin una diferencia mayor de 3
        if (levels[i] <= levels[i + 1] || diferencia > 3)
        {
            return false;
        }
    }
    return true;
}

bool Ascendente(List<int> levels)
{
    for (int i = 0; i < levels.Count - 1; i++)
    {
        var diferencia = Math.Abs(levels[i] - levels[i + 1]);
        if (levels[i] >= levels[i + 1] || diferencia > 3)
        {
            return false;
        }
    }
    return true;
}

