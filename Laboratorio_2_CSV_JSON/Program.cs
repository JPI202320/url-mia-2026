using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string archivoCSV = "estudiantes.csv";

        List<Estudiante> estudiantes = new List<Estudiante>();

        if (!File.Exists(archivoCSV))
        {
            Console.WriteLine("No se encontró el archivo estudiantes.csv");
            return;
        }

        string[] lineas = File.ReadAllLines(archivoCSV);

        // Omitir encabezado del archivo CSV
        for (int i = 1; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(',');

            Estudiante estudiante = new Estudiante();

            estudiante.Id = Convert.ToInt32(datos[0]);
            estudiante.Nombre = datos[1];
            estudiante.Carrera = datos[2];

            estudiantes.Add(estudiante);
        }

        Console.WriteLine("Lista de estudiantes:\n");

        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine(estudiante.Id + " - " 
                + estudiante.Nombre + " - " 
                + estudiante.Carrera);
        }

        Console.WriteLine();

        // Convertir la lista a formato JSON
        string json = JsonSerializer.Serialize(estudiantes, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        // Crear archivo JSON
        File.WriteAllText("estudiantes.json", json);

        Console.WriteLine("Archivo estudiantes.json creado correctamente.");
    }
}


