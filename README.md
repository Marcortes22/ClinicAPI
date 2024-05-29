# Proyecto 2

Este proyecto se centra en el desarrollo de una aplicación web de gestión de una clínica; además, requiere utilizar módulos que permitan el manejo de pacientes,asignación y cancelación de citas. Utilizando .NET como framework principal. 

## Authors

- [@marcortes20](https://github.com/marcortes20)
- [@JosePabloSG](https://github.com/JosePabloSG)
- [@Adriana](https://github.com/Adriana-06)
- [@Nazagomez](https://github.com/Nazagomez)
- [@Yeilinnn](https://github.com/Yeilinnn)

## Features Back End

Una Clínica requiere utilizar un aplicativo que permita el manejo de pacientes,
asignación y cancelación de citas.  
A continuación, se encuentra el listado de los requerimientos sugeridos por el
experto que deben ser tomados en cuenta al momento de desarrollar.  
### El aplicativo contiene la siguiente información:  
● Información del paciente (Nombre, Email, Teléfono).  
● Información de la cita. (Fecha y hora, Lugar, Status).  
● La clínica puede tener varias sucursales.  
● El sistema deberá manejar 2 roles principales.
 USER y ADMIN  
### Los tipos de citas que atenderá la Clínica son:  
○ Medicina General  
○ Odontología  
○ Pediatría  
○ Neurología  
### La Clínica solicita que se agreguen las siguientes reglas de negocio:  
● Las citas se deben cancelar con mínimo 24 horas de antelación.  
 La cita cancelada no se elimina, solo cambia de status ACTIVA a
CANCELADA.  
● No se puede crear otra cita para el mismo paciente en el mismo día.  
● Envío de correo de confirmación al paciente con todos los detalles de la cita.  
● El usuario con el rol USER sería el paciente quien puede crear y editar una cita.  
● Solo un usuario ADMIN puede Eliminar una cita.  
● Deberá haber un mecanismo de Registro y Login.  
## Aspectos Técnicos
● Utilizar NET Core API para los endpoints.  
● Crear los servicios necesarios y utilizar inyección de dependencias.  
● Utilizar EntityFramework para la conexión a la base de datos.  
● Utilizar SQL Server  
● Implementar Login al API utilizando Json Web Token.
● Implementar el uso de ROLES en el token. (Investigación)
● User y Role son entidades separadas.  
### Opcional
● Proyecto de pruebas unitarias que cubra por lo menos los escenarios de las
reglas de negocio más importantes utilizando XUnit y FluentAssertion.  
