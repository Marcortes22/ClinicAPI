// See https://aka.ms/new-console-template for more information
TimeOnly tiempoInicio = new TimeOnly(8, 30); // 8:30 AM
TimeOnly tiempoFin = new TimeOnly(17, 45); // 5:45 PM

TimeSpan diferenciaTiempos = tiempoFin - tiempoInicio;
double horasDeDiferencia = diferenciaTiempos.TotalHours;
Console.WriteLine(horasDeDiferencia);
