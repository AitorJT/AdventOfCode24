using AdventOfCode24.Helpers;

var inputPath = Helper.GetInputFilePath(4);
string[] input = File.ReadAllLines(inputPath);
var filas = input.Length;
var columnas = input[0].Length;
char[,] grid = new char[filas, columnas];

for (int i = 0; i < filas; i++)
{
    for (int j = 0; j < columnas; j++)
    {
        grid[i, j] = input[i][j];
    }
}

int ocurrencias = BuscarPalabra("XMAS", grid);
Console.WriteLine($"Numero de veces que se ha encontrado la palabra: {ocurrencias}");
static int BuscarPalabra(string palabra, char[,] matriz)
{
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);

    var ocurrencias = 0;

    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
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
    
    //se buscan las siguientes letras en cada direccion, si se falla se prueba con el siguiente vector
    for(int direccion = 0; direccion < 8; direccion++)
    {
        int posicionLetra = 1;
        int posicionX = fila + x[direccion];
        int posicionY = columna + y[direccion];
        //en 
        for(posicionLetra = 1;  posicionLetra < longitudPalabra; posicionLetra++)
        {
            //posiciones limite
            if(posicionX >= filas || posicionX < 0)
            {
                break;
            }
            if(posicionY >= columnas || posicionY < 0)
            {
                break;
            }

            if (matriz[posicionX,posicionY] == palabra[posicionLetra])
            {
                posicionX += x[direccion];
                posicionY += y[direccion];
            }
            else
            {
                break;
            }
        }
        //Si ha llegado al final es que ha encontrado todas las letras
        if(posicionLetra == longitudPalabra)
        {
            return true;
        }

    }

    return false;

}

