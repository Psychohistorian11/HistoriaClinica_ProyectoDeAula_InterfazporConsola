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
                          "================================================\n");
        }

        public void ejecutar()
        {
            while (true)
            {
                mostrarMenuDeInicio();
                Console.Write("|                                              |\n" +
                              "|       Seleccione una opción:                 |\n" +
                              "|                                              |\n" +
                              "================================================\n");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
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
            string enfermedadMasRelevante = "Ninguna";
            string tipoRegimen = "";
            string tipoAfiliacion = "";
            DateTime fechaNacimiento = new DateTime();
            DateTime fechaIngreso = new DateTime();
            DateTime fechaIngresoEPS = new DateTime();
            string EPS = "";
            Console.WriteLine("================================================\n" +
                              "|                                              |\n" +
                              "|       Formulario                             |\n" +
                              "|                                              |\n" +
                              "================================================\n");
            Console.WriteLine("* Identificacón: \n" +
                              "================================================\n");
            int identificacion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("* Nombres: \n" +
                              "================================================\n");
            string nombre = Console.ReadLine();
            Console.WriteLine("* Apellidos:\n" +
                              "================================================\n");
            string apellido = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("* Fecha de nacimiento (dd/mm/yyyy):\n" +
                              "================================================\n");
                
                string fechaNacimientoMomentanea = Console.ReadLine();

                if (DateTime.TryParse(fechaNacimientoMomentanea,out fechaNacimiento))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese una fecha valida");
                    Console.ReadKey();
                }
            }
            
            while (true)
            {
                Console.WriteLine("* Tipo de regimen (1: Contributivo, 2: subsidiado): \n " + "================================================\n");
                string tipoRegimenMomentaneo = Console.ReadLine();
                if(tipoRegimenMomentaneo == "1")
                {
                    tipoRegimen = "Contributivo";
                    break;
                }
                if(tipoRegimenMomentaneo == "2")
                {
                    tipoRegimen = "Subsidiado";
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingresar valores validos");
                    Console.ReadKey();
                }
            }
            
            Console.WriteLine("* Semanas Cotizadas:\n" + "================================================\n");
            int semanasCotizadas = Convert.ToInt32( Console.ReadLine());
            while (true)
            {
                Console.WriteLine("* Fecha de Ingreso (dd/mm/yyyy): \n" + "================================================\n");
                string fechaIngresoMomentanea = Console.ReadLine();
                if(DateTime.TryParse(fechaIngresoMomentanea,out fechaIngreso))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese una fecha valida");
                    Console.ReadKey();

                }

            }
            while (true)
            {
                Console.WriteLine("* Fecha de Ingreso a la EPS (dd/mm/yyyy): \n" + "================================================\n");
                string fechaIngresoEPSMomentanea = Console.ReadLine();
                if (DateTime.TryParse(fechaIngresoEPSMomentanea, out fechaIngresoEPS))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese una fecha valida");
                    Console.ReadKey();
                }
            }
            while (true)
            {
                Console.WriteLine("* EPS: (Sura, Nueva EPS, Salud Total, Sanitas, Savia):\n" + "================================================\n");
                EPS = Console.ReadLine();
                if(EPS == "Sura" || EPS == "Nueva EPS" || EPS == "Salud Total" || EPS == "Sanitas" || EPS == "Savia")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese una EPS valida");
                    Console.ReadKey();
                }
            }
            
            Console.WriteLine("* Historia Clinica: \n" + "================================================\n");
            string historiaClinica = Console.ReadLine();
            Console.WriteLine("* Cantidad de enfermedades: \n" + "================================================\n");
            int cantidadEnfermedades = Convert.ToInt32( Console.ReadLine());
            if(cantidadEnfermedades> 0)
            {
                Console.WriteLine("* Enfermedad más relevante: \n" + "================================================\n");
                enfermedadMasRelevante = Console.ReadLine();
            }
            while (true)
            {
                Console.WriteLine("* Tipo de Afiliación (1: Cotizante, 2: beneficiario) : \n" + "================================================\n");
                string tipoAfiliacionMomentanea = Console.ReadLine();
                if(tipoAfiliacionMomentanea  == "1")
                {
                    tipoAfiliacion = "Cotizante";
                    break;
                }
                else if(tipoAfiliacionMomentanea == "2")
                {
                    tipoAfiliacion = "Beneficiario";
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor ingresar valores validos");
                    Console.ReadKey();
                }
                
            }
            
            Console.WriteLine("* Costo de Tratamientos: \n" + "================================================\n");
            double costoTratamientos = Convert.ToDouble( Console.ReadLine());

            Persona nuevoPaciente = new Persona(identificacion, nombre, apellido, fechaNacimiento,
                                                tipoRegimen, semanasCotizadas, fechaIngreso, fechaIngresoEPS, EPS,
                                                historiaClinica, cantidadEnfermedades, enfermedadMasRelevante, tipoAfiliacion,
                                                costoTratamientos);
            clinica.ingresarPaciente(nuevoPaciente);

            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("!El Paciente fue registrado con exito!");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ReadKey();

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
                        Console.WriteLine("* Se ha verifiado que la persona ha estado en el sistema de salud {0} por 3 meses o más.", paciente.EPS1);
                        Console.WriteLine("");
                        Console.WriteLine("* Ingrese la nueva EPS a la que desea ingresar (Sura, Nueva EPS, Salud Total, Sanitas, Savia)");
                        string nuevaEPS = Console.ReadLine();
                        if(paciente.EPS1 == nuevaEPS)
                        {
                            Console.WriteLine("* Señor usuario usted ya hace parte de esta EPS, no se realizara el cambio");
                            Console.ReadKey();
                            CambiarEPSConsola();
                        }
                        else
                        {
                            clinica.CambiarEPS(paciente, nuevaEPS);
                            Console.WriteLine("* El paciente Identificado con el numero "+ paciente.Identificacion + 
                                              " ahora hace parte de la EPS: "+ paciente.EPS1);
                            Console.ReadKey();
                            BackMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("* La persona ha estado en el sistema de salud por menos de 3 meses. ");
                        Console.WriteLine("  No se puede realizar el cambio de EPS ");
                        Console.ReadKey();
                        BackMenu();

                    }
                    
                }
                else
                {
                    Console.WriteLine("* El usuario actualmente no se encuentra en el sistema ");
                    Console.ReadKey();
                    BackMenu();
                }
            }

        }
        public void MostrarEstadisticasConsola()
        {
            List<double> porcentajeCostosPorEPS = clinica.calcularPorcentajeCostosPorEPS();
            List<double> totalCostosPorEPS = clinica.calcularTotalCostosPorEPS();
            double PorcentajePacientesSinEnfermedades = clinica.calcularPorcentajePacienteSinEnfermedad();
            double pacientesEnfermidadMasRelevanteCancer = clinica.calcularTotalPacientesCancer();
            Persona pacienteMayorCostosDeTratamientos = clinica.encontrarMayorCosto();
            List<double> porcentajePacientesEdad = clinica.calcularPorcentajesPorEdad();
            List<double> pacientePorRegimen = clinica.calcularPacientesPorRegimen();
            List<double> porcentajePacientesPorTipoAfiliacion = clinica.calcularPorcentajePacientesPorTipoAfiliacion();
       


            Console.WriteLine("================================================\n" +
                              "|                                              |\n" +
                              "|                 Estadisticas                 |\n" + 
                              "|                                              |\n" +
                              "================================================\n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                       \n" +
                              "|                                              |                       \n" +
                              "|     1. Porcentaje de costos por EPS          |                       \n" +
                              "|                                              |                       \n" +
                              "================================================                       \n" +
                              "                                                                       \n" +
                              "      a. Sura: " + Math.Round(porcentajeCostosPorEPS[0],2)+"%          \n" +       
                              "      b. Nueva EPS: " + Math.Round(porcentajeCostosPorEPS[1],2)+"%     \n" +
                              "      c. Salud Total: " + Math.Round(porcentajeCostosPorEPS[2], 2) +"% \n" +
                              "      d. Sanitas: " + Math.Round(porcentajeCostosPorEPS[3], 2) +"%     \n" + 
                              "      e. Savia: " + Math.Round(porcentajeCostosPorEPS[4], 2) +"%       \n" +
                              "                                                                       \n" + 
                              "================================================                       \n" );
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                     \n" +
                              "|                                              |                     \n" +
                              "|     2. Total de costos por EPS               |                     \n" +
                              "|                                              |                     \n" +
                              "================================================                     \n" +
                              "                                                                     \n" +
                              "      a. Sura: " + Math.Round(totalCostosPorEPS[0],2) +" $           \n" +
                              "      b. Nueva EPS: " + Math.Round(totalCostosPorEPS[1],2) +" $      \n" +
                              "      c. Salud Total: " + Math.Round(totalCostosPorEPS[2],2) +" $    \n" +
                              "      d. Sanitas: " + Math.Round(totalCostosPorEPS[3],2) + " $       \n" +
                              "      e. Savia: " + Math.Round(totalCostosPorEPS[4],2) + " $         \n" +
                              "                                                                     \n" +
                              "================================================                     \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                                             \n" +
                              "|                                              |                                             \n" +
                              "| 3. Porcentaje de pacientes sin enfermedades  |                                             \n" +
                              "|                                              |                                             \n" +
                              "================================================                                             \n" +
                              "                                                                                             \n" +
                              "  El " + PorcentajePacientesSinEnfermedades+"% de los pacientes no presenta enfermedades" + "\n"+
                              "                                                                                             \n" +
                              "================================================                                             \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                                             \n" +
                              "|                                              |                                             \n" +
                              "| 4. Pacientes con mayor costo en tratamientos |                                             \n" +
                              "|                                              |                                             \n" +
                              "================================================                                             \n" +
                              "                                                                                             \n" +
                              "  El paciente con numero de indetificación:                                                  \n" +
                              "  ==> "+pacienteMayorCostosDeTratamientos.Identificacion + "                                 \n" +
                              "  Apellido y nombre:                                                                         \n" +
                              "  ==> "+pacienteMayorCostosDeTratamientos.Apellidos +" "+ pacienteMayorCostosDeTratamientos.Nombre + " \n"+
                              "                                                                                             \n" +
                              "  Presenta el tratamiento mas costoso con:                                                   \n" +
                              "  ==> "+ pacienteMayorCostosDeTratamientos.CostosTratamientos+ " $                           \n" + 
                              "                                                                                             \n" +
                              "================================================                                             \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                            \n" +
                              "|                                              |                            \n" +
                              "| 5. Porcentaje de pacientes por rango de edad |                            \n" +
                              "|                                              |                            \n" +
                              "================================================                            \n" +
                              "                                                                            \n" +
                              "      a. Niños(0 - 12 años): " + porcentajePacientesEdad[0]+"%" + "         \n" +
                              "      b. Adolescente(12 - 18 años): " + porcentajePacientesEdad[1]+"%" + "  \n" +
                              "      c. Joven(18 - 30 años): " + porcentajePacientesEdad[2]+"%" + "        \n" +
                              "      d. Adulto(30 - 55 años): " + porcentajePacientesEdad[3]+"%" + "       \n" +
                              "      e. Adulto Mayor(55 - 75 años): " + porcentajePacientesEdad[4]+"%" + " \n" +
                              "      f. Anciano(>75 años): " + porcentajePacientesEdad[5] + "%" + "        \n" +
                              "                                                                            \n" +
                              "================================================                            \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================           \n" +
                              "|                                              |           \n" +
                              "| 6. Porcentaje de Pacientes por Regimen       |           \n" +
                              "|                                              |           \n" +
                              "================================================           \n" +
                              "                                                           \n" +
                              "      a. Contributivo: " + pacientePorRegimen[0] + "%" + " \n" +
                              "      b. Subsidiado: " + pacientePorRegimen[1] + "%" + "   \n" +
                              "                                                           \n" +
                              "================================================           \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                             \n" +
                              "|                                              |                             \n" +
                              "| 7. Porcentaje de Pacientes por Afiliación    |                             \n" +
                              "|                                              |                             \n" +
                              "================================================                             \n" +
                              "                                                                             \n" +
                              "      a. Cotizante: " + porcentajePacientesPorTipoAfiliacion[0] + "%" + "    \n" +
                              "      b. beneficiario: " + porcentajePacientesPorTipoAfiliacion[1] + "%" + " \n" +
                              "                                                                             \n" +
                              "================================================                             \n");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("================================================                                     \n" +
                              "|                                              |                                     \n" +
                              "| 8.  Total de pacientes cuya enfermedad mas   |                                     \n" +
                              "|     relevante sea el cancer.                 |                                     \n" +            
                              "|                                              |                                     \n" +
                              "================================================                                     \n" +
                              "                                                                                     \n" +
                              "    Un total de: "+pacientesEnfermidadMasRelevanteCancer+ " pacientes actualmente" + "\n" +
                              "                                                                                     \n" +
                              "================================================                                     \n");
            Console.ReadKey();
            BackMenu();




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
