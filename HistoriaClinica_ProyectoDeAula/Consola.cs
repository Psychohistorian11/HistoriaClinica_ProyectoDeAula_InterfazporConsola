using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoriaClinica_ProyectoDeAula
{
    public class Consola
    {
        Clinica clinica = new Clinica();

        public void mostrarMenuDeInicio()
        {
            Console.Write("================================================\n" +
                          "|     historia Clinica de los Colombianos      |\n" +
                          "================================================\n" +
                          "|                                              |\n" +
                          "|       Menu de opciones                       |\n" +
                          "|                                              |\n" +
                          "================================================\n" +
                          "|                                              |\n" +
                          "|       1. Ingresar Usuario                    |\n" +
                          "|       2. Cambiar de EPS                      |\n" +
                          "|       3. Mostrar Estadisticas                |\n" +
                          "|       4. Salir                               |\n" +
                          "|                                              |\n" +
                          "================================================\n" );
        }

        public void ejecutar()
        {
            while(true)
            {
                mostrarMenuDeInicio();
                    Console.Write("|                                              |\n" +
                                  "|       Seleccione una opción :                |\n" +
                                  "|                                              |\n" +
                                  "================================================\n");
                int opcion = Convert.ToInt32( Console.ReadLine()); 
                switch(opcion )
                {
                    case 1:
                        ingresarPacienteConsola(); break;
                    case 2:
                        CambiarEPSConsola(); break;
                    case 3:
                        MostrarEstadisticasConsola(); break;
                    case 4:
                        Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Ingrese Opción valida");
                        ejecutar();
                        break;
                }
            }
        }

        public void ingresarPacienteConsola()
        {
            Console.WriteLine("================================================\n" +
                              "|                                              |\n" +
                              "|       Formulario                             |\n" +
                              "|                                              |\n" +
                              "================================================\n");
            Console.WriteLine("Identificacón: \n"+
                              "================================================\n");
            int identificacion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nombres: \n"+
                              "================================================\n");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellidos:\n"+
                              "================================================\n");
            string apellido = Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento:\n"+
                              "================================================\n");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("  Tipo de regimen:\n "+ "================================================\n");
            string tipoRegimen = Console.ReadLine();
            Console.WriteLine("  Semanas Cotizadas:\n" + "================================================\n");
            int semanasCotizadas = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("  fecha de Ingreso: \n" + "================================================\n");
            DateTime fechaIngreso = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("  fecha de Ingreso a la EPS: \n" + "================================================\n");
            DateTime fechaIngresoEPS = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("  EPS (Sura, Nueva EPS, Salud Total, Sanitas, Savia):\n" + "================================================\n");
            string EPS = Console.ReadLine();
            Console.WriteLine("  Historia Clinica: \n" + "================================================\n");
            string historiaClinica = Console.ReadLine();
            Console.WriteLine(" Cantidad de enfermedades: \n" + "================================================\n");
            int cantidadEnfermedades = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("  Enfermedad más relevante: \n" + "================================================\n");
            string enfermedadMasRelevante = Console.ReadLine();
            Console.WriteLine("  Tipo de Afiliación: \n" + "================================================\n");
            string tipoAfiliacion = Console.ReadLine();
            Console.WriteLine("  Costo de Tratamientos: \n" + "================================================\n");
            double costoTratamientos = Convert.ToDouble( Console.ReadLine());

            Persona nuevoPaciente = new Persona(identificacion, nombre, apellido, fechaNacimiento,
                                                tipoRegimen, semanasCotizadas, fechaIngreso, fechaIngresoEPS, EPS,
                                                historiaClinica, cantidadEnfermedades, enfermedadMasRelevante, tipoAfiliacion,
                                                costoTratamientos);
            clinica.ingresarPaciente(nuevoPaciente);



        }
        public void CambiarEPSConsola()
        {
        
            Console.WriteLine("================================================\n" +
                              "|                                              |\n" +
                              "|       Cambiar de EPS                         |\n" +
                              "|                                              |\n" +
                              "================================================\n");

            Console.WriteLine("  Digite identificación del paciente: ");
           
            int identificacionParaCambioEPS = Convert.ToInt32( Console.ReadLine());
            foreach(Persona paciente in clinica.ListaDePacientes)
            {
                if(paciente.Identificacion == identificacionParaCambioEPS)
                {
                    if(DateTime.Now >= paciente.FechaIngresoEPS.AddMonths(3))
                    {
                        Console.WriteLine("Se ha verifiado que la persona ha estado en el sistema de salud {0} por 3 meses o más.", paciente.EPS1);
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese la nueva EPS a la que desea ingresar (Sura, Nueva EPS, Salud Total, Sanitas, Savia)");
                        string nuevaEPS = Console.ReadLine();
                        if(paciente.EPS1 == nuevaEPS)
                        {
                            Console.WriteLine("Señor usuario usted ya hace parte de esta EPS, no se realizara el cambio");
                            Console.ReadKey();
                            ejecutar();
                        }
                        else
                        {
                            Console.WriteLine("Se procedera con el cambio de EPS...");
                            clinica.CambiarEPS(paciente, nuevaEPS);
                            Console.WriteLine("El paciente Identificado con el numero "+ paciente.Identificacion + 
                                              " ahora hace parte de la EPS: "+ paciente.EPS1);
                            BackMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("La persona ha estado en el sistema de salud por menos de 3 meses. ");
                        Console.WriteLine("No se puede realizar el cambio de EPS ");
                        BackMenu();

                    }
                    
                }
                else
                {
                    Console.WriteLine("El usuario actualmente no se encuentra en el sistema ");
                    BackMenu();
                }
            }

        }
        public void MostrarEstadisticasConsola()
        {

        }

        public void BackMenu()
        {
            Console.WriteLine("================================================\n" +
                              "|                                              |\n" +
                              "|       1. Volver al menu incial               |\n" +
                              "|       2. Salir del sistema                   |\n" +
                              "|                                              |\n" +
                              "================================================\n");
            Console.WriteLine("|                                              |\n" +
                              "|       Seleccione una opción :                |\n" +
                              "|                                              |\n" +
                              "================================================\n");

            int opcion = Convert.ToInt32( Console.ReadLine()); 
            switch(opcion)
            {
                case 1:
                    ejecutar();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ingrese Opción valida");
                    BackMenu();
                    break;
            }
        }
    }
}
