﻿using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace HistoriaClinica_ProyectoDeAula
{
    public class Persona
    {
        int identificacion;
        string nombre;
        string apellidos;
        DateTime fechaNacimiento;
        string tipoRegimen;
        int semanasCotizadas;
        DateTime fechaIngreso;
        DateTime fechaIngresoEPS;
        string EPS; 
        string historiaClinica;
        int cantidadEnfermedades;
        string enfermedadRelevante;
        string tipoAfiliacion;
        double costosTratamientos;

        public Persona(int identificacion, 
            string nombre, 
            string apellidos,
            DateTime fechaNacimiento, 
            string tipoRegimen, 
            int semanasCotizadas, 
            DateTime fechaIngreso, 
            DateTime fechaIngresoEPS, 
            string ePS, 
            string historiaClinica, 
            int cantidadEnfermedades, 
            string enfermedadRelevante, 
            string tipoAfiliacion, 
            double costosTratamientos)
        {
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.TipoRegimen = tipoRegimen;
            this.SemanasCotizadas = semanasCotizadas;
            this.FechaIngreso = fechaIngreso;
            this.FechaIngresoEPS = fechaIngresoEPS;
            EPS1= ePS;
            this.HistoriaClinica = historiaClinica;
            this.CantidadEnfermedades = cantidadEnfermedades;
            this.EnfermedadRelevante = enfermedadRelevante;
            this.TipoAfiliacion = tipoAfiliacion;
            this.CostosTratamientos = costosTratamientos;
        }

        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string TipoRegimen { get => tipoRegimen; set => tipoRegimen = value; }
        public int SemanasCotizadas { get => semanasCotizadas; set => semanasCotizadas = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaIngresoEPS { get => fechaIngresoEPS; set => fechaIngresoEPS = value; }
        public string EPS1 { get => EPS; set => EPS = value; }
        public string HistoriaClinica { get => historiaClinica; set => historiaClinica = value; }
        public int CantidadEnfermedades { get => cantidadEnfermedades; set => cantidadEnfermedades = value; }
        public string EnfermedadRelevante { get => enfermedadRelevante; set => enfermedadRelevante = value; }
        public string TipoAfiliacion { get => tipoAfiliacion; set => tipoAfiliacion = value; }
        public double CostosTratamientos { get => costosTratamientos; set => costosTratamientos = value; }



    }

    public class Clinica
    {
        List<Persona> listaDePacientes = new List<Persona>();

        public List<Persona> ListaDePacientes { get => listaDePacientes; set => listaDePacientes = value; }


        public void ingresarPaciente(Persona nuevoPaciente)
        {
            ListaDePacientes.Add(nuevoPaciente);

        }

        public void CambiarEPS(Persona paciente, string nuevaEPS)
        {
            paciente.EPS1 = nuevaEPS;
        }

        public double calcularPorcentajePacienteSinEnfermedad()
        {
            int cantidadDePacientes = 0;
            int cantidadDePacientes0Enfermedades = 0;
            double porcentajePacientesSinEnfermedades = 0f;
            foreach (Persona paciente in listaDePacientes)
            {
                cantidadDePacientes++;
                if (paciente.CantidadEnfermedades == 0)
                {
                    cantidadDePacientes0Enfermedades++;
                }
            }
            porcentajePacientesSinEnfermedades = (cantidadDePacientes0Enfermedades * 100) / cantidadDePacientes;
            return porcentajePacientesSinEnfermedades;
        }

        public List<double> calcularTotalCostosPorEPS()
        {
            List<double> costosEps = new List<double>();
            List<Persona>  afiliadosSura = listaDePacientes.Where(afiliado => afiliado.EPS1 == "Sura").ToList();
            List<Persona> afiliadosNuevaEps = listaDePacientes.Where(afiliado => afiliado.EPS1 == "Nueva EPS").ToList();
            List<Persona> afiliadosSaludtotal = listaDePacientes.Where(afiliado => afiliado.EPS1 == "Salud Total").ToList();
            List<Persona> afiliadosSanitas = listaDePacientes.Where(afiliado => afiliado.EPS1 == "Sanitas").ToList();
            List<Persona> afiliadosSavia = listaDePacientes.Where(afiliado => afiliado.EPS1 == "Savia").ToList();

            double costoSura = afiliadosSura.Sum(afiliado => afiliado.CostosTratamientos);
            double costoNuevaEps = afiliadosNuevaEps.Sum(afiliado => afiliado.CostosTratamientos);
            double costoSaludTotal = afiliadosSaludtotal.Sum(afiliado => afiliado.CostosTratamientos);
            double costoSanitas = afiliadosSanitas.Sum(afiliado => afiliado.CostosTratamientos);
            double costoSavia = afiliadosSavia.Sum(afiliado => afiliado.CostosTratamientos);

            costosEps.Add(costoSura);
            costosEps.Add(costoNuevaEps);
            costosEps.Add(costoSaludTotal);
            costosEps.Add(costoSanitas);
            costosEps.Add(costoSavia);
            return costosEps;

        }

        public List<double> calcularPorcentajeCostosPorEPS()
        {
            List<double> costosEps = calcularTotalCostosPorEPS();

            double costoSura = costosEps[0];
            double costoNuevaEps = costosEps[1];
            double costoSaludTotal = costosEps[2];
            double costoSanitas = costosEps[3];
            double costoSavia = costosEps[4];
            double TotalCosto = costosEps.Sum();
            double porcentajeSura = (costoSura / TotalCosto) * 100;
            double porcentajeNuevaEps = (costoNuevaEps / TotalCosto) * 100;
            double porcentajeSaludTotal = (costoSaludTotal / TotalCosto) * 100;
            double porcentajeSanitas = (costoSanitas / TotalCosto) * 100;
            double porcentajeSavia = (costoSavia / TotalCosto) * 100;

            List<double> costosPorcentajes = new List<double> { porcentajeSura, porcentajeNuevaEps, porcentajeSaludTotal, porcentajeSanitas,porcentajeSavia};
            return costosPorcentajes;

        }
        public double calcularTotalPacientesCancer()
        {
            List<Persona> afiliadosCancer = listaDePacientes.Where(afiliado => afiliado.EnfermedadRelevante == "Cancer" || afiliado.EnfermedadRelevante == "cancer" || afiliado.EnfermedadRelevante == " cancer" || afiliado.EnfermedadRelevante == " cancer ").ToList();
            double numeroPacientes = Convert.ToDouble(afiliadosCancer.Count());
            
            return numeroPacientes;
        }
        public List<double> calcularPorcentajesPorEdad()
        {
            double cantidadDePacientes = Convert.ToDouble(listaDePacientes.Count);
            double cantidadNiños = 0;
            double cantidadAdolescente = 0;
            double cantidadJovenes = 0;
            double cantidadAdultos = 0;
            double cantidadAdultoMayor = 0;
            double cantidadAnciano = 0;
            List<double> porcentajeDePacientes = new List<double>();
            
            foreach (Persona paciente in listaDePacientes)
            {
                
                
                DateTime fecha = paciente.FechaNacimiento;
                int edad = DateTime.Today.Year - fecha.Year;

                // Se ajusta la edad si aún no ha cumplido años en este año
                if (DateTime.Today < fecha.AddYears(edad))
                {
                    edad--;
                }
                if(edad >= 0 && edad < 12)
                {
                    cantidadNiños++;
                }
                if(edad >= 12 && edad < 18)
                {
                    cantidadAdolescente++;
                }
                if(edad >= 18 && edad < 30)
                {
                    cantidadJovenes++;
                }
                if(edad >= 30 && edad < 55)
                {
                    cantidadAdultos++;
                }
                if(edad >= 55 && edad < 75)
                {
                    cantidadAdultoMayor++;
                }
                if(edad >= 75)
                {
                    cantidadAnciano++;
                }


            }
            double cantidadPorcentajeNiños = (cantidadNiños * 100) / cantidadDePacientes;
            double cantidadPorcentajeJovenes = (cantidadJovenes * 100) / cantidadDePacientes;
            double cantidadPorcentajeAdolescente = (cantidadAdolescente * 100) / cantidadDePacientes;
            double cantidadPorcentajeAdultos = (cantidadAdultos * 100) / cantidadDePacientes;
            double cantidadPorcentajeAdultoMayor = (cantidadAdultoMayor * 100) / cantidadDePacientes;
            double cantidadPorcentajeAnciano = (cantidadAnciano * 100) / cantidadDePacientes;

            porcentajeDePacientes.Add(cantidadPorcentajeNiños);
            porcentajeDePacientes.Add(cantidadPorcentajeJovenes);
            porcentajeDePacientes.Add(cantidadPorcentajeAdolescente);
            porcentajeDePacientes.Add(cantidadPorcentajeAdultos);
            porcentajeDePacientes.Add(cantidadPorcentajeAdultoMayor);
            porcentajeDePacientes.Add(cantidadPorcentajeAnciano);

            return porcentajeDePacientes;
        }
        public  Persona encontrarMayorCosto()
        {

            List<Persona> listaCostosPaciente = listaDePacientes.Where(paciente => paciente.CostosTratamientos >0).ToList();
            double mayor_costo = listaCostosPaciente.Max(paciente => paciente.CostosTratamientos);
            List<Persona> paciente = listaCostosPaciente.Where(paciente => paciente.CostosTratamientos == mayor_costo).ToList();
            return paciente[0];

        }                
        public List<double> calcularPacientesPorRegimen()
        {
            List<double> porcentajes= new List<double>();
            List<Persona> afiliadosContributivo = listaDePacientes.Where(afiliado => afiliado.TipoRegimen == "Contributivo").ToList();
            List<Persona> afiliadosSubsidiado = listaDePacientes.Where(afiliado => afiliado.TipoRegimen == "Subsidiado").ToList();
            double porcentajeContributivo = (Convert.ToDouble(afiliadosContributivo.Count) / Convert.ToDouble(listaDePacientes.Count))*100;
            double porcentajeSubsidiado = (Convert.ToDouble(afiliadosSubsidiado.Count) / Convert.ToDouble(listaDePacientes.Count)) * 100;
            porcentajes.Add(porcentajeContributivo);
            porcentajes.Add(porcentajeSubsidiado);
            return porcentajes;
        }
        public List<double> calcularPorcentajePacientesPorTipoAfiliacion()
        {
            List<Persona> afiliadosCotizantes = listaDePacientes.Where(paciente => paciente.TipoAfiliacion == "Cotizante").ToList();
            List<Persona> afiliadosBeneficiarios = listaDePacientes.Where(paciente => paciente.TipoAfiliacion == "Beneficiario").ToList();
            double porcentajeCotizantes = (Convert.ToDouble(afiliadosCotizantes.Count)/Convert.ToDouble(listaDePacientes.Count))*100;
            double  porcentajeBeneficiarios = (Convert.ToDouble(afiliadosBeneficiarios.Count) /Convert.ToDouble(listaDePacientes.Count))*100;
            List<double> porcentajes = new List<double> { porcentajeCotizantes, porcentajeBeneficiarios};
            return porcentajes;


        }
    }
}