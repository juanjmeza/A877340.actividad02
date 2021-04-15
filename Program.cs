using System;
using System.Collections.Generic;

namespace A877340.Actividad02
{
    class Program
    {
        static int validarEntero(string ingreso, string mensajeError)
        {
            int numero;
            bool ingresoCorrecto = Int32.TryParse(ingreso, out numero);

            while(!ingresoCorrecto || numero <= 0)
            {
                Console.WriteLine(mensajeError);
                Console.Write("Ingrese un número del 1 al 4 nuevamente: ");
                ingresoCorrecto = Int32.TryParse(ingreso, out numero);
            }

            return numero;
        }
        static void Main(string[] args)
        {
           

            Dictionary<int, int> tecnicos = new Dictionary<int, int>();
            Queue<int> ordenes = new Queue<int>();

            Dictionary<int, int> tecnicosYordenes = new Dictionary<int, int>();

            while(true)
            {
                Console.WriteLine("1) Dar de alta de operadores tecnicos.");
                Console.WriteLine("2) Ingreso de nueva orden de trabajo.");
                Console.WriteLine("3) Asignar orden de trabajo a tecnicos.");
                Console.WriteLine("4) Salir");
                Console.Write("Ingrese una opcion: ");
                int opcion;
                bool ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out opcion);
                while(!ingresoCorrecto || opcion < 1 || opcion > 4)
                {
                    Console.Write("Opción no válida, ingrese una opción correcta: ");
                    ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out opcion);
                }

                switch(opcion)
                {
                    case 1:
                        {
                            Console.Write("Ingrese el número de tecnicos que desea dar de alta: ");
                            int numtecnicos = validarEntero(Console.ReadLine(), "Número de tecnicos inválido");
                            for(int i = 0; i < numtecnicos; i++)
                            {
                                Console.Write("Ingrese el número del operador tecnico que desea dar de alta: ");
                                int operadorTecnico;
                                ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out operadorTecnico);
                                while(!ingresoCorrecto || operadorTecnico <= 0)
                                {
                                    Console.Write("Ingreso inválido, ingrese otro número de operadorTecnico: ");
                                    ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out operadorTecnico);
                                }
                                if(tecnicos.ContainsKey(operadorTecnico))
                                {
                                    Console.WriteLine("Número de operador tecnico ya existente. Intente nuevamente");
                                    i--;
                                }

                                tecnicos.Add(operadorTecnico,0);
                            }
                            if(numtecnicos == 1)
                            {
                                Console.WriteLine("operador tecnico registrado ingresoCorrectosamente.");
                            }else
                            {
                                Console.WriteLine($"Se registraron correctos {numtecnicos} tecnicos.");
                            }
                            
                        }
                        break;

                    case 2:
                        {
                            Console.Write("Ingrese el número de ordenes que desea ingresar: ");
                            int numOrdenes = validarEntero(Console.ReadLine(), "Número de ordenes inválido");
                            for (int i = 0; i < numOrdenes; i++)
                            {
                                Console.Write("Ingrese el número de orden: ");
                                int orden;
                                ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out orden);
                                while (!ingresoCorrecto || orden <= 0)
                                {
                                    Console.Write("Ingreso inválido, ingrese otro número de orden: ");
                                    ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out orden);
                                }
                                if (ordenes.Contains(orden))
                                {
                                    Console.WriteLine("Número de orden ya cargado, ingrese nuevamente");
                                    i--;
                                }

                                ordenes.Enqueue(orden);
                            }
                            if (numOrdenes == 1)
                            {
                                Console.WriteLine("Orden ingresada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine($"Se registraron correctamente {numOrdenes} ordenes.");
                            }

                        }
                        break;

                    case 3:
                        {
                            Console.Write("Ingrese el número del operador tecnico: ");
                            int operadorTecnico;
                            ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out operadorTecnico);
                            while(!ingresoCorrecto || operadorTecnico <= 0)
                            {
                                Console.Write("Número de operador tecnico inválido, ingrese un número de operador tecnico válido: ");
                                ingresoCorrecto = Int32.TryParse(Console.ReadLine(), out operadorTecnico);
                            }
                            if(!tecnicos.ContainsKey(operadorTecnico))
                            {
                                Console.WriteLine($"El operador tecnico {operadorTecnico} no existe.");
                                continue;
                            }

                            if (tecnicosYordenes.ContainsKey(operadorTecnico))
                            {
                                Console.WriteLine($"Orden {tecnicosYordenes[operadorTecnico]} finalizada.");
                                tecnicos[operadorTecnico]++;
                            }

                            if (ordenes.Count == 0)
                            {
                                Console.WriteLine($"operador tecnico {operadorTecnico} existe pero no hay ordenes pendientes de asignar.");
                                tecnicosYordenes.Remove(operadorTecnico);
                                continue;
                            }

                            tecnicosYordenes[operadorTecnico] = ordenes.Dequeue();

                            Console.WriteLine($"Orden {tecnicosYordenes[operadorTecnico]} asignada a {operadorTecnico}.");


                        }
                        break;

                    case 4:
                        {
                            
                            foreach(int operadorTecnico in tecnicos.Keys)
                            {
                                
                                Console.WriteLine($"operadorTecnico: {operadorTecnico}, Ordenes: {tecnicos[operadorTecnico]}.");
                            }

                            Console.WriteLine("Ordenes pendientes: ");
                            while(ordenes.Count > 0)
                            {
                                Console.WriteLine(ordenes.Dequeue());
                            }
                            foreach(int operadorTecnico in tecnicosYordenes.Keys)
                            {
                                Console.WriteLine(tecnicosYordenes[operadorTecnico]);
                            }
                        }

                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                }
            }
        }
    }
}
