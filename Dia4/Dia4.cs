using AdventOfCode24.Helpers;
using System.Reflection.Metadata.Ecma335;

var inputPath = Helper.GetInputFilePath(4);
string[] input = File.ReadAllLines(inputPath);
var filas = input.Length;
var columnas = input[0].Length;
char[,] grid = new char[filas, columnas];

//poblar el grid
for (int i = 0; i < filas; i++)
{
    for (int j = 0; j < columnas; j++)
    {
        grid[i, j] = input[i][j];
    }
}
Console.WriteLine($"Tamaño total del grid: filas {filas} y columnas {columnas}");

int ocurrencias = BuscarPalabra("XMAS", grid);
//Solucion
Console.WriteLine($"Numero de veces que se ha encontrado la palabra: {ocurrencias}");


static int BuscarPalabra(string palabra, char[,] matriz)
{
    //en C# para un array tipo [,] el 0 da filas y 1 columnas
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);
    Console.WriteLine($"filas y columnas recibidas en buscarPalabra: filas {filas} y columnas {columnas}");
    var ocurrencias = 0;
    //Se busca la primera letra de la palabra por todas las posiciones del array
    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            Console.WriteLine($"Buscando en fila, columna [{i}],[{j}]");
            //Si el resultado de buscar la palabra en esa posicion es true, subimos contador de ocurrencias
            if(BuscarPalabraAqui(palabra,matriz, i, j))
            {
                ocurrencias++;
            }
        }
    }

    return ocurrencias;
}

static bool BuscarPalabraAqui(string palabra, char[,] matriz, int fila, int columna)
{
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);
    var longitudPalabra = palabra.Length;

    int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
    int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

    //Buscamos solo si la palabra empieza en esta casilla
    if (matriz[fila,columna] != palabra[0])
    {
        return false;
    }
    
    //se buscan las siguientes letras en cada posible direccion, si se falla se prueba con el siguiente vector
    //asi no hay quepreocuparse de buscar palabras inversas
    for(int direccion = 0; direccion < 8; direccion++)
    {
        int posicionLetra = 1;
        int posicionX = fila + x[direccion];
        int posicionY = columna + y[direccion];
        
        Console.WriteLine($"Comprobando palabra por la letra {palabra[posicionLetra]} en fila,columna ({fila}, {columna}) en dirección {direccion}.");
        //se prueban las 8 posibles direcciones desde la segunda letra porque la primera ya la hemos encontrado
        for (posicionLetra = 1;  posicionLetra < longitudPalabra; posicionLetra++)
        {
            //posiciones limite
            if (posicionX < 0 || posicionX >= filas || posicionY < 0 || posicionY >= columnas)
            {
                break;
            }
            //si la siguiente letra coincide, sumamos uno mas a la direccion para evaluar la siguiente posicion que deberia tener la siguiente letra
            if (matriz[posicionX,posicionY] == palabra[posicionLetra])
            {
                Console.WriteLine($"Comprobando palabra por la letra {palabra[posicionLetra]} en fila,columna ({fila}, {columna}) en dirección {direccion}.");

                posicionX += x[direccion];
                posicionY += y[direccion];
            }
            else
            {
                //si no coincide la letra, esta direccion ya no va a ser válida y probamos la siguiente
                break;
            }
        }
        //Si ha llegado al final es que ha encontrado todas las letras en orden
        if(posicionLetra == longitudPalabra)
        {
            Console.WriteLine($"Encontrada palabra {palabra} en posición ({fila},{columna}) en dirección {direccion}");
            return true;
        }

    }

    return false;

}

