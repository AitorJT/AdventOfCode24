string rutaInput = "F:/Codigo/CodigoDeAdvientoPorquePolvoronesNoMeHacenFalta/Dia1/Dia1/input.txt";
//una lista para cada columna
List<int> listaIzq = new List<int>();
List<int> listaDer = new List<int>();
int distanciaTotal = 0;
int similarityScore = 0;
Console.WriteLine("Parte 1");
try
{
    foreach (string linea in File.ReadLines(rutaInput))
    {
        //RemoveEmptyEntries porque hay varios espacios de separacion
        string[] partes = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        listaIzq.Add(int.Parse(partes[0]));
        listaDer.Add(int.Parse(partes[1]));
    }
}
catch (Exception ex)
{

    Console.WriteLine($"Error leyendo del archivo de input: {ex.Message}");
}

listaIzq.Sort();
listaDer.Sort();

for (int i = 0; i < listaIzq.Count; i++)
{
    distanciaTotal += Math.Abs(listaIzq[i] - listaDer[i]);

    int ocurrencias = listaDer.Count(x => x == listaIzq[i]);
    similarityScore += listaIzq[i] * ocurrencias;
}

Console.WriteLine($"En teoría la solución para la distancia total debería ser esta: {distanciaTotal}");
Console.WriteLine($"Confio en que la solucion para la similarity score sea: {similarityScore}");
