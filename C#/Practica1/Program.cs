namespace Practica1
{
    class Program
    {
        static void Main()
        {
            Prueba classPrueba = new Prueba();
            classPrueba.practicaInicial();

            int numero1 = int.Parse(Console.ReadLine());
            int numero2 = int.Parse(Console.ReadLine());

            Suma suma= new Suma();
            suma.funcionSuma(numero1, numero2);
            Console.WriteLine("La suma es: " + suma.funcionSuma(numero1, numero2));

            Resta resta = new Resta();
            resta.funcionResta(numero1, numero2);
            Console.WriteLine("La resta es: " + resta.funcionResta(numero1, numero2));

            Multiplicacion multiplicacion = new Multiplicacion();
            multiplicacion.funcionmultiplicacion(numero1, numero2);
            Console.WriteLine("La multiplicación es: " + suma.funcionSuma(numero1, numero2));

            Division division = new Division(); 
            division.funcionDivision(numero1, numero2);
    
        }
    }
}